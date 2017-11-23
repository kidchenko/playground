## Helper function to Start-ClusterTest
function Restart-Cluster {
    param($ClusterName)

    ## Do whatever it takes to restart the cluster here
}
    
## Helper function to Start-ClusterTest
function Test-ClusterProblem {
    param($ClusterName)

    ## Check some stuff here. Return either $true if all checks passed
    ## or false if they did not. For now, we'll just return $true.
    $true
}

function Start-ClusterTest {
    param($ClusterName)

    # Write-Host 'Starting cluster test...'
    $result = Test-ClusterProblem -ClusterName $ClusterName ## Run another function
    if ($result) {
        $true
    } else {
        Restart-Cluster -ClusterName $ClusterName
    }
}

Describe 'Start-ClusterTest' {

    ## Create mocks to simply let the function execute and essentially do nothing
    Mock 'Write-Host'

    Mock 'Test-ClusterProblem' {
        $true
    }

    Mock 'Restart-Cluster' ## Null

    $result = Start-ClusterTest -ClusterName 'DOESNOTMATTER'

    ## These it blocks do not depend on a specific scenario and are not in a context block.
    It 'Write-Host does not be called' {

        $paramValues = @{
            CommandName = 'Write-Host'
            Times = 0
            Exactly = $true
        }

        Assert-MockCalled @paramValues
    }

    It 'Should tests the correct cluster' {

        $paramValues = @{
            CommandName = 'Test-ClusterProblem'
            Times = 1
            Exactly = $true
            ParameterFilter = {
                $ClusterName -eq 'DOESNOTMATTER'
            }
        }

        Assert-MockCalled @paramValues
    }

    Context 'When a problem is detected with a cluster' {
        
        ## This mock overrides Test-ClusterProblem only in this context block. We are ONLY testing the scenario
        ## when there's a problem with the cluster.

        Mock 'Test-ClusterProblem' {
            $false
        }

        Start-ClusterTest -ClusterName 'DOESNOTMATTER'

        It 'Attempts to restart the cluster' {
            
            $paramValues = @{
                CommandName = 'Restart-Cluster'
                Times = 1
                Exactly = $true
                ParameterFilter = { $ClusterName -eq 'DOESNOTMATTER' }
            }
            Assert-MockCalled @paramValues
        }
    }

    context 'When no problems are detected on the cluster' {
        
        ## Override again to simulate the scenario
            mock 'Test-ClusterProblem' {
            $true
        }  

        $result = Start-ClusterTest -ClusterName 'DOESNOTMATTER'

        it 'Should return $true' {
            $result | should be $true
        }
    }
}