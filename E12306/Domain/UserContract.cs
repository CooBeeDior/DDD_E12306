using E12306.Common;
using E12306.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{
    /// <summary>
    /// 实体
    /// </summary>
    [Table("UserContract")]
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


            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }
        [Required]
        [MaxLength(50)]
        public string Name { get; private set; }
        [Required]
        [MaxLength(50)]
        public string IdCard { get; private set; }

        [Required]
        public ContractUserType UserType { get; set; }





    }
}
