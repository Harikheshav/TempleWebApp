using System;
using System.Collections.Generic;

namespace TempleWebApp.Models
{
    public partial class PoojaBkng
    {
        public int Bkid { get; set; }
        public string? Det { get; set; }
        public DateTime? Sdt { get; set; }
        public DateTime? Edt { get; set; }
        public PoojaBkng()
        {

        }

        public PoojaBkng(SlotBkng slot)
        {
            Bkid = slot.Bkid;
            Det = slot.Det;
            Sdt = slot.Sdt;
            Edt = slot.Edt;
        }
    }
}
