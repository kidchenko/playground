Get-Process | Where-Object Handles -GT 900

Write-Output "`n Now ordered: `n"

Get-Process | Where-Object Handles -GT 900 | Sort-Object Handles

# Dump the object in console
Get-Service -Name BITS | Get-Member

# Select just some properties of the object
Get-Service | Select-Object -Property Name, Status, StartType

Get-ChildItem | Select-Object -Property Name, Length | Sort-Object Length

Write-Output "`n Now ordered in Descending Order: `n"

Get-ChildItem | Select-Object -Property Name, Length | Sort-Object Length -Descending

Get-EventLog -LogName System -Newest 5 | Select-Object EventID, TimeWritten, Message | Sort-Object TimeWritten

Get-Service | Where-Object { $_.Status -eq "Running" }
# same of
# Get-Service | Where-Object { $PSItem.Status -eq "Running" }

Get-Help *comparsion*

Get-Help *operators*

Get-Service | Where-Object { $PSItem.Status -eq "Running" -and $_.Name -like "b*" }

# Think about this 2 ps scripts
Get-Service | Sort-Object | Where-Object { $_.Status -eq "Running" } | Out-File ".\juca.txt"

# This is better. So it does matter where you filter and where you sort
# You should filter as left you can
Get-Service | Where-Object { $_.Status -eq "Running" } | Sort-Object | Out-File ".\juca.txt"

# History about the powershell 'Where' operator the initiall idea was do SQL against .NET Objects, so 3 months ago, the result was not good
# So, they redesign it, and replaced it with three lines of code
# The ree lines of code, 
    # Step 1 takes each object that comes in the pipleline and assign it to a variable $_ and now $PSItem too. 
    # Step 2 evaluate the code inside {} 
    # Step 3 if the step 2 returns true, we pass the object on, if it doesn't we throw it away
    # trie this
    # gps *ss | Where {$false}
    # gps *ss | Where {$true}

# PS have 2 versions of where

# full vesion
gps | where { $_.Handles -ge 1000 }

# sub-set version
gps | where Handles -GE 1000

# Good resources
# www.powershell.org > forums > free-ebooks > podcast
# https://docs.microsoft.com/en-us/powershell/