using CSharpClickerWeb.Domain;
using CSharpClickerWeb.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CSharpClickerWeb.Initializers
{
    public static class DbContextInitializer
    {
        public static void AddAppDbContext(IServiceCollection services)
        {
            var pathToDbFile = GetPathToDbFile();
            services
                .AddDbContext<AppDbContext>(options => options
                    .UseSqlite($"Data Source={pathToDbFile}"));

            string GetPathToDbFile()
            {
                var applicationFolder = Path.Combine(Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData), "CSharpClicker");

                if (!Directory.Exists(applicationFolder))
                {
                    Directory.CreateDirectory(applicationFolder);
                }

                return Path.Combine(applicationFolder, "CSharpClicker.db");
            }
        }

        public static void InitializeDbContext(AppDbContext appDbContext)
        {
            const string Boost1 = "Цири";
            const string Boost2 = "Геральт";
            const string Boost3 = "Весемир";
            const string Boost4 = "Трисс";
            const string Boost5 = "Йеннифэр";

            appDbContext.Database.Migrate();

            var existingBoosts = appDbContext.Boosts
                .ToArray();

            AddBoostIfNotExist(Boost1, price: 100, profit: 1);
            AddBoostIfNotExist(Boost2, price: 100, profit: 15);
            AddBoostIfNotExist(Boost3, price: 100, profit: 60, isAuto: true);
            AddBoostIfNotExist(Boost4, price: 100, profit: 400);
            AddBoostIfNotExist(Boost5, price: 100, profit: 5000, isAuto: true);

            appDbContext.SaveChanges();

            void AddBoostIfNotExist(string name, long price, long profit, bool isAuto = false)
            {
                if (!existingBoosts.Any(eb => eb.Title == name))
                {
                    var pathToImage = Path.Combine(".", "Resources", "BoostImages", $"{name}.png");
                    using var fileStream = File.OpenRead(pathToImage);
                    using var memoryStream = new MemoryStream();

                    fileStream.CopyTo(memoryStream);

                    appDbContext.Boosts.Add(new Boost
                    (name, price, profit, memoryStream.ToArray(), isAuto)); 
                }
            }
        }
    }
}
