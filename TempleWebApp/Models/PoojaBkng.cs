using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TempleWebApp.Models
{
    public partial class PoojaBkng
    {
        public int Bkid { get; set; }
        [DataType(DataType.Currency)]
        public int? Cost { get; set; }
        public int? Pooid { get; set; }
        public string? Det { get; set; }
        [DataType(DataType.DateTime), ValidateIfPast(ErrorMessage = "Cannot Assign Events on Past Date and Time")]
        public DateTime? Sdt { get; set; }
        [DataType(DataType.DateTime), ValidateIfFuture("Sdt",ErrorMessage = "Event ends before it gets started")]
        public DateTime? Edt { get; set; }
        public int? Userid { get; set; }

        public virtual Pooja? Poo { get; set; }
        public virtual User? User { get; set; }
        public PoojaBkng() 
        { 
        }
    }
}
