var src = Directory("./src");
var dst = Directory("./artifacts");
var reports = dst + Directory("./reports");

Task("Clean").Does(() => {
    CleanDirectories(dst);
    CleanDirectories(src.Path + "/**/bin");
    CleanDirectories(src.Path + "/**/obj");
    CleanDirectories(src.Path + "/**/pkg");
    DotNetCoreClean(src);
});

Task("Restore").Does(() => {
    EnsureDirectoryExists(dst);
    DotNetCoreRestore(src);
});

Task("Build").Does(() => {
    var settings = new DotNetCoreBuildSettings {
        Configuration = "Release"
    };
    DotNetCoreBuild(src, settings);
});


Task("Default")
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .IsDependentOn("Build");

RunTarget(Argument("target", "Default"));