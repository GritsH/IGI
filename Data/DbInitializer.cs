using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WEB_953505_Grits.Entities;

namespace WEB_953505_Grits.Data
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                await roleManager.CreateAsync(roleAdmin);
            }
            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user@gmail.com",
                    UserName = "user@gmail.com"
                };
                await userManager.CreateAsync(user, "AA1111!");

                var admin = new ApplicationUser
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com"
                };
                await userManager.CreateAsync(admin, "4444AA!");
                admin = await userManager.FindByEmailAsync("admin@gmail.com");
                await userManager.AddToRoleAsync(admin, "admin");
            }
            if (!context.BouquetGroups.Any())
            {
                context.BouquetGroups.AddRange(
                new List<BouquetGroup>
                {
                    new BouquetGroup {GroupName="Weddings"},
                    new BouquetGroup {GroupName="Birthdays"},
                    new BouquetGroup {GroupName="For family and friends"},
                    new BouquetGroup {GroupName="Valentain's day"}
                });
                await context.SaveChangesAsync();
            }

            if (!context.Bouquets.Any())
            {
                context.Bouquets.AddRange(
                new List<Bouquet>
                {
                    new Bouquet { BouquetName = "Janet",
                    Description = "Вelicate aroma and calm composition", Image="buket1.jpg",
                    BouquetGroupId = 1},

                    new Bouquet { BouquetName = "Lilian",
                    Description = "Colorful bouquet with lilies", Image = "buket6.jpg",
                    BouquetGroupId = 2},

                    new Bouquet {BouquetName = "Vivien",
                    Description="Simple bouquet in pastel colors", Image="buket3.jpg", BouquetGroupId = 3},

                    new Bouquet{ BouquetName="Aurelia",
                    Description = "Perfect bouquet to express your love", Image = "buket5.jpg", BouquetGroupId=4 },

                    new Bouquet{ BouquetName="Prez",
                    Description="Modest but significant", Image="buket4.jpg", BouquetGroupId = 4},

                    new Bouquet{ BouquetName="Maria",
                    Description = "Delicate peonies and sweetish aroma", Image="buket2.jpg", BouquetGroupId=3},

                    new Bouquet{ BouquetName="Donna",
                    Description="Little bouquet for big event", Image="buket7.jpg", BouquetGroupId=1},

                    new Bouquet{ BouquetName="Jacklin",
                    Description="Strict and simple", Image="buket8.jpg", BouquetGroupId = 2},

                    new Bouquet{ BouquetName = "Violet",
                    Description="Pastel colors and charming composition", Image="buket9.jpg", BouquetGroupId=1},

                    new Bouquet{ BouquetName="Miranda",
                    Description="Suitable for birthdays", Image = "buket11.jpg", BouquetGroupId=2},

                    new Bouquet{ BouquetName="Samantha",
                    Description = "Soozing aroma and colors", Image="buket12.jpg", BouquetGroupId=3},

                    new Bouquet{ BouquetName="Singyang",
                    Description = "Fiery bouquet for your significant other", Image="buket13.jpg", BouquetGroupId = 4}

                    });
                await context.SaveChangesAsync();
            }
        }
    }
}
