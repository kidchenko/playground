# you can create functions that are similar to cmddlets
# Functions are not the same as compiled cmdlets. but are perfect the for IT PRO
Get-Help *functions*

<#
 Comment based help
#>
Function Verb-Noun {

    [CmdletBinding()]
    Param(
        [Parameter()][String]$MyString
    )

    # begin is to setup your code
    Begin {
        "Begin $MyString"
    }
    
    # process is the processing of your code
    Process {
        "Process $MyString"
    }

    # end is to clean your resources and close connections
    End {
        "End $MyString"
    }
}

Verb-Noun -MyString "Juca"