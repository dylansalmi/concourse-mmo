<#
.SYNOPSIS
  Uploads automation test results to VSTS
.DESCRIPTION
  Uploads automation test results to VSTS
.PARAMETER trxFolder
  The folder that contains the TRX file or files
.PARAMETER suiteIds
  A comma delimited list of suite ids
.PARAMETER configId
  The configuration id
.PARAMETER collection
  The collection string
.PARAMETER auth
  The auth token or string
.PARAMETER user
  The user id string
.NOTES
  Version:        1.0
  Author:         Troy Walsh
  Creation Date:  03/03/2017
  Purpose/Change: Initial script development. 
  
.EXAMPLE
  ./Upload

  This will upload automation test results to VSTS.
  #>

param([string]$trxFolder, [string]$suiteIds, [string]$configId, [string]$collection, [string]$project, [string]$auth,  [string]$user)

[string[]] $regKeys = "hklm:\HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\VisualStudio\14.0", 
"hklm:\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\VisualStudio\14.0", 
"hklm:\HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\VisualStudio\13.0",
"hklm:\HKEY_LOCAL_MACHINE\SOFTWARE\\Microsoft\VisualStudio\13.0", 
"hklm:\HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\VisualStudio\12.0",
"hklm:\HKEY_LOCAL_MACHINE\SOFTWARE\\Microsoft\VisualStudio\12.0", 
"hklm:\HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\VisualStudio\11.0",
"hklm:\HKEY_LOCAL_MACHINE\SOFTWARE\\Microsoft\VisualStudio\11.0"

$tcmPath

foreach ($key in $regKeys) 
{ 
    if ((Test-Path $key) -eq $True -AND (Get-ItemProperty $key).InstallDir -ne $null)
    {
        $tcmPath = (Get-ItemProperty $key).InstallDir
        $tcmPath = [io.path]::combine($tcmPath, "tcm.exe");

        break
    }
}

foreach ($file in Get-ChildItem $trxFolder -Filter *.trx -Recurse) 
{
    foreach ($suiteId in $suiteIds.split(",")) 
    {
        $newName = $file.FullName + ".trx"
        Write-Output $newName
        Write-Host $newName

        $doc = (Get-Content $file.FullName) -as [Xml]
        $doc.TestRun.id = [guid]::newguid().ToString().ToLower()
        $doc.Save($newName)
        
        $Parms= "run /publish /suiteid:{0} /configid:{1} /resultsfile:""{2}"" /collection:""{3}"" /teamproject:""{4}"" /login:{5} /allowalternatecredentials /resultowner:""{6}""" -f $suiteId,$configId,$newName,$collection,$project,$auth,$user
        $Prms = $Parms.Split(" ")
        & "$tcmPath" $Prms 

       Remove-Item "$newName" -Confirm:$false
    }
}