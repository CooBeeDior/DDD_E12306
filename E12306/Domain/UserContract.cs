using E12306.Common;
using E12306.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.Domain
{
    public class UserContract : EntityBase
    {
        //public UserContract()
        //{
        //}
        public UserContract(string Name, string IdCard, ContractUserType UserType = ContractUserType.Adult)
        {
            Id = Guid.NewGuid();
            this.Name = Name;
            this.IdCard = IdCard;
            this.UserType = UserType;

            Version = 0;
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }
        public string Name { get; private set; }
        public string IdCard { get; private set; }

        public ContractUserType UserType { get; set; }


        public override bool Equals(object obj)
        {
            var other = obj as UserContract;
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            var a = Name.GetHashCode();
            var b = IdCard.GetHashCode();
            return a ^ b;
        }


        public static bool operator ==(UserContract left, UserContract right)
        {
            return left?.Id == right?.Id;
        }
        public static bool operator !=(UserContract left, UserContract right)
        {
            return left?.Id != right?.Id;
        }


    }
}
