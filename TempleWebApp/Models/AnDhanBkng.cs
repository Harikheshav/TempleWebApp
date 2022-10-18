﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TempleWebApp.Models
{
    public partial class AnDhanBkng
    {
        public int Bkid { get; set; }
        [DataType(DataType.Currency)]
        public int? Cost { get; set; }
        public string? Det { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Sdt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Edt { get; set; }
        public int? Userid { get; set; }

        public virtual User? User { get; set; }
        public AnDhanBkng(SlotBkng slot)
        {
            Bkid = slot.Bkid;
            Cost = slot.Cost;
            Det = slot.Det;
            Sdt = slot.Sdt;
            Edt = slot.Edt;
        }
        public AnDhanBkng() { }
    }
}
