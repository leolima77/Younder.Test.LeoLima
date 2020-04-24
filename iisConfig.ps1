$ErrorActionPreference = "Stop"



Import-Module WebAdministration



$name = "api.komercialize"

$path = "$PSScriptRoot\LojaVirtual.Gerenciador.MVC"



">> Website name: $name"

">> path $path"



if (-not(Test-Path "IIS:\AppPools\$name"))

{

	">> Create WebAppPool"

	New-WebAppPool -name $name -force

}



if (-not(Test-Path "IIS:\Sites\$name"))

{

	">> Create WebSite"

	new-WebSite -name $name -PhysicalPath $path -HostHeader $name -ApplicationPool $name -force

	

	">> Add https bind"

	New-WebBinding -Name $name -Protocol "https" -Port 443 -HostHeader $name

	

	">> Start Website"

	Start-WebSite -Name $name

}

else

{

	">> Set WebSite path: $path"

	Set-ItemProperty "IIS:\Sites\$name" -name physicalPath -value $path

}





$name = "loja.komercialize"

$path = "$PSScriptRoot\LojaVirtual.MVC"



">> Website name: $name"

">> path $path"



if (-not(Test-Path "IIS:\AppPools\$name"))

{

	">> Create WebAppPool"

	New-WebAppPool -name $name -force

}



if (-not(Test-Path "IIS:\Sites\$name"))

{

	">> Create WebSite"

	new-WebSite -name $name -PhysicalPath $path -HostHeader $name -ApplicationPool $name -force

	

	">> Add https bind"

	New-WebBinding -Name $name -Protocol "https" -Port 443 -HostHeader $name

	

	">> Start Website"

	Start-WebSite -Name $name

}

else

{

	">> Set WebSite path: $path"

	Set-ItemProperty "IIS:\Sites\$name" -name physicalPath -value $path

}

$wsh = New-Object -ComObject Wscript.Shell

$wsh.Popup("IIS configurado com sucesso! Altere o arquivo hosts em C: > Windows > System32 > Drivers > etc, adicione as entradas disponiveis em hosts.txt na pasta raiz")


