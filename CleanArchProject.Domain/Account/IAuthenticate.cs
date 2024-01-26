using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchProject.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string passowrd);
        Task<bool> RegisterUser(string email, string passowrd);
        Task LogOut();
    }
}
