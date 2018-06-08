# dotnet-cli-example
An example of a dotnet cli tool

# Installation
If the tool is already installed, uninstall it first
`dotnet tool uninstall -g test-tool`

Create your local nuget package:

`dotnet pack --output ./`

Install the tool:

`dotnet tool install -g test-tool --add-source ./`

If you've never installed the tool, refresh your powershell environment variables by running the following command:

`$env:Path = [System.Environment]::GetEnvironmentVariable("Path","Machine") + ";" + [System.Environment]::GetEnvironmentVariable("Path","User")`

Run it!

`test-tool`

# Creating your own global tool

1. Get the global tool nuget template for dotnet new

Check for a newer version of the template first!

`dotnet new --install "McMaster.DotNet.GlobalTool.Templates::2.1.300-preview1"`

2. Create a project from the `dotnet new` command
`dotnet new global-tool --command-name test-tool`
Where test-tool is the name of your tool.


# More information
https://natemcmaster.com/blog/2018/05/12/dotnet-global-tools/
https://github.com/natemcmaster/dotnet-tools
https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools


