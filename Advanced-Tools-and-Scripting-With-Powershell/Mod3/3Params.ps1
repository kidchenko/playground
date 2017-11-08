# add the Param block

function t {

    # This transform a function into a full Cmdlet
[CmdletBinding()]
param(
    [String]$ComputerName='Client',
    [String]$Drive='c:'
)

    Get-WmiObject -class Win32_logicalDisk -Filter "DeviceID='$Drive'" -ComputerName $ComputerName
}