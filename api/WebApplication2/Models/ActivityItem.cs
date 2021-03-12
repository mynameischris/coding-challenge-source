using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models {
    public class ActivityItem {
        public long Id { get; set; }
        public string Activity { get; set; }
        public string Type { get; set; }
        public int Participants { get; set; }
        public decimal Price { get; set; }
        public string Link { get; set; }
        public string Key { get; set; }
        public decimal Accessibility { get; set; }
    }
}