
## Authenticate to Azure
$azrPwd = ConvertTo-SecureString $env:azure_pass -AsPlainText -Force
$azrCred = New-Object System.Management.Automation.PSCredential ($env:azure_appId, $azrPwd)

## Use a SPN for easy authentication
$connParams = @{
	ServicePrincipal = $true
	TenantId = $env:azure_tenantId
	Credential = $azrCred
	SubscriptionId = $env:azure_subscriptionid
}
$null = Add-AzureRmAccount @connParams

$artifactsFolder = 'C:\Dropbox\GitRepos\Session-Content\Live Talks\Pester MVA\Demos\Project 1 - PowerShell Project\Artifacts'
$employeesCsvPath = "$artifactsFolder\Employees.csv"

describe 'CSV file' {

	it 'the CSV file exists in the expected location' {
		Test-Path -Path $employeesCsvPath | should be $true
	}

	it 'the CSV file contains all the expected rows' {
		$csvContent = '"FirstName","LastName","Department","Title"
"Katie","Green","Accounting","Manager of Accounting"
"Joe","Blow", "Information Systems","System Administrator"
"Joe","Schmoe", "Information Systems", "Software Developer"
"Barack","Obama", "Executive Office", "CEO"
"Donald","Trump", "Janitorial Services", "Custodian"'

		$csvContent -eq (Get-Content -Path $employeesCsvPath -Raw) | should be $true
	}
}

describe 'Active Directory' {

	$csvEmployees = Import-Csv -Path $employeesCsvPath

	it 'the expected OUs exist' {

		$expectedOus = $csvEmployees | foreach { "OU=$($_.Department),DC=mylab,DC=local" } | Select -Unique
		
		$actualOus = Get-ADOrganizationalUnit -Server DC -Filter * | Select-Object -ExpandProperty DistinguishedName
		@($actualOus | where { $_ -in $expectedOus }).Count | should be @($expectedOus).Count

	}

	it 'the expected groups exist' {

		$expectedGroups = $csvEmployees | foreach { $_.Department } | Select -Unique
		
		$actualGroups = Get-ADGroup -Server DC -Filter * | Select-Object -ExpandProperty Name
		@($actualGroups | where { $_ -in $expectedGroups }).Count | should be @($expectedGroups).Count

	}

	it 'users in the CSV file do not exist in AD' {
		
		foreach ($user in (Import-Csv -Path $employeesCsvPath)) {
			
			$firstInitial = $user.FirstName.SubString(0,1)
    		$userName = '{0}{1}' -f $firstInitial,$user.LastName
			
			Get-AdUser -Server DC -Filter "samAccountName -eq '$userName'" | should benullorEmpty
		}	
	}
}