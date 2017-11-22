function Start-ClusterTest {
    param($ClusterName)

    Write-Host "Doing the thing..."
    Write-Output "I did the thing against $ClusterName"
}

Describe "Start-ClusterTest" {
    
    $result = Start-ClusterTest -ClusterName "SERVER1"

    It "Returns a string with ClusterName inside" {
        $result | Should -Be "I did the thing against SERVER1"
    }
}

Describe "Start-ClusterTestMock" {

    Mock -CommandName "Write-Output" -MockWith {
        "describemock"
    }
    
    $result = Start-ClusterTest -ClusterName "SERVER1"

    It "Returns a string with ClusterName inside" {
        $result | Should -Be "describemock"
    }

    Context "MockScope1" {
        
        # Override the previous mock, This only applices within this context block
        Mock -CommandName "Write-Output" -MockWith {
            "mockscope1"
        }

        $result = Start-ClusterTest -ClusterName "SERVER1"

        # Pass because the mock is applied
        It "Does the thing in the mock scope1 context" {
            $result | Should -Be "mockscope1"
        }

        # Fail because we are inside the context the mock still overwriten
        It "Does the thing in the mock scope1 context" {
            $result | Should -Be "describeMock"
        }
    }

    Context "MockScope2" {
        
        Mock -CommandName "Write-Output" -MockWith {
            "mockscope2"
        }

        $result = Start-ClusterTest -ClusterName "SERVER1"

        # Wich will pass?
        It "Does the thing in the mock scope1 context" {
            $result | Should -Be "mockscope1"
        }

        It "Does the thing in the mock scope2 context" {
            $result | Should -Be "mockscope2"
        }

        It "Does the thing in the mock" {
            $result | Should -Be "describeMock"
        }
    }

    It "Mock outside scope" {
        $result | Should -Be "describemock"
    }
}