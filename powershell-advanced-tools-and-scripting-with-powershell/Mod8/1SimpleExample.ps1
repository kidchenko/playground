# Powershell has a variable called $ConfirmPreference with default value `High`
# If you change the value to `Medium` powershell will ask to confirm when executing the function
# Because in the function we are setting the ConfirmImpact to Medium

# If you use -WhatIf the function will just say what it will do
# If you use -Verbose the function will execute and say what it is doing
# If you use -Confirm the function will say what will do and ask for you confirm the action
function Set-Stuff 
{
    
    [Cmdletbinding(
        SupportsShouldProcess=$true, # This make -WhatIf works
        ConfirmImpact='Medium'
    )]
    param(
        [Parameter(Mandatory=$True)]
        [string]$computername
    )
    
    process {
    
        If ($PSCmdlet.ShouldProcess("$Computername", "THIS IS THE NAME OF OPERATION")){
            Write-Output 'Im changing something right now'
        }
    }
}
