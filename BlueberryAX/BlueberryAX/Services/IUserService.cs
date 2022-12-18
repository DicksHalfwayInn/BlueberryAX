using BlueberryAX.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueberryAX.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetValidUsersAsync();
    }
}
