SET NUnitFolderPath=C:\Projects\dotNet\testNunit3SpecflowPickles\packages\NUnit.Console.3.0.0\tools
SET NUnitPath=%NUnitFolderPath%\nunit3-console.exe
SET PickesPath=C:\Projects\dotNet\testNunit3SpecflowPickles\packages\Pickles.CommandLine.2.11.1\tools\pickles.exe
SET ProjectPath=C:\Projects\dotNet\testNunit3SpecflowPickles\testNunit3SpecflowPickles
SET LibraryPath=%ProjectPath%\bin\Debug\testNunit3SpecflowPickles.dll
SET TestResultPath=%NUnitFolderPath%\TestResult.xml
SET ReportFolder=D:\1111

C:
cd %NUnitFolderPath%
del %ProjectPath%\index.html
del %ProjectPath%\img /s /f /q
%NUnitPath% %LibraryPath%
cd %ProjectPath%
%PickesPath% -trfmt=nunit3 -lr %TestResultPath%

copy %ProjectPath%\index.html %ReportFolder%\*.*
xcopy %ProjectPath%\img\*.* %ReportFolder%\img /s /y /i
xcopy %ProjectPath%\css\*.* %ReportFolder%\css /s /y /i
xcopy %ProjectPath%\js\*.* %ReportFolder%\js /s /y /i
xcopy %ProjectPath%\Features\*.ht* %ReportFolder%\Features /s /y /i
explorer %ReportFolder%\index.html