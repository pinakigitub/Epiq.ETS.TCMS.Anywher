$outputTxtPath = "C:\E2ETests\Unity-OUT\Output-IE.txt"
$outputXmlPath = "C:\E2ETests\Unity-OUT\Result-IE.xml"
$outputHtmlPath = "C:\E2ETests\Unity-OUT\E2EReport-IE.html"

$projectPath = "C:\E2ETests\Unity-DEV\EXEC\V1\IE\PROJ\Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.csproj"
$binPath = "C:\E2ETests\Unity-DEV\EXEC\V1\IE\BIN\Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.dll"
$specflowPath = "C:\E2ETests\Tools\SpecFlow\tools\specflow.exe"
$configPath = "C:\E2ETests\Unity-DEV\EXEC\V1\IE\BIN\Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.dll.config"
$featuresPath = "C:\E2ETests\Unity-DEV\TAGS\FeatureTags.xml"

#Get Features from Google Docs
[xml]$xmlIncludeDocument = (Get-Content $featuresPath)
[string]$include = "";

foreach($row in $xmlIncludeDocument.Columns.Rows){
    
    if($row.ChildNodes.Count -ne 0){
        if($row.ChildNodes[0].'#text' -ne "Include" -and $row.ChildNodes[0].'#text' -ne "NA"){
            $include = $include + "|" + $row.ChildNodes[0].'#text';        
        }
    }

    if($row.ChildNodes.Count -eq 2){
        if($row.ChildNodes[1].'#text' -ne "Exclude" -and $row.ChildNodes[1].'#text' -ne "NA"){
            $include = $include + "-" + $row.ChildNodes[1].'#text';            
        }
    }
}

$include = $include.Substring(1, $include.Length - 1);

Write-Host -ForegroundColor Green "Expression Feature: ($include)"

#Execution

& nunit-console.exe /labels /result=$outputXmlPath /output=$outputTxtPath $binPath /framework:net-4.5 /include:$include
& $specflowPath nunitexecutionreport $projectPath /xmlTestResult:$outputXmlPath /out:$outputHtmlPath
.\EmailSender.ps1 -file "C:\E2ETests\Unity-OUT\E2EReport-IE.html" -browser "IE"
.\Archiver.ps1