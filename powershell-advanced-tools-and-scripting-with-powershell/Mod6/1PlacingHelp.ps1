# Help file for Help
Get-Help *about_Comment_Based_Help*
Get-Help Get-TestHelp -ShowWindow


<#
.Synopsis
This is the short description
#> 
# If you put 2 blank lines before the help you break your help, 
Function Get-TestHelp{
    # You can put your help here

    [CmdletBinding()]
    param()

    Begin{}
    Process{}
    End{}

    # Or you can put your help here
}