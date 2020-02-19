[CmdletBinding()]
 Param(
	[string]$file,
    [string]$browser
 )  

 Write-Output $file

##############################################################################
$From = "subbarao.thotakura@aeriestechnology.com"
$To = @("subbarao.thotakura@aeriestechnology.com", "subrahmanyeswara.p@aeriestechnology.com", "Shilpa.Jain@aeriestechnology.com", "arun.mamidi@aeriestechnology.com")
$Cc = "subbarao.thotakura@epiqsystems.com"
#$Cc = "fdipace@belatrixsf.com"
$Attachment = $file
$Subject = "Automation Regression Report on Unity Dev Environment - $browser"
$Body = "Execution Report for ReactJS converted features on unity-tnetqa.eipqsystems.com has been completed. Please find the attached report for feature wise results."
$SMTPServer = "smtp.office365.com"
$SMTPPort = "587"
Write-Output $SMTPPort
Send-MailMessage -From $From -to $To -Cc $Cc -Subject $Subject `
-Body $Body -SmtpServer $SMTPServer -port $SMTPPort -UseSsl `
-Credential (New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList "subbarao.thotakura@aeriestechnology.com",("Password1!" | ConvertTo-SecureString -AsPlainText -Force)
) -Attachments $Attachment
##############################################################################