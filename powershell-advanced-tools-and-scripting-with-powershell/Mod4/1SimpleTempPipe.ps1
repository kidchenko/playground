<#
 Comment based help
#>
Function Verb-Noun {

    [CmdletBinding()]
    Param(
        [Parameter(ValueFromPipeline=$true)]
        [String]$MyString
    )

    Begin {
        "Begin $MyString" # Begin will be called once and $MyString will be empty
    } 
    Process {
        "Process $MyString" # Process will be called 3 times
    }
    End {
        "End $MyString" # Process will be called once and $MyString will recieve 3
    }
}

1..3 | Verb-Noun