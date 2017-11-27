Describe 'Get-AdUserDefaultPassword' {

    It 'builds the default FilePath parameter correctly and passes it to Import-CliXml' {

    }

    It 'returns a single secure string' {
               
    }

    It 'converts the expected password to a secure string' {

    }
}

Describe 'Get-ActiveEmployee' {

    It 'returns the expected number of objects' {        

    }

    It 'returns objects that have an ADuserName property appended' {
        
    }

    It 'returns objects that have an OUPath property appended' {

    }

    It 'throws an exception when the CSV file cannot be found' {

    }


    It 'builds the default FilePath parameter correctly and passes it to Import-Csv' {

    }
}

Describe 'Get-InactiveEmployee' {

    It 'should only query for AD users that are enabled' {

    }

    It 'should exclude the domain administrator account from the AD user query' {
    
    }

    It 'should only return AD users that are not in the CSV file' {

    }   
}

Describe 'Get-EmployeeUsername' {

    It 'should return a single string' {

    }
    
    It 'should return the first initial of the first name as the first character' {
    
    }

    It 'should return the expected username' {
    
    }
}

Describe 'Get-DepartmentOUPath' {


    It 'returns a single string' {

    } 

    It 'returns the expected OU path' {

    }
}

Describe 'Test-AdUserExists' {
    
    It 'returns $true if the user account can be found in AD' {

    }

    It 'returns $false if the user account cannot be found in AD' {

    }
}

Describe 'Test-AdGroupExists' {

    It 'returns $true if the group can be found in AD' {

    }

    It 'returns $false if the group cannot be found in AD' {

    }
}

Describe 'Test-AdGroupMemberExists' {

    It 'returns $true if the username is a member of the group' {

    }

    It 'returns $false if the username is not a member of the group' {

    }
}

Describe 'Test-ADOrganizationalUnitExists' {
    
    It 'creates the proper full OU DN and passes to Get-ADOrganizationalUnit' {

    }

    It 'returns $true if the group can be found in AD' {


    }

    It 'returns $false if the group cannot be found in AD' {

    }
}

Describe 'New-CompanyAdUser' {

    It 'should attempt to create an AD user with the proper parameters' {

    }
}