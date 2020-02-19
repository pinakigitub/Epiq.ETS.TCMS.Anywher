$TimeStamp = Get-Date -Format o | foreach {$_ -replace ":", "."}
$DirectoryFrom = "C:\E2ETests\Unity-RC-OUT\*"
$DirectoryTo = "C:\E2ETests\Unity-RC-OUT-ARCHIVE\$TimeStamp"

New-Item -ItemType Directory -Force $DirectoryTo

Copy-Item $DirectoryFrom -Destination $DirectoryTo