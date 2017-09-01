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
    var settingsStd = new DotNetCoreBuildSettings {
        Configuration = "Release",
        Framework = "netstandard1.3"
    };
    var settingsCore = new DotNetCoreBuildSettings {
        Configuration = "Release",
        Framework = "netcoreapp1.1"
    };
    DotNetCoreBuild(src + "/commercetools.NETStandard", settingsStd);
    DotNetCoreBuild(src + "/commercetools.Test", settingsCore);
});


Task("Default")
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .IsDependentOn("Build");

RunTarget(Argument("target", "Default"));