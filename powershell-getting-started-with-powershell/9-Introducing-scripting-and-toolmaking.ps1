function Get-MyProccess {
  Param(
    [string]$ProcessName = "*"
  )

  Get-Process | Where-Object { $_.ProcessName -like $ProcessName }
  
}

$env:PSModulePath -split ":"
