using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Plane
    {
        public Guid ID { get; set; }
        public string model { get; set; }
        public int seats { get; set; }
        public override string ToString()
        {
            return model;
        }
    }
}
