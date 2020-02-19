[CmdletBinding()]
 Param(
	[string]$file,
    [string]$browser
 )  

 Write-Output $file

##############################################################################
$From = "unity.epiq@gmail.com"
#$To = @("fdipace@belatrixsf.com", "cbaquero@belatrixsf.com")
$To = @("twalton@epiqsystems.com","pgimelli@belatrixsf.com", "aalmada@belatrixsf.com", "cbaquero@belatrixsf.com", "fdipace@belatrixsf.com", "kpereda@belatrixsf.com", "mgomez@belatrixsf.com", "ftong@belatrixsf.com", "jolivares@belatrixsf.com", "lbendezu@belatrixsf.com","rrojas@belatrixsf.com","dvidacak@epiqsystems.com")
$Cc = "hdelnegro@belatrixsf.com"
#$Cc = "fdipace@belatrixsf.com"
$Attachment = $file
$Subject = "RC Unity Automation Report - $browser"
$Body = "RC Environemnt - A new automation test finished. Please find the report attached."
$SMTPServer = "smtp.gmail.com"
$SMTPPort = "587"
Send-MailMessage -From $From -to $To -Cc $Cc -Subject $Subject `
-Body $Body -SmtpServer $SMTPServer -port $SMTPPort -UseSsl `
-Credential (New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList "unity.epiq@gmail.com",("Unity2016" | ConvertTo-SecureString -AsPlainText -Force)
) -Attachments $Attachment
##############################################################################