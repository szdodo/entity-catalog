using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class DVD
    {
        public int DvdId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }

        public virtual List<Actor> Actors { get; set; }
    }
}
