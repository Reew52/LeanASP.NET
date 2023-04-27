using LeanASP.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace LeanASP.Net.Data
{
    public class ApplicationDbcontext: DbContext // Dung DbContext va can using EntityFrameworkCore
    {
        // ctor tao ham contructor
        // Cau hinh ngu canh tuy chon DB
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {
            // gửi 1 vài option đến DB
            
        }
        // method lấy ra bảng
        public DbSet<Category> Categories { get; set; }
    }
}
