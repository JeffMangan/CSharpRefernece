//
// This is the implementation for the storage, postgresql in this case. It is specific to the product aggregated
// root.  The interface for this is kept in the domain layer to enforce the domain rules that this must adhere to.
// It uses Entity framework, which allows the db to be created automatically based on the structure of the domain model.
//
// This will need to be designed properly once th domain is properly defined.  Also you might want to not use this
// and do the reverse, create the object model from the db schema.
//

using System;
using System.Runtime.CompilerServices;
using SampleCompany.Domain;
using Microsoft.EntityFrameworkCore;

namespace SampleCompany.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        
        public ProductRepository(string host, string userName, string password, string database)
        {
            //todo:validate the params here
            this._connectionString = $"Host={host};Username={userName};Password={password};Database={database}";
        }

        public System.Guid AddNewProduct(Product p)
        {
            try
            {
                using (var c = GetContext())
                {
                    c.Product.Add(p);
                    c.SaveChanges();
                    return p.Id;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool ChangeProductPrice()
        {
            throw new NotImplementedException();
        }

        public Guid AddPart(ProductPart part)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }
        
        //todo: move this and the context class to separate objects to be reused across all pgsql repos
        private Context GetContext()
        {
            var context = new Context(_connectionString);
            Console.WriteLine(_connectionString);
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }
    }
    
    /// <summary>
    /// This class is used to initiate the db, and the related entity framework schema
    /// </summary>
    public class Context : DbContext
    {
        private readonly string _connectionString;

        public Context(string cs)
        {
            _connectionString = cs;

        }
        
        public DbSet<Product> Product { get; set; }
        public DbSet<Part> Part { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

    }
}


/*
public async Task<List<Output>> Get(Input input)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            await using var cmd = new NpgsqlCommand("query statement", conn);
            NpgsqlDataReader  reader = await cmd.ExecuteReaderAsync();
            return new List<Output>();
        }

        public async Task<int> Put(Input input)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "";  
            Task<int> rowsAffected = cmd.ExecuteNonQueryAsync();
            await conn.CloseAsync();
            return rowsAffected.Result; //items affected
        }

        public async Task<int> Delete(Input input)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            await using var cmd = new NpgsqlCommand("Delete statement here....", conn);
            await cmd.ExecuteNonQueryAsync();
            return 1; //number of items affected
        }
*/