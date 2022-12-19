using BlueberryAX.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueberryAX.Services
{
    public class DummyValidUsersService : IValidUsersService
    {
        public Task<List<UserModel>> GetValidUsersAsync() =>
            Task.FromResult(new List<UserModel>(new[]
            {
                new UserModel("Stuart Jones", "Stuey", "stu@gmail.com", "StueyPassword"),
                new UserModel("Paul Brees", "Pauly", "paul@gmail.com", "PaulyPassword"),
                new UserModel("Larry Hythe", "Larry", "larry@gmail.com", "LarryPassword")
            }));

    }
}
