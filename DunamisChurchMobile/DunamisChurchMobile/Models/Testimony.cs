using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunamisChurchMobile.Models
{
    public class Testimony
    {
        public string id { get; set; }
        public string title { get; set; }
        public DateTime date { get; set; }
        public string details { get; set; }
        public string testifiersName { get; set; }
    }
}
