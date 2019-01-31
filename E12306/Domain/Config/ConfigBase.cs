using E12306.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{

    public class ConfigBase : EntityBase
    {
        protected ConfigBase()
        {

        }
        public ConfigBase(string Code, string Name) : base()
        {
            this.Code = Code;
            this.Name = Name;
        }
        [Required]
        [MaxLength(50)]
        public virtual string Code { get; protected set; }
        [Required]
        [MaxLength(50)]
        public virtual string Name { get; protected set; }


        public override bool Equals(object obj)
        {
            var other = obj as ConfigBase;
            return this.Code == other.Code && this.Name == other.Name;
        }

        public override int GetHashCode()
        {
            var a = Code.GetHashCode();
            var b = Name.GetHashCode();
            return a ^ b;
        }


        public static bool operator ==(ConfigBase left, ConfigBase right)
        {
            return isEqual(left, right);
        }
        public static bool operator !=(ConfigBase left, ConfigBase right)
        {
            return !isEqual(left, right);
        }

        private static bool isEqual(ConfigBase left, ConfigBase right)
        {
            var a = ReferenceEquals(left, null);
            var b = ReferenceEquals(right, null);
            if (a ^ b)
            {
                return false;
            }
            var c = ReferenceEquals(left, null);
            var d = left.Equals(right);
            return c || d;
        }

        public override string ToString()
        {
            return $"名称：{Name} ,编码：{Code}";
        }
    }
}
