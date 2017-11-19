# Pipeline pass values ByValue or ByPropertyName

calc.exe
Get-Process calc | Get-ChildItem

# Here I am creating a new propery called 'ComputerName' and assign to the object
# Get Service receive a -ComputerName parameter
Get-AdComputer -Filter * | Select -Property name, @{name = 'ComputerName'; e={$_.name}} | Get-Service

# return list of strings with the computer name
get-AdComputer -filter * | select -ExpandProperty name | gm

# WmiObject don't support pipeline
# New API Get-CimInstance support it
Get-WmiObject -Class win32_bios -ComputerName (get-ADComputer -filter * | Select -ExpandProperty Name)
# same
Get-WmiObject -Class win32_bios -ComputerName (get-ADComputer -filter *).Name

Get-CimInstance -ClassName win32_bios