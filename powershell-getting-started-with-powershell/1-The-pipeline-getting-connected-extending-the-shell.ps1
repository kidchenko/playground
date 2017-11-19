Get-Service | Export-Csv -Path './services.csv'

Import-Csv './services.csv'

Get-Process | Export-Clixml -Path "./process.xml"

calc

Compare-Object -ReferenceObject (Import-Clixml "./process.xml") -DifferenceObject (Get-Process) -Property Name

Get-Service | Out-File -FilePath "./services.txt"

Get-Content "./services.txt"

Get-Service | ConvertTo-Html -Property Name, Status | Out-File "./services.html"

# This line stop all services in the computer if you remove -WhatIf! CAUTION!!!
Get-Service | Stop-Service -WhatIf # -WhatIf show what will be executed but don't execute it.

# Confirm ask for the confirmation before execute
Get-Service | Stop-Service -Confirm