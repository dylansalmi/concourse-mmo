<#
.SYNOPSIS
  Makes updates to the MAQS config.
.DESCRIPTION
  Makes updates to the MAQS project config.
.NOTES
  Version:        1.0
  Author:         Troy Walsh
  Creation Date:  03/03/2017
  Purpose/Change: Initial script development. 
  
.EXAMPLE
  ./Config

  This will make config updates locally.
#>

$myArray = New-Object System.Collections.ArrayList

foreach ($arg in $args)
{
  $myArray.Add($arg)
}

$webConfig = $PSScriptRoot + '\App.config'
$doc = (Get-Content $webConfig) -as [Xml]

for($i=0;  $i -lt $myArray.Count; $i += 2)
{
    $obj = $doc.configuration.MagenicMaqs.add | where {$_.Key -eq $myArray[$i]}
    	if($obj)
	{
    $obj.value = $myArray[$i+1]
	}
}

for($i=0;  $i -lt $myArray.Count; $i += 2)
{
    $obj = $doc.configuration.RemoteSeleniumCapsMaqs.add | where {$_.Key -eq $myArray[$i]}
	if($obj)
	{
    $obj.value = $myArray[$i+1]
	}
}

$doc.Save($webConfig)