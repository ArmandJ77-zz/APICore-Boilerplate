///////////////////////////////////////////////////////////////////////////////
// Import Additional Custom Cake Classes
///////////////////////////////////////////////////////////////////////////////
#load build/paths.cake

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Publish");
var configuration = Argument("configuration", "Release");

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(ctx =>
{
   // Executed BEFORE the first task.
   Information("Running tasks...");
});

Teardown(ctx =>
{
   // Executed AFTER the last task.
   Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(Paths.BinFile.FullPath);
    CleanDirectory(Paths.ObjFile.FullPath);
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreBuild(Paths.ProjectFile.FullPath);
});

Task("Test-Unit")
    .IsDependentOn("Build")
    .Does(() =>
{
    DotNetCoreTest(Paths.UnitTestProjectFile.FullPath);
});

Task("Test-Integration")
    .IsDependentOn("Test-Unit")
    .Does(() =>
{
    DotNetCoreTest(Paths.IntegrationTestProjectFile.FullPath);
});

Task("Publish")
    .IsDependentOn("Test-Integration")
    .Does(() =>
{
    DotNetCorePublish(Paths.ProjectFile.FullPath,
        new DotNetCorePublishSettings{
            Configuration = configuration
        });
});

RunTarget(target);