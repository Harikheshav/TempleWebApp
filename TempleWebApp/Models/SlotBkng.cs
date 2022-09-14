using System.ComponentModel.DataAnnotations;

namespace TempleWebApp.Models
{
    public class SlotBkng
    {
        [Key]
        public int Bkid { get; set; }
        public string? Det { get; set; }
        public DateTime? Sdt { get; set; }
        public DateTime? Edt { get; set; }
        public string SlotName { get; set; }

        public SlotBkng()
        {

        }
    }
}
