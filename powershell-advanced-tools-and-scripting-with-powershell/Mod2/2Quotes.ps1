#Quotation Markes

#Double quotes resolve the variable
$i="PowerShell"

"This is the variable $i, and $i Rocks!"
'This is the variable $i, and $i Rocks!'
"This is the variable `$i, and $i Rocks!"

$computerName="Client"
Get-service -name bits -ComputerName "$ComputerName" | 
    Select MachineName, Name, Status

$p = Get-Process lsass

# Will print $p as string
"Process id = $p.id"

# Will get the id
"Process id = $($p.id)"

$text = @"
ola
hi
swadee
test
"@