# begin test no pass, no implementation
function Test-Foo {
    param(
        $FilePath
    )
}

# second step, make one test pass
# function Test-Foo {
#     param(
#         $FilePath
#     )

#     if (Select-String -Path $FilePath -Pattern "foo") {
#         $true
#     }
}

# final step, make all tests pass
# function Test-Foo {
#     param(
#         $FilePath
#     )

#     if (Select-String -Path $FilePath -Pattern "foo") {
#         $true
#     } else {
#         $false
#     }
# }

Describe "Test-Foo" {

    BeforeAll {
        Add-Content -Path TestDrive:\foofile.txt -Value "foo"

        Add-Content -Path TestDrive:\nofoofile.txt -Value "not here"
    }

    $fooOutput = Test-Foo -FilePath TestDrive:\foofile.txt
    $noFooOutput = Test-Foo -FilePath TestDrive:\nofoofile.txt


    It 'When the file has "foo", it should return $true' {
        
        $fooOutput | Should -Be $true
        $fooOutput | Should -BeOfType 'bool'
        @($fooOutput).Count | Should -Be 1
    }

    It 'When the file dones not have "foo", it should return $false' {

        $noFooOutput | Should -Be $false
        
    }
}
