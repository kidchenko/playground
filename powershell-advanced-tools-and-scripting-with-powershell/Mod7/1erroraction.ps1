$ErrorActionPreference

ls variable:*pref*

Get-WmiObject win32_bios -ComputerName NotOnline, localhost

# ErrorAction wich can be abbreviated as -EA
# ErrorVariable wich can be abbreviated as -EV
Get-WmiObject win32_bios -ComputerName DC,NotOnline,Client -EA SilentlyContinue -EV MyError
$MyError

Get-WmiObject win32_bios -ComputerName DC,NotOnline,Client -EA Stop

# Inquire ask for the user
Get-WmiObject win32_bios -ComputerName DC,NotOnline,Client -EA Inquire

gps |  select id

# Now $e is a array of erros
Stop-Process 99999, 999991 -EV e

$e[0] | gm

# fl => Format-List
$e[0] | fl * # This work for other commands, but for erros don't because powershell treat erros as special type of objects
$e[0] | fl * -Force # This will work! 

# Powershell does not autocomplete this but the property exist
$e.TargetObject

# This is interesing becuase If you want execute a batch of commands, and some fails and some get success
# You can itereate in $e.TargetObject and retry 
foreach ($t in $e.TargetObject) {
    Write-Output $t
}

ls variable:*error*

# ErrorView is other trick in powershell, this show just the category of the error.
$ErrorView = "CategoryView"
Stop-Process 99999, 999991

$ErrorView = "NormalView"
Stop-Process 99999, 999991

# If you want search by a error in powershell, search by the FullyQualifiedErrorId 
# You can find the FullyQualifiedErrorId reading the error message

# For error log you can use the Windows Event Log
# You need to register the Source used in parameter -Source
Write-EventLog -LogName Application -Source MySource -EntryType Information -Message "MyMessage" -EventId "Juca"

# Idea how you can show and prove that you are saving money in automating and scripting
# You can write an EventLog each time that your script run
# In the week/month/run you can get the event log to see how much you save in time running the script x the manual way
# Then you can do a calculation that using like: Saved Time Using Script * Cost of Money by Our, then you have how
# Much money you saved.