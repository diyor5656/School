using Microsoft.AspNetCore.Identity;
using School.Core.Enums;

namespace School.DataAccess.Identity;

public class ApplicationUser : IdentityUser
{
    
    
        public Guid Id { get; set; }          // Foydalanuvchi ID'si
        public string UserName { get; set; }  // Foydalanuvchi nomi
        public string PasswordHash { get; set; } // Parol xesh
        public string Role { get; set; }      // Foydalanuvchi roli (masalan, "Admin", "User")
    

}
