using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Ginch
{
    class Program
    {
        // static int Main(string[] args)
        // {
        //     // Create a root command with some options
        //     var rootCommand = new RootCommand
        //     {
        //         new Argument<string>("name", "Your name."),

        //         new Option<int>(
        //             "--int-option",
        //             getDefaultValue: () => 42,
        //             description: "An option whose argument is parsed as an int"),

        //         new Option<bool>(
        //             "--bool-option",
        //             "An option whose argument is parsed as a bool"),

        //         new Option<FileInfo>(
        //             "--file-option",
        //             "An option whose argument is parsed as a FileInfo")
        //     };

        //     rootCommand.Description = "My sample app";

        //     // Note that the parameters of the handler method are matched according to the names of the options
        //     rootCommand.Handler = 
        //         CommandHandler.Create<string, int, bool, FileInfo>(
        //         (name, intOption, boolOption, fileOption) =>
        //     {
        //         Console.WriteLine($"The value for Argument is: {name}");
        //         Console.WriteLine($"The value for --int-option is: {intOption}");
        //         Console.WriteLine($"The value for --bool-option is: {boolOption}");
        //         Console.WriteLine($"The value for --file-option is: {fileOption?.FullName ?? "null"}");
        //     });

        //     // Parse the incoming args and invoke the handler
        //     return rootCommand.InvokeAsync(args).Result;
        // }

        public static async Task<int> Main(string[] args)
        {
            var greeting = new Command("greeting", "Say hi.")
            {
                new Argument<string>("name", "Your name."),
                new Option<string?>(new[] { "--greeting", "-g" }, "The greeting to use."),
                new Option<bool>(new[] { "--verbose", "-v" }, "Show the deets."),
            };
            greeting.Handler = 
                CommandHandler.Create<string, string?, bool, IConsole>(HandleGreeting);

            var times = new Command("times", "Repeat a number of times.")
            {
                new Argument<string>("words", "The thing you are saying."),
                new Option<int>(new[] { "--count", "-c" }, description: "The number of times to copy you.",
                    getDefaultValue: () => 1),
                new Option<int>(new[] { "--delay", "-d" }, description: "The delay between each echo.",
                    getDefaultValue: () => 100),
                new Option<bool>(new[] { "--verbose", "-v" }, "Show the deets."),
            };
            times.Handler = 
                CommandHandler.Create<string, int, int, bool, IConsole, CancellationToken>(HandleEchoTimesAsync);

            var forever = new Command("forever", "Just keep repeating.")
            {
                new Argument<string>("words", "The thing you are saying."),
                new Option<int>(new[] { "--delay", "-d" }, description: "The delay between each echo.",
                    getDefaultValue: () => 100),
                new Option(new[] { "--verbose", "-v" }, "Show the deets."),
            };
            forever.Handler = 
                CommandHandler.Create<string, int, bool, IConsole, CancellationToken>(HandleEchoForeverAsync);

            var cmd = new RootCommand
            {
                greeting,
                new Command("echo", "Stop copying me!")
                {
                    times, 
                    forever,
                },
            };

            return await cmd.InvokeAsync(args);
        }

        private static void HandleGreeting(
            string name,
            string? greeting,
            bool verbose,
            IConsole console)
        {

        }

        static async Task<int> HandleEchoTimesAsync(
            string words,
            int count,
            int delay,
            bool verbose,
            IConsole console,
            CancellationToken cancellationToken)
        {
            return default;
        }

        static async Task<int> HandleEchoForeverAsync(
            string words,
            int delay,
            bool verbose,
            IConsole console,
            CancellationToken cancellationToken)
        {
             return default;
        }
    }
}
