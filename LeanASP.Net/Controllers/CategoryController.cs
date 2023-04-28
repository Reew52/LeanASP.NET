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
        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST (một phương thức là post chúng ta cần viết thuộc tính HTTP POST)
        [HttpPost]
        /* xác thực mã thông báo giả mạo có mã thông báo chống giả mạo hay không
           để trợ giúp và ngăn chặn cuộc tấn công giả mạo yêu cầu trên nhiều trang web*/
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                // hiển thị lỗi ở CustomError
                ModelState.AddModelError("name","The Display Order cannot exactly match the Name");
            }
            // kiểm tra tính hợp lệ của mô hình (ModelState.IsValid) trước khi lưu đối tượng mới vào cơ sở dữ liệu.
            if (ModelState.IsValid)
            {
                // tạo đối tượng mới của lớp category
                _db.Categories.Add(obj);
                // lưu vào DB
                _db.SaveChanges();
                // Dữ liệu tạm thời
                TempData["success"] = "Category create successfully!";
                // chuyển hướng tới index
                return RedirectToAction("Index");
            }

            // dữ liệu không hợp lệ, trả về view hiển thị dữ liệu đã nhập và thông báo lỗi
            return View(obj);
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id  == 0)
            {
                return NotFound();
            }
            // gán id tìm được bằng var
            var categoryFormDb = _db.Categories.Find(id);
            //var categoryFormDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFormDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFormDb == null)
            {
                return NotFound();
            }
            // trả view cùng với biến
            return View(categoryFormDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                // thực hiện update
                _db.Categories.Update(obj);
                // lưu vào DB
                _db.SaveChanges();
                // dữ liệu tạm thời
                TempData["success"] = "Category updated successfully!";
                // chuyển hướng tới index
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // gán id tìm được bằng var
            var categoryFormDb = _db.Categories.Find(id);
            if (categoryFormDb == null)
            {
                return NotFound();
            }
            // trả view cùng với biến
            return View(categoryFormDb);
        }
        // đặt tên cho action
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            // tìm id
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            // thực hiện xóa
            _db.Categories.Remove(obj);
            // lưu vào DB
            _db.SaveChanges();
            // dữ liệu tạm thời
            TempData["success"] = "Category deleted successfully!";
            // chuyển hướng tới index
            return RedirectToAction("Index");
        }

    }
}
