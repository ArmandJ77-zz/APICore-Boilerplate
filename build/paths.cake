public static class Paths{
    public static FilePath SolutionFile => "API.sln";
    public static FilePath ProjectFile => "API/API.csproj";
    public static FilePath BinFile => "API/bin";
    public static FilePath ObjFile => "API/obj";
    public static FilePath UnitTestProjectFile => "Unit.Tests/Unit.Tests.csproj";
    public static FilePath IntegrationTestProjectFile => "Integration.Tests/Integration.Tests.csproj";
}

public static FilePath Combine(DirectoryPath directory, FilePath file)
{
    return directory.CombineWithFilePath(file);
}