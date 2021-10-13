using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TadaEntryWebApp.Models
{
    public class TadaHistory
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public int TravelCost { get; set; }
        public int LunchCost { get; set; }
        public int InstrumentCost { get; set; }
        public int TotalCost { get; set; }
        public bool IsPaid { get; set; }

        
    }
}