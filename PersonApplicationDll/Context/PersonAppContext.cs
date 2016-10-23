using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonApplicationDll.Entities;

namespace PersonApplicationDll.Context
{
    public class PersonAppContext : DbContext
    {
        public PersonAppContext() : base()
        {
            Database.SetInitializer(new DataBaseInitializer());
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonStatus> PersonStatuses { get; set; }
        public DbSet<Wish> Wishes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //one-to-many 
            modelBuilder.Entity<Person>()
                .HasRequired<PersonStatus>(p => p.Status)
                .WithMany(ps => ps.Persons)
                .HasForeignKey(conf => conf.PersonStatusId);

            //many-to-many
            modelBuilder.Entity<Person>()
                .HasMany<Wish>(p => p.Wishes)
                .WithMany(c => c.Persons);


            base.OnModelCreating(modelBuilder);
        }
    }

    public class DataBaseInitializer : DropCreateDatabaseAlways<PersonAppContext>
    {
        protected override void Seed(PersonAppContext db)
        {
            var wish1 = new Wish() { Name = "Bird", Created = DateTime.Now.AddDays(-2) };
            var wish2 = new Wish() { Name = "Plane", Created = DateTime.Now.AddDays(-1) };
            var wish3 = new Wish() { Name = "SuperMan", Created = DateTime.Now.AddDays(-30) };
            var wish4 = new Wish() { Name = "Bowl of snails", Created = DateTime.Now.AddDays(-4) };

            db.Wishes.Add(wish1);
            db.Wishes.Add(wish2);
            db.Wishes.Add(wish3);
            db.Wishes.Add(wish4);

            var defaultStatus = new PersonStatus() {Name = "At Home"};
            db.PersonStatuses.Add(defaultStatus);
            db.PersonStatuses.Add(new PersonStatus() { Name = "At Work" });
            db.PersonStatuses.Add(new PersonStatus() { Name = "In Spain" });

            db.Persons.Add(new Person() {Name = "Bill", Status = defaultStatus, Wishes = new List<Wish> {wish1, wish2, wish3} });
            db.Persons.Add(new Person() { Name = "Joe", Status = defaultStatus, Wishes = new List<Wish> { wish1, wish3, wish4 } });
            db.Persons.Add(new Person() { Name = "Jill", Status = defaultStatus, Wishes = new List<Wish> { wish2, wish3 } }); 
            db.Persons.Add(new Person() { Name = "Billy", Status = defaultStatus, Wishes = new List<Wish> {wish4 } });

            
            base.Seed(db);
        }
    }
}
