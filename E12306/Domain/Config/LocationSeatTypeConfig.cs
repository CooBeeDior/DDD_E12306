using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{
    //    Top,
    //    Middle,
    //    Down,

    //    A,
    //    B,
    //    C,
    //    D,
    //    E,
    //    F
    [Table("LocationSeatTypeConfig")]
    public class LocationSeatTypeConfig : ConfigBase
    {
        private LocationSeatTypeConfig() : base()
        {

        }
        public LocationSeatTypeConfig(SeatTypeConfig SeatTypeConfig, string Code, string Name, bool IsCloseWindow = false) : base(Code, Name)
        {
            this.IsCloseWindow = IsCloseWindow;
            this.SeatTypeConfig = SeatTypeConfig;

            SeatTypeConfig.AddLocationSeatTypeConfig(this);
        }

        [Required] 
        public virtual SeatTypeConfig SeatTypeConfig { get; private set; }

     
 

        [Required]
        public bool IsCloseWindow { get; private set; }




    }
}
