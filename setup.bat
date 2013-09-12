@echo off
set /p name="Enter your application name: " %=%

fart -r *.cs,*.xaml,*.xml,*.csproj "Bootstrap" %name%
fart -f *.* "Bootstrap" %name%
fart -r *.csproj,*.user,*.sln "Bootstrap" %name%