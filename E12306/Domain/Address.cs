using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{
    [Table("Address")]
    public class Address : ValueObject<Address>
    {
        private Address()
        { }

        public Address(CustomerInfo CustomerInfo, string Province, string City, string Area, string Detail) : base()
        {
            this.CustomerInfo = CustomerInfo;
            this.Province = Province;
            this.City = City;
            this.Area = Area;
            this.Detail = Detail;
            this.CustomerInfo.AddAddress(this);
        }

        public CustomerInfo CustomerInfo { get; }
        public string Province { get; private set; }

        public string City { get; private set; }

        public string Area { get; private set; }

        public string Detail { get; private set; }

        protected override bool EqualsCore(Address other)
        {
            return this.Province == other.Province
                && this.City == other.City
                && this.Area == other.Area
                && this.Detail == other.Detail;
        }

        protected override int GetHashCodeCore()
        {
            var a = Province.GetHashCode();
            var b = City.GetHashCode();
            var c = Area.GetHashCode();
            var d = Detail.GetHashCode();
            return a ^ b ^ c ^ d;
        }
    }
}
