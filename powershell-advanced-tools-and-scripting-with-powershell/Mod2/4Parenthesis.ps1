# Parenthesis help!

#Create a txt and csv file
'DC','Client' | Out-file computers.txt
"ComputerName,IPAddress" | Out-file computers.csv
"DC,192.168.3.10" | Out-file computers.csv -Append
"Client,192.168.3.100" | Out-File computers.csv -Append

#Getting names from a txt file
Get-Service -ComputerName (Get-Content computers.txt)

# Getting Names from a CSV
# We need use the -ExpandProperty here to get the property as Array of String, if don't,  we get property as array of object
# (Import-csv computers.csv | Select -ExpandProperty ComputerName)
# DC
# Client

# (Import-csv computers.csv | Select ComputerName)
# ComputerName
# ------------
# DC
# Client

# Import-csv computers.csv | gm  # returns object
# Import-csv computers.csv | Select ComputerName | gm # returns object 
# Import-csv computers.csv | Select -ExpandProperty ComputerName | gm # returns string 
Get-Service -ComputerName (Import-csv computers.csv | Select -ExpandProperty ComputerName)

# In PS Version 3 we have this syntax that is the same than the -ExpandProperty, this is called . (dot) notation
Get-Service -ComputerName (Import-csv computers.csv).ComputerName

#Using Get-Adcomputer
Invoke-Command -ComputerName (
    Get-Adcomputer -filter "name -like '*c*'" | 
    Select -ExpandProperty Name) -ScriptBlock {Get-Service -name bits}