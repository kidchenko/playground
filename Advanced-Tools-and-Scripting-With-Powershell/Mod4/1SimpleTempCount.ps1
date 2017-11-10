# you can create functions that are similar to cmddlets
# Functions are not the same as compiled cmdlets. but are perfect the for IT PRO

<#
 Comment based help
#>
Function Get-Sum {

    [CmdletBinding()]
    Param(
        [Parameter(ValueFromPipeline=$true)]
        [int]$x
    )

    # begin is to setup your code
    Begin {
        $total = 0;
    } 
    Process {
        $total += $x
    }
    End {
        "Total $total"
    }
}

1..3 | Get-Sum