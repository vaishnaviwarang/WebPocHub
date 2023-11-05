using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPOCHub.Models;

namespace WebPOCHub.DataAccessLayer
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DbContextClass _context;
        public AuthenticationRepository(DbContextClass context)
        {
            _context = context;
        }
        public User? CheckCredentials(User model)
        {
           var userCredentials = _context.Users.SingleOrDefault(x => x.Email == model.Email);
           return userCredentials;
        }

        public string GetUserRole(int roleId)
        {
            return _context.Roles.SingleOrDefault(x => x.RoleId == roleId).RoleName;
        }

        public int RegisterUsers(User model)
        {
            _context.Users.Add(model);
            return _context.SaveChanges();
        }
    }
}
