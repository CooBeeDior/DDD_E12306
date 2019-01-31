using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E12306.Domain
{
    //K,
    //Z,
    //T,
    //D,
    //G,
    //C
    [Table("TrainTypeConfig")]
    public class TrainTypeConfig : ConfigBase
    {
        public TrainTypeConfig(string Code, string Name) : base(Code, Name)
        {

        }

    }
}
