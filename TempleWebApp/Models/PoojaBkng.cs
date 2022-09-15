using System;
using System.Collections.Generic;

namespace TempleWebApp.Models
{
    public partial class PoojaBkng
    {
        public int Bkid { get; set; }
        public int? Pooid { get; set; }
        public string? Det { get; set; }
        public DateTime? Sdt { get; set; }
        public DateTime? Edt { get; set; }

        public virtual Pooja? Poo { get; set; }
        public PoojaBkng()
        {

        }

    }
}
