[CmdletBinding()]
 Param(
	[string]$browser,
    [string]$path
 )

$appConfig = $path
$xmlDocument = (Get-Content $appConfig) -as [Xml]

$driverPort = $xmlDocument.configuration.appSettings.add | where { $_.Key -eq "DriverPort" }
$driverPath = $xmlDocument.configuration.appSettings.add | where { $_.Key -eq "DriverPath" }
$browserKey = $xmlDocument.configuration.appSettings.add | where { $_.Key -eq "Browser" }
$url = $xmlDocument.configuration.appSettings.add | where { $_.Key -eq "PortalURL" }
$dbConnection = $xmlDocument.configuration.appSettings.add | where { $_.Key -eq "DBConnectionString" }



if($browser -eq "chrome"){
	$driverPort.value = "64666"
	$driverPath.value = "C:\E2ETests\Tools"
	$browserKey.value = "Chrome"

    Write-Output $browserKey.value
}

if($browser -eq "ie"){
	$driverPort.value = "64667"
	$driverPath.value = "C:\E2ETests\Tools-RC"
	$browserKey.value = "IE"
}

if($browser -eq "firefox"){
 Write-Output "asdasdasd"
	$driverPort.value = "64668"
	$driverPath.value = "C:\E2ETests\Tools-RC"
	$browserKey.value = "Firefox"
}

#RC parameters
$url.value = "http://tcms-anywhere-rc.clouddev.epiqcorp.com/login"
$dbConnection.value="Data Source=ebtssql1\ets_qa;Initial Catalog=TCMS21_RC;Integrated Security=True; trusted_connection=true"

#QA parameters
#$url.value = "http://tcms-anywhere-qa/login"
#$dbConnection.value="Data Source=ebtssql1\ets_qa;Initial Catalog=TCMS21;Integrated Security=True; trusted_connection=true"

$xmlDocument.save($appConfig);