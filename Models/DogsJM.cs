using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApisJM.Models
{
    [Table("dogs")]
    public class DogsJM
    {
        public string id { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }   
    }
}

