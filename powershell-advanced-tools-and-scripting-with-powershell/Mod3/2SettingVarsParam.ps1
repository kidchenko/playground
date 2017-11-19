param(
    [String]$ComputerName="kidchenko",
    [String]$Drive="c:"
)

#Choose values to replace with variables
# For unix like compatible you can access the args using $args

Write-Output 'Using $args: '
$args
$args.GetType()
$args[0]
$args.Count

Get-WmiObject -class Win32_logicalDisk -Filter "DeviceID='$Drive'" -ComputerName $ComputerName