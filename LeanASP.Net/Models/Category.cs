using System.ComponentModel.DataAnnotations;

namespace LeanASP.Net.Models
{
    public class Category
    {
        [Key] // Khai báo id là khóa chính (cần using DataAnnotations)
        public int Id { get; set; }
        [Required] // khai báo name không được bỏ trống
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;    

    }
}
