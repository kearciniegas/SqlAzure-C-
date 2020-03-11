using Microsoft.EntityFrameworkCore;
using ProjectSQLAzure.Models;

namespace ProjectSQLAzure.Models
{
  public class ContactsContext : DbContext
  {
    public ContactsContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Contacts> ContactSet {get; set;}
  }
}