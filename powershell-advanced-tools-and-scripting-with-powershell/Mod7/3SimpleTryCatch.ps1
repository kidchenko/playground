$Computer='notonline'
Try {
    # If you use try catch block you need to set -ErrorAction to Stop
    # Because if it is not stop, powershell will try continue and don't will call the catch
    $os = Get-Wmiobject -ComputerName $Computer -Class Win32_OperatingSystem -ErrorAction Stop -ErrorVariable CurrentError
             
}
Catch {
    Write-Warning "You done made a boo-boo with computer $Computer"            
}