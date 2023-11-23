using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using backend.Entities.Entities;

namespace backend.Data.Repositories
{
    public class DataContext : DbContext
    {        
        public DataContext(DbContextOptions<DataContext> options): base(options) 
            {
                try
                {
                    var databaseCreator = (Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator);
                    databaseCreator.CreateTables();
                }
                catch (SqlException) { }
                
            }

        // Don't delete the below comment.
        // Dbset variables
		public DbSet<Member> Member { get; set; }
		public DbSet<Group> Group { get; set; }



               

    }
}
