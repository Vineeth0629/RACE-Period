using Microsoft.EntityFrameworkCore;

namespace Authentication.Context
{
    public class ApplicationDbcontext:DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {

        }
        public virtual DbSet<UserModel> usermodel { get; set; }
    }
}
 