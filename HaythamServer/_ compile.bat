REM set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v3.5
set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
call %msBuildDir%\msbuild.exe  Haytham_Server\Haytham.sln /t:Clean,Build /p:Configuration=Release /p:Platform="Any CPU" /l:FileLogger,Microsoft.Build.Engine;logfile=Manual_MSBuild_ReleaseVersion_LOG.log
set msBuildDir=

pause