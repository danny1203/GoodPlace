using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodPlaces.Core.Services
{
    public class LoginMockServices : ILoginServices
    {
        Dictionary<string, string> urs = new Dictionary<string, string>{{ "user@user.com", "123" }, { "user1@user.com", "123" }, { "user2@user.com", "123" } };

        public Task<bool> login(string Email, string Pwd)
        {
            if(urs.ContainsKey(Email) && urs[Email] == Pwd) 
            {
                return Task.FromResult(true);
            } 
            else 
            {
                return Task.FromResult(false);
            }
        }
    }
}
