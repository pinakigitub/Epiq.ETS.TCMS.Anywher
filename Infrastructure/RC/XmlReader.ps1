[xml]$xmlIncludeDocument = (Get-Content "C:\E2ETests\Unity-RC\TAGS\FeatureTags.xml")
[string]$include = "";

foreach($row in $xmlIncludeDocument.Columns.Rows){
    
    if($row.ChildNodes.Count -ne 0){
        if($row.ChildNodes[0].'#text' -ne "Include" -and $row.ChildNodes[0].'#text' -ne "NA"){
            $include = $include + "+" + $row.ChildNodes[0].'#text';        
        }
    }

    if($row.ChildNodes.Count -eq 2){
        if($row.ChildNodes[1].'#text' -ne "Exclude"){
            $include = $include + "-" + $row.ChildNodes[1].'#text';            
        }
    }
}

$include = $include.Substring(1, $include.Length - 1);

Write-Host -ForegroundColor Green "Features To Include: ($include)"