<#
.SYNOPSIS
  Runs the TRX update script
.DESCRIPTION
  Wrapper for running the TRX mapping script.
  It adds error handling for calling the Mapping.ps1 script
.PARAMETER trxDir
  The folder that contains the TRX file or files
.NOTES
  Version:        1.0
  Author:         Troy Walsh
  Creation Date:  03/03/2017
  Purpose/Change: Initial script development
  
.EXAMPLE
  ./RunMapping

  This will executing the mapping of the TRX file tests to VSTS
  #>

param([string]$trxDir)

$path = $PSScriptRoot + '\Mapping.ps1'

ForEach ($file in Get-ChildItem $trxDir -Filter *.trx -Recurse) 
{
	try
	{
		Write-Host -ForegroundColor Green "Found: " $file.FullName

		$fullPath = $file.FullName
		$argumentList = @()
		$argumentList += ("-trxFile", "'$fullPath'")

		$tests = Invoke-Expression "& `"$path`"$argumentList"
	
		Write-Host -ForegroundColor Green "Ran: " $file.fullName
	}
	catch
	{
		Write-Host -ForegroundColor Yellow "Did not run: " $file.fullName
		Write-Host -ForegroundColor Red $_.Exception|format-list -force
		Write-Host -ForegroundColor Red $_.ScriptStackTrace
	}
}