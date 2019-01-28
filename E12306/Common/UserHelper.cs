using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.Common
{
    public static class UserHelper
    {
        public static User User => new User(Guid.NewGuid(), "testUser");
    }

    public class User
    {
        public User(Guid Id, string UserName)
        {
            this.Id = Id;
            this.UserName = UserName;

        }
        public Guid Id { get; set; }

        public string UserName { get; set; }
    }
}
