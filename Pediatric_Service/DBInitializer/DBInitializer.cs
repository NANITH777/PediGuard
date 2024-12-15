using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pediatric_Service.Helper;
using Pediatric_Service.Models;

namespace Pediatric_Service.DBInitializer
{
    public class DBInitializer : IDBInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DBInitializer(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public void Initialize()
        {
            // Migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }


            // Create roles if they are not applied
            if (!_roleManager.RoleExistsAsync(SD.Role_Assistant).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Assistant)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Doctor)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();


                // if roles are not created, then we will create Admin user as well
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "nanith@sakarya.edu.tr",
                    Email = "nanith@sakarya.edu.tr",
                    FullName = "Nanith",
                    PhoneNumber = "05346060000",
                    StressAdress = "Serdivan",
                    Gender = "Male",
                }, "Admin@7755").GetAwaiter().GetResult();
                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault
                    (u => u.Email == "nanith@sakarya.edu.tr");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
            }
            return;

        }

    }
}
