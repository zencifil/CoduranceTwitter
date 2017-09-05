using System;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using CoduranceTwitter.Core;
using CoduranceTwitter.Core.Repository;
using CoduranceTwitter.Core.Models;
using CoduranceTwitter.Core.Services;

namespace CoduranceTwitter.UI {

    class Program {

        static void Main(string[] args) {
            Console.WriteLine("Welcome...");

            var provider = GetServiceProvider();

            using (var twitter = provider.GetService<Twitter>()) {
                while (true) {
                    Console.Write(">");
                    var line = Console.ReadLine();
                    if (line == "quit")
                        break;

                    try {
                        var result = twitter.Execute(line);
                        result.ToList().ForEach(r => Console.WriteLine(r));
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private static IServiceProvider GetServiceProvider() {
            var services = new ServiceCollection();
            services.AddTransient<Twitter>();
            services.AddTransient<Receiver>();
            services.AddTransient(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(IRepository<User>), typeof(InMemoryRepo<User>));

            return services.BuildServiceProvider();
        }
    }
}
