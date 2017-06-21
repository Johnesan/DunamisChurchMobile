using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunamisChurchMobile.Models
{
    public class Event
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime eventTime { get; set; }
        public string venue { get; set; }
        public string description { get; set; }
        public string  imagePath { get; set; }
    }
}