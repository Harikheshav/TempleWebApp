using System;
using System.Collections.Generic;

namespace TempleWebApp.Models
{
    public partial class FnHallBkng
    {
        public int Bkid { get; set; }
        public string? Det { get; set; }
        public DateTime? Sdt { get; set; }
        public DateTime? Edt { get; set; }
        public int Cost { get; set; }
        public FnHallBkng()
        {

        }
        public FnHallBkng(SlotBkng slot)
        {
            Bkid = slot.Bkid;
            Det = slot.Det;
            Sdt = slot.Sdt;
            Edt = slot.Edt;
            Cost = slot.Cost;
        }

    }
}
