using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeanASP.Net.Models
{
    public class Category
    {
        [Key] // Khai báo id là khóa chính (cần using DataAnnotations)
        public int Id { get; set; }
        [Required] // khai báo name không được bỏ trống
        public string Name { get; set; }
        //chỉ định tên hiển thị cho trường dữ liệu "DisplayOrder"
        [DisplayName("Display Order")]
        // Display order chỉ được từ 1 đến 100 (phạm vi)
        [Range(1,100, ErrorMessage="Display Order must be between 1 and 100 only!")]
        public int DisplayOrder { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;    

    }
}
