using System;
using McMaster.Extensions.CommandLineUtils;

namespace test_tool
{
    class Program
    {
        public static int Main(string[] args)
        {
            var app = new CommandLineApplication();
            app.Name = "test-tool";
            app.HelpOption("-?|-h|--help");
            
            
            app.Command("generate", (command) =>
            {
                command.Description = "Magically write code for me.";
                command.HelpOption("-?|-h|--help");

                var buildOption =
                    command.Option("-b|--build", "Build after generating code.", CommandOptionType.NoValue);

                var languageOption = command.Option("-l|--lang", "Output language", CommandOptionType.MultipleValue);

                var langArgument = command.Argument("[project-name]",
                    "The name of the output project.");
                command.OnExecute(() =>
                {
                    var language = langArgument.Value ?? "c#";
                        
                    Console.WriteLine($"Your code has been generated in {language}! ");
                    if (languageOption.HasValue())
                    {
                        foreach (var languageOptionValue in languageOption.Values)
                        {
                            Console.WriteLine($"Code generated for {languageOptionValue}");
                        }
                    }

                    if (buildOption.HasValue())
                    {
                        Console.WriteLine("Build succeeded!");
                    }
                    return 0;
                });
            });
            
            
            app.OnExecute(() => {
                Console.WriteLine("MyBucks CLI");
                app.HelpTextGenerator.Generate(app, Console.Out);
                return 0;
            });

            var returnCode = 1;

            try
            {
                returnCode = app.Execute(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }

            return returnCode;
        }
    }
}
