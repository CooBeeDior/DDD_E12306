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
        protected UserContract()
        {
        } 

        public UserContract(CustomerInfo CustomerInfo, string Name, string IdCard, ContractUserType UserType = ContractUserType.Adult) : base()
        {
            this.Name = Name;
            this.IdCard = IdCard;
            this.UserType = UserType;

            this.CustomerInfo = CustomerInfo;
            CustomerInfo?.AddUserContract(this);

        }
        [Required]
        public virtual CustomerInfo CustomerInfo { get; private set; }

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
