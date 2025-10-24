run:
	sudo dotnet restore
	sudo dotnet clean
	sudo dotnet publish -c Release -r linux-x64
	sudo dotnet publish -c Release -r linux-x64
	sudo dotnet ${PWD}/bin/Release/net6.0/linux-x64/testNetLinux.dll

clear:
	sudo dotnet restore
	sudo dotnet clean