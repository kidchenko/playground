. "$PSScriptRoot\CodeCoverage.ps1"

Describe "Get-Thing" {
    $result = Get-Thing

    It "Should return 'I got the thing'" {
        $result | Should -Be "I got the thing"
    }
}

# Describe "Get-Thing" {
#     $result = Do-Thing

#     It "Should return 'I did the thing'" {
#         $result | Should -Be "I did the thing"
#     }
# }

# Describe "Set-Thing" {
#     $result = Set-Thing

#     It "Should return 'I set the thing'" {
#         $result | Should -Be "I set the thing"
#     }
# }

# Invoke-Pester -Script "./CodeCoverage.Tests.ps1" -CodeCoverage "./CodeCoverage.ps1"

# We are scopping our CodeCoverage here to just check a specific function

# Invoke-Pester -Script "./CodeCoverage.Tests.ps1" -CodeCoverage @{ Path = "./CodeCoverage.ps1"; Function = "Get-Thing" } 

# Invoke-Pester -Script "./CodeCoverage.Tests.ps1" -CodeCoverage @{ Path = "./CodeCoverage.ps1"; StartLine = 7; EndLine = 10 } 
