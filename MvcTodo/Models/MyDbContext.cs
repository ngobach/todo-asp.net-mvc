namespace MvcTodo.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyDbContext : DbContext
    {
        // Your context has been configured to use a 'SampleModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MvcTodo.Models.SampleModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SampleModel' 
        // connection string in the application configuration file.
        public MyDbContext() : base("name=MyDbContext")
        {
            Database.SetInitializer(new MySeeder());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Task> Tasks { get; set; }
    }
    
    public class MySeeder : CreateDatabaseIfNotExists<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            context.Tasks.Add(new Task
            {
                Name = "Seeded",
                Archived = false,
                Created = DateTime.Now,
                Updated = DateTime.Now
            });
            base.Seed(context);
        }
    }

    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Archived { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}