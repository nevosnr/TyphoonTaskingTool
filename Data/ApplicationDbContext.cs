using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TyphoonTaskingTool.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        //OnModelCreating below is used to seed initial data for roles and users.
        //IdentityRole defines each role within the application.
        //IdentityUser defines default users for the application. (Much like the Administrator or guest user in a Microsoft OS)
        //IdentityUserRole defines the relationship between users and roles.
        //The GUIDs were generated from https://guidgenerator.com/
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "d04e5b4c-10f0-4b2a-a25a-3fbe26f63566",
                    Name = "user",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "9e30e59b-edd6-4cf2-b8d1-c254f43549dd",
                    Name = "mscuser",
                    NormalizedName = "MSCUSER"
                },
                new IdentityRole
                {
                    Id = "bf704d5b-3971-4f86-b75e-07d625399087",
                    Name = "teamlead",
                    NormalizedName = "TEAMLEAD"
                },
                new IdentityRole
                {
                    Id = "392f7177-e777-4ffc-a57d-2ed84d16ae01",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "a478c1b6-20aa-48e9-9abf-7e7c3bfcbd3e",
                    Email = "admin@finalproject.co.uk",
                    NormalizedEmail = "ADMIN@FINALPROJECT.CO.UK",
                    NormalizedUserName = "ADMIN@FINALPROJECT.CO.UK",
                    UserName = "admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = "418cb504-2c5d-4e58-9059-e22de9594e74",
                    Email = "guestuser@finalproject.co.uk",
                    NormalizedEmail = "GUESTUSER@FINALPROJECT.CO.UK",
                    NormalizedUserName = "GUESTUSER@FINALPROJECT.CO.UK",
                    UserName = "guestuser",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                }
                //new ApplicationUser
                //{
                //    Id = "",
                //    Email = "ixtslead@finalproject.co.uk",
                //    NormalizedEmail = "IXTSLEAD@FINALPROJECT.CO.UK",
                //    NormalizedUserName = "IXTSLEAD@FINALPROJECT.CO.UK",
                //    UserName = "ixtslead",
                //    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                //    EmailConfirmed = true,
                //},
                //new ApplicationUser
                //{
                //    Id = "",
                //    Email = "wssrlead@finalproject.co.uk",
                //    NormalizedEmail = "WSSRLEAD@FINALPROJECT.CO.UK",
                //    NormalizedUserName = "WSSRLEAD@FINALPROJECT.CO.UK",
                //    UserName = "wssrlead",
                //    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                //    EmailConfirmed = true,
                //},
                //new ApplicationUser
                //{
                //    Id = "",
                //    Email = "ixtsuser@finalproject.co.uk",
                //    NormalizedEmail = "IXTSUSER@FINALPROJECT.CO.UK",
                //    NormalizedUserName = "IXTSUSER@FINALPROJECT.CO.UK",
                //    UserName = "ixtsuser",
                //    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                //    EmailConfirmed = true,
                //},
                //new ApplicationUser
                //{
                //    Id = "",
                //    Email = "wssrsuser@finalproject.co.uk",
                //    NormalizedEmail = "WSSRUSER@FINALPROJECT.CO.UK",
                //    NormalizedUserName = "WSSRUSER@FINALPROJECT.CO.UK",
                //    UserName = "wssrsuser",
                //    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                //    EmailConfirmed = true,
                //}
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "392f7177-e777-4ffc-a57d-2ed84d16ae01", // Administrator role
                    UserId = "a478c1b6-20aa-48e9-9abf-7e7c3bfcbd3e", // Admin user
                },
                //new IdentityUserRole<string>
                //{
                //    RoleId = "9e30e59b-edd6-4cf2-b8d1-c254f43549dd", // MSC User role
                //    UserId = "", // MSC user (IXTS)
                //},
                //new IdentityUserRole<string>
                //{
                //    RoleId = "bf704d5b-3971-4f86-b75e-07d625399087", // MSC Team Lead role
                //    UserId = "", // MSC Lead (IXTS)
                //},
                //new IdentityUserRole<string>
                //{
                //    RoleId = "9e30e59b-edd6-4cf2-b8d1-c254f43549dd", // MSC User role
                //    UserId = "", // MSC user (WSSR)
                //},
                //new IdentityUserRole<string>
                //{
                //    RoleId = "bf704d5b-3971-4f86-b75e-07d625399087", // MSC Team Lead role
                //    UserId = "", // MSC Lead (WSSR)
                //},
                new IdentityUserRole<string>
                {
                    RoleId = "d04e5b4c-10f0-4b2a-a25a-3fbe26f63566", // User role
                    UserId = "418cb504-2c5d-4e58-9059-e22de9594e74" // Guest user
                }
            );
        }
    }
}
