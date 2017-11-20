Test-Path TestDrive:\

Describe "TestDrive Demo" {
    Write-Host (Test-Path TestDrive:\)

    BeforeAll {
        Add-Content -Path TestDrive:\testfile.txt -Value "testfile"
    }

    AfterAll {
        Write-Host (Get-Content -Path TestDrive:\testfile.txt)
    }

    It "TestDrive exists" {
        "TestDrive:\" | Should -Exist
    }

    It "The File we createed in the TestDrive exists" {
        "TestDrive:\testfile.txt" | Should -Exist
    }
}