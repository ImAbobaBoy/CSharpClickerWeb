using CSharpClickerWeb.Domain;
using CSharpClickerWeb.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc.Diagnostics;
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

            AddBoostIfNotExist(Boost1, price: StandartBoosts.StandartBoostProperties[Boost1].Price, 
                profit: StandartBoosts.StandartBoostProperties[Boost1].Profit);
            AddBoostIfNotExist(Boost2, price: StandartBoosts.StandartBoostProperties[Boost2].Price,
                profit: StandartBoosts.StandartBoostProperties[Boost2].Profit);
            AddBoostIfNotExist(Boost3, price: StandartBoosts.StandartBoostProperties[Boost3].Price,
                profit: StandartBoosts.StandartBoostProperties[Boost3].Profit);
            AddBoostIfNotExist(Boost4, price: StandartBoosts.StandartBoostProperties[Boost4].Price,
                profit: StandartBoosts.StandartBoostProperties[Boost4].Profit);
            AddBoostIfNotExist(Boost5, price: StandartBoosts.StandartBoostProperties[Boost5].Price,
                profit: StandartBoosts.StandartBoostProperties[Boost5].Profit);


            //AddRandomUsers();

            appDbContext.SaveChanges();

            void AddRandomUsers()
            {

                List<string> UserNames =
                [
                    "GerwantFromFishia",
                    "Balabol",
                    "FanatSamoletov",
                    "Lutik",
                    "ClownFish",
                    "BroSKosichkami",
                    "Plotwa",
                    "Bobr",
                    "DrugNebes",
                    "BillGates",
                    "ElonMax"
                ];

                List<long> Scores =
                [
                    123423,
                    987589347,
                    20394,
                    9783467285967,
                    82394,
                    19283,
                    8493,
                    9238,
                    23,
                    34534,
                    2304775
                ];

                for (var i = 0; i < UserNames.Count; i++)
                {
                    appDbContext.Users.Add(new ApplicationUser
                    {
                        UserName = UserNames[i],
                        RecordScore = Scores[i],
                    });
                }
            }

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
