using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WormsWorld.Mover;
using WormsWorld.FileWriter;
using WormsWorld.FoodGenerator;
using WormsWorld.NameGenerator;
using WormsWorld.WorldSimulator;

namespace WormsWorld
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddHostedService<WorldService>();
                    services.AddSingleton<IFoodGenerator, FoodGenerator.FoodGenerator>();
                    services.AddSingleton<IFileWriter>(_ => new FileWriter.FileWriter("AboutWorms.txt"));
                    services.AddSingleton<INameGenerator, NameGenerator.NameGenerator>();
                    services.AddSingleton<IWormMover, WormMover>();
                });
        }
    }
}