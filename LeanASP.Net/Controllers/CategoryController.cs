using LeanASP.Net.Data;
using LeanASP.Net.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeanASP.Net.Controllers
{
    public class CategoryController : Controller
    {

        // tạo 1 trường private đây sẽ là ngữ cảnh DB ứng dụng (cần use LeanASP.Net.Data )
        private readonly ApplicationDbcontext _db;

        // contructor
        public CategoryController(ApplicationDbcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            // truy cập _db (chúng ta có tất cả bộ Database)
            // nó sẽ chuyển đến DB và truy xuất tất cả
            /* "IEnumerable<Category>". Kiểu dữ liệu này cho phép biến chứa một danh sách các
               đối tượng của lớp "Category", và có thể được sử dụng để thực hiện các hoạt động
               liên quan đến việc lặp lại và truy xuất danh sách. */
            IEnumerable<Category> objCategoryList = _db.Categories;
            // để sử dụng ta cần gọi sang view 
            return View(objCategoryList);
        }
    }
}
