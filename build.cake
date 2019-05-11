//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("./artifacts");
var solutionFile = "./src/UniversalTypeConverter.sln";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreRestore(solutionFile);
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = configuration,
        NoRestore = true
    };
     
    DotNetCoreBuild(solutionFile, settings);
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    var settings = new DotNetCoreTestSettings
	{
        Configuration = configuration,
        NoBuild = true
    };
    
    DotNetCoreTest("./src/UniversalTypeConverter.Tests/", settings);
});

Task("Create-NuGet-Package")
    .IsDependentOn("Run-Unit-Tests")
    .Does(() => 
    {
        var settings = new DotNetCorePackSettings
        {
            Configuration = configuration,
            OutputDirectory = buildDir
        };

        DotNetCorePack("./src/UniversalTypeConverter/UniversalTypeConverter.csproj", settings);
    });

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Create-NuGet-Package");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
