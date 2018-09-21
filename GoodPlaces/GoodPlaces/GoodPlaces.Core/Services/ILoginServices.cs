using System;
using System.Threading.Tasks;

namespace GoodPlaces.Core.Services
{
    public interface ILoginServices
    {
        Task<bool> login(string Email, string Pwd);
    }
}
