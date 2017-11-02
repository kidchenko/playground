# AllSigned vs Remote Signed
# AllSigned means every script that you download and creat locally need to be signed
# Remote Signed meams just script downloaded need to be signed

Get-Help *variable*

$myVar = Get-Service BITS
$myVar | Get-Member
$myVar.Status
$myVar.Stop()
$myVar.Status
$myVar.Refresh()
$myVar.Start()
$myVar.Refresh()
$myVar.Status

# Why variables in PS have start with a $? Becuse if you write just myVar the PS don't know if myVar is a declaration of a invocation of a Cmdlet

$var = Read-Host "Enter a computerName"
Get-Service -Name BITS -ComputerName $var

# don't use Write-Host use Write-Output

${ THIS IS A TEST } = 4
${ THIS IS A TEST} = 1

# Can I use emoji for variables? try it

1..5 > variables.txt
${C:\kidchenko\playground\Getting-Started-with-Microsoft-PowerShell\variables.txt}

${C:\kidchenko\playground\Getting-Started-with-Microsoft-PowerShell\variables.txt} = "ARE YOU FREAKING KIDDING ME?"

${C:\kidchenko\playground\Getting-Started-with-Microsoft-PowerShell\variables.txt}

# The last example works because when PS see a $ sign, he understand that it is a place to store data. As general we store data in memory

${☺} = ":)"
${☺}