## TESTS FOR ALL FUNCTIONS REFERENCED IN THE SYNC-ADUSER.PS1 SCRIPT.

## Remove all loaded functions
Get-Module -Name AdUserSync -All | Remove-Module -Force

## Ensure functions are not called from modules that are already loaded
Import-Module "$PSScriptRoot\AdUserSync.psm1" -Force

InModuleScope 'AdUserSync' {
    Describe 'Get-AdUserDefaultPassword' {

        ## Must mock this to control what gets passed to ConvertTo-SecureString and we're asserting this command was called.
        Mock 'Import-CliXml' {
            $testCred = New-MockObject -Type 'System.Management.Automation.PSCredential'

            ## No built-in way to mock a .NET method. We must use PowerShell extended type system to replace it instead.
            $addMemberParams = @{
                MemberType = 'ScriptMethod'
                Name = 'GetNetworkCredential'
                Value = { @{'Password' = 'Foo'} }
                Force = $true
            }
            $testCred | Add-Member @addMemberParams
            $testCred
        }

        It 'builds the default FilePath parameter correctly and passes it to Import-CliXml' {

            #############
            ## HIGHLIGHT
            #############
            ## Assign to $null. I'm just asserting a command was called. I don't care what it returns.
            $null = Get-AdUserDefaultPassword

            $assMParams = @{
                CommandName = 'Import-CliXMl'
                Times = 1
                Exactly = $true
                Scope = 'It'
                ParameterFilter = { 
                    $Path -eq 'C:\Dropbox\GitRepos\MIcrosoftVIrtualAcademy\Creating Tests for PowerShell using Pester\Demos\Project 1 - PowerShell Project\Artifacts\DefaultUserPassword.xml' 
                }
            }
            Assert-MockCalled @assMParams
        }

        It 'returns a single secure string' {
            
            $result = Get-AdUserDefaultPassword

            ## Figure out what type of object ConvertTo-SecureString returns to get this assertion
            ## ConvertTo-SecureString -String 'foo' -AsPlainText -Force | Get-Member

            $result.Count | should be 1

            #############
            ## HIGHLIGHT
            #############
            $result | should beofType 'System.Security.SecureString'
        }

        #############
        ## HIGHLIGHT
        #############
        It 'converts the expected password to a secure string' {

            ## This It block is last on purpose because I'm creating a mock that I don't want applied to the It
            ## blocks above.     

            Mock 'ConvertTo-SecureString'

            $null = Get-AdUserDefaultPassword

            $assMParams = @{
                CommandName = 'ConvertTo-SecureString'
                Times = 1
                Exactly = $true
                Scope = 'It'
                ParameterFilter = { $String -eq 'Foo' } ## Output from our "mocked" GetNetworkCredential method
            }
            Assert-MockCalled @assMParams

        }
    }

    Describe 'Get-ActiveEmployee' {

        #############
        ## HIGHLIGHT
        #############
        ## "Fake"" CSV data just to test with based on the real data
        Mock 'Import-Csv' {
            ConvertFrom-Csv -InputObject @'
    "FirstName","LastName","Department","Title"
    "Katie","Green","Accounting","Manager of Accounting"
    "Joe","Blow", "Information Systems","System Administrator"
    "Joe","Schmoe", "Information Systems", "Software Developer"
    "Barack","Obama", "Executive Office", "CEO"
    "Donald","Trump", "Janitorial Services", "Custodian"
'@
        }

        Mock 'Test-Path' {
            $true
        }

        It 'returns the expected number of objects' {

            $result = Get-ActiveEmployee
            $result.Count | should be 5

        }

        #############
        ## HIGHLIGHT
        #############
        It 'returns objects that have an ADuserName property appended' {
            
            ## I've chosen not to mock the function (Get-EmployeeUserName) creates the ADUserName property. I do this because
            ## I trust this function because I also have tests for it.

            $result = Get-ActiveEmployee
            $result.ADUserName | should not benullorempty

        }

        It 'returns objects that have an OUPath property appended' {
            
            $result = Get-ActiveEmployee
            $result.OUPath | should not benullorempty

        }

        #############
        ## HIGHLIGHT
        #############
        It 'throws an exception when the CSV file cannot be found' {
            
            Mock 'Test-Path' {
                $false
            }

            { Get-ActiveEmployee } | should throw 'could not be found'
        }


        It 'builds the default FilePath parameter correctly and passes it to Import-Csv' {

            Mock 'Import-Csv'

            Mock 'Test-Path' {
                $true
            }

            ## This it block is last again on purpose
            $null = Get-ActiveEmployee

            $assMParams = @{
                CommandName = 'Import-Csv'
                Times = 1
                Exactly = $true
                Scope = 'It'
                ParameterFilter = { 
                    $Path -eq 'C:\Dropbox\GitRepos\MIcrosoftVIrtualAcademy\Creating Tests for PowerShell using Pester\Demos\Project 1 - PowerShell Project\Artifacts\Employees.csv' 
                }
            }
            Assert-MockCalled @assMParams
        }
    }

    Describe 'Get-InactiveEmployee' {

        #############
        ## HIGHLIGHT
        #############
        Mock 'Get-ActiveEmployee' {
            ## Must create something with ADUserName since we're referencing that property in the function.
            [pscustomobject]@{
                ADUserName = 'user1'
            }
            [pscustomobject]@{
                ADUserName = 'user2'
            }
            [pscustomobject]@{
                ADUserName = 'user3'
            }
        }

        It 'should only query for AD users that are enabled' {

            ## This will only create the mock if the parameter filter is $true
            Mock 'Get-AdUser' {

            } -ParameterFilter { $Filter -like "*Enabled -eq 'True'*" }

            $null = Get-InactiveEmployee

            $assMParams = @{
                CommandName = 'Get-AdUser'
                Times = 1
                Exactly = $true
                Scope = 'It'
            }
            Assert-MockCalled @assMParams
        }

        It 'should exclude the domain administrator account from the AD user query' {

            ## This will only create the mock if the parameter filter is $true
            Mock 'Get-AdUser' {

            } -ParameterFilter { $Filter -like "*SamAccountName -ne 'Administrator'*" }

            $null = Get-InactiveEmployee

            $assMParams = @{
                CommandName = 'Get-AdUser'
                Times = 1
                Exactly = $true
                Scope = 'It'
            }
            Assert-MockCalled @assMParams
        }

        It 'should only return AD users that are not in the CSV file' {

            ## Purposefully add users that are AND aren't active to test the filter
            Mock 'Get-AdUser' {
                [pscustomobject]@{
                    samAccountName = 'user1'
                }
                [pscustomobject]@{
                    samAccountName = 'user2'
                }
                [pscustomobject]@{
                    samAccountName = 'inactive1'
                }
                [pscustomobject]@{
                    samAccountName = 'inactive2'
                }
            } -ParameterFilter { $Filter } ## This is required since we're mocking with the param filter above

            $result = Get-InactiveEmployee
            
            diff $result.samAccountName @('inactive1','inactive2') | should benullorempty

        }   
    }

    Describe 'Get-EmployeeUsername' {

        $result = Get-EmployeeUsername -FirstName 'Bob' -LastName 'Jones'

        It 'should return a single string' {
            @($result).Count | should be 1
            $result | should beofType 'string'
        }
        
        ## This test is technically not required since we're inherently testing this in the assertion below. However,
        ## I choose to do this to make the tests more explicit and easier to pinpoint problems.
        It 'should return the first initial of the first name as the first character' {
            $result.SubString(0,1) | should be 'B'
        }

        It 'should return the expected username' {
            $result | should be 'BJones'
        }
    }

    Describe 'Get-DepartmentOUPath' {
        $result = Get-DepartmentOUPath -OUPath 'departmentHere'

        It 'returns a single string' {
                @($result).Count | should be 1
                $result | should beofType 'string'
        } 

        It 'returns the expected OU path' {
                $result | should be 'OU=departmentHere,DC=mylab,DC=local'
        }
    }

    Describe 'Test-AdUserExists' {
        
        It 'returns $true if the user account can be found in AD' {
            Mock 'Get-AdUser' {
                $true
            }
            $result = Test-AdUserExists -UserName 'bjones'
            $result | should be $true
        }

        It 'returns $false if the user account cannot be found in AD' {
            Mock 'Get-AdUser'

            $result = Test-AdUserExists -UserName 'bjones'
            $result | should be $false
        }
    }

    Describe 'Test-AdGroupExists' {


        It 'returns $true if the group can be found in AD' {
            Mock 'Get-AdGroup' {
                $true
            }
            $result = Test-AdGroupExists -Name 'whatever'
            
            $result | should be $true
        }

        It 'returns $false if the group cannot be found in AD' {
            Mock 'Get-AdGroup'

            $result = Test-AdGroupExists -Name 'whatever'
            $result | should be $false
        }
    }

    Describe 'Test-AdGroupMemberExists' {

        It 'returns $true if the username is a member of the group' {
            Mock 'Get-AdGroupMember' {
                @{
                    Name = 'bjones'
                }
            }

            $result = Test-AdGroupMemberExists -UserName 'bjones' -GroupName 'groupnamehere'
                
            $result | should be $true
        }

        It 'returns $false if the username is not a member of the group' {
            Mock 'Get-AdGroupMember' {
                @{
                    Name = 'someotherusernamehere'
                }
            }

            $result = Test-AdGroupMemberExists -UserName 'bjones' -GroupName 'groupnamehere'
            
            $result | should be $false
        }
    }

    Describe 'Test-ADOrganizationalUnitExists' {
        
        It 'creates the proper full OU DN and passes to Get-ADOrganizationalUnit' {
            Mock 'Get-ADOrganizationalUnit' {
                $true
            }

            $null = Test-ADOrganizationalUnitExists -DistinguishedName 'OU=departmentHere,DC=mylab,DC=local'

            $assMParams = @{
                CommandName = 'Get-AdOrganizationalUnit'
                Times = 1
                Exactly = $true
                Scope = 'It'
                ParameterFilter = {$Filter -eq "DistinguishedName -eq 'OU=departmentHere,DC=mylab,DC=local'" }
            }
            Assert-MockCalled @assMParams
        }

        It 'returns $true if the group can be found in AD' {

            $result = Test-ADOrganizationalUnitExists -DistinguishedName 'OU=departmentHere,DC=mylab,DC=local'
            $result | should be $true
        }

        It 'returns $false if the group cannot be found in AD' {
            Mock 'Get-ADOrganizationalUnit'

            $result = Test-ADOrganizationalUnitExists -DistinguishedName 'OU=departmentHere,DC=mylab,DC=local'
            
            $result | should be $false
        }
    }

    Describe 'New-CompanyAdUser' {

        #############
        ## HIGHLIGHT
        #############
        function DecryptSecureString {
            param($String)
            [Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR($String))
        }

        $securePass = (ConvertTo-SecureString -String 'foo' -AsPlainText -Force)
        $ptPass = DecryptSecureString -String $securePass

        #############
        ## HIGHLIGHT
        #############
        Mock 'Get-ADUserDefaultPassword' -Verifiable {
            $securePass
        }

        Mock 'New-Aduser' -Verifiable {

        } -ParameterFilter {
            $UserPrincipalName -eq 'fLastNameHere' -and
            $Name -eq 'fLastNameHere' -and
            $GivenName -eq 'firstNameHere' -and
            $SurName -eq 'lastNameHere' -and
            $Title -eq 'titleHere' -and
            $Department -eq 'departmentHere' -and
            $SamAccountName -eq 'fLastNameHere' -and
            (DecryptSecureString $AccountPassword) -eq $ptPass -and
            $Path -eq 'OU=Users,DC=mylab,DC=local' -and
            $Enabled -eq $true -and
            $ChangePasswordAtLogon -eq $true
        }

        $params = @{
            Employee = [pscustomobject]@{
                FirstName = 'firstNameHere'
                LastName = 'lastNamehere'
                Department = 'departmenthere'
                Title = 'titleHere'
            }
            Username = 'flastNameHere'
            OrganizationalUnit = 'OU=Users,DC=mylab,DC=local'
        }
        $result = New-CompanyAdUser @params

        It 'should attempt to create an AD user with the proper parameters' {

            Assert-VerifiableMocks
        }
    }
}