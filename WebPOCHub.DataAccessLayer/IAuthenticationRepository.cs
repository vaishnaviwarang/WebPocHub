using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPOCHub.Models;

namespace WebPOCHub.DataAccessLayer
{
    public interface IAuthenticationRepository
    {
        int RegisterUsers(User model);
        User? CheckCredentials(User model);
        string GetUserRole(int roleId);
    }
}
