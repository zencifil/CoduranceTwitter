using System;
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
                while(true) {
                    var line = Console.ReadLine();
                    if (line == "quit")
                        break;
                    var result = twitter.Execute(line);
                    Console.WriteLine(result);
                }
            }
        }

        private static IServiceProvider GetServiceProvider() {
            var services = new ServiceCollection();
            services.AddTransient<Twitter>();
            services.AddTransient<Receiver>();
            //services.AddTransient(typeof(IEntity), typeof(User));
            //services.AddTransient(typeof(IEntity), typeof(Tweet));
            services.AddTransient(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(IRepository<User>), typeof(InMemoryRepo<User>));

            return services.BuildServiceProvider();
        }
    }
}
