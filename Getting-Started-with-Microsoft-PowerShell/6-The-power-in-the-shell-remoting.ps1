# Powershell vs Bash
# Objects vs Text

# Powershell universal code execution model

# Overview of remoting

# PS uses the Windows Remote Management (WinRM)

Enable-PSRemoting

# History about bill gates letter about security and I love you Vb script issues

Enter-PSSession -ComputerName "DC"

HOSTNAME

ipconfig

# PS remoting  serialize/desialize objects

#
Invoke-Command -ComputerName A, B { Get-Service -Name BITS }

# WindowsPowershellWebAccess
# get-help *pswa*

# Powershell in the browser
# powershell web access

icm dc, s1, s2 { Get-Volume } | sort SizeRemaining | select -Last 3

