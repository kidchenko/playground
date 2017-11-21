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
        "No you did not"
    }
    
    $result = Start-ClusterTest -ClusterName "SERVER1"

    It "Returns a string with ClusterName inside" {
        $result | Should -Be "I did the thing against SERVER1"
    }
}