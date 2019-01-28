using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{

    //    Normal
    //    OneSeat,
    //    TwoSeat,
    //    BusinessSeat,
    //    HardSleep,
    //    SoftSleep,
    //    Eat,
    [Table("CarriageTypeConfig")]
    public class CarriageTypeConfig : ConfigBase
    {
        
        public CarriageTypeConfig(string Code, string Name) : base(Code, Name)
        {

        }
  
    }
}
