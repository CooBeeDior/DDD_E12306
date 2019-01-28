using E12306.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{
    /// <summary>
    /// 站台 （值对象）
    /// </summary>
    [Table("Station")]
    public class Station : EntityBase
    {
        //public Station()
        //{ }
        public Station(string Code, string Name)
        {
            this.Code = Code;
            this.Name = Name;

            Version = 0;
            AddTime = DateTimeOffset.Now;
            UpdateTime = DateTimeOffset.Now;
            AddUserId = UserHelper.User.Id;
            UpdateUserId = UserHelper.User.Id;
        }



        public string Code { get; private set; }
        /// <summary>
        /// 站名
        /// </summary>
        public string Name { get; private set; }

        public override bool Equals(object obj)
        {
            var other = obj as Station;
            return this.Code == other.Code && this.Name == other.Name;
        }
        public override int GetHashCode()
        {
            var a = Code.GetHashCode();
            var b = Name.GetHashCode();
            return a ^ b;
        }

        public static bool operator ==(Station left, Station right)
        {
            return isEqual(left, right);
        }
        public static bool operator !=(Station left, Station right)
        {
            return !isEqual(left, right);
        }

        private static bool isEqual(Station left, Station right)
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
            return $"【{Name}】";
        }

    }
}
