using Book_Order.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Order.Data
{
    public class BookDbContext : DbContext
    {
      
        
            public BookDbContext(DbContextOptions options) : base(options)
            {

            }

            public DbSet<book>  books { get; set; }
        public DbSet<useraccounts>  useraccounts { get; set; }
        public DbSet<orders> orders { get; set; }
        public DbSet<report> report { get; set; }   

    }
}
