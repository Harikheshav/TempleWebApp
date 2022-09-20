using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TempleWebApp.Models
{
    public partial class FnHallBkng
    {
        public int Bkid { get; set; }
        [DataType(DataType.Currency)]
        public int? Cost { get; set; }
        public string? Det { get; set; }
        [DataType(DataType.DateTime), ValidateIfPast(ErrorMessage = "Cannot Assign Events on Past Date and Time")]
        public DateTime? Sdt { get; set; }
        [DataType(DataType.DateTime), ValidateIfFuture("Sdt", ErrorMessage = "Event ends before it gets started")]
        public DateTime? Edt { get; set; }
        public int? Userid { get; set; }

        public virtual User? User { get; set; }
        public FnHallBkng(SlotBkng slot)
        {
            Bkid = slot.Bkid;
            Cost = slot.Cost;
            Det = slot.Det;
            Sdt = slot.Sdt;
            Edt = slot.Edt;
        }
        public FnHallBkng() { }
    }
}
