using System;
using System.Collections.Generic;
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
    public class LocationSeatTypeConfig : ConfigBase
    {
        public LocationSeatTypeConfig(string Code, string Name,bool IsCloseWindow=false) : base(Code, Name)
        {
            this.IsCloseWindow = IsCloseWindow;
        }

        public bool IsCloseWindow { get; private set; }


     

    }
}
