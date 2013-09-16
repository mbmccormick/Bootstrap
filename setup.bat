@echo off
set /p name="Enter your application name: " %=%

fart -r -a -i *.cs,*.xaml,*.xml,*.csproj "Bootstrap" %name%
fart -f *.* "Bootstrap" %name%
fart -r -a -i *.csproj,*.user,*.sln "Bootstrap" %name%

del LICENSE.txt
