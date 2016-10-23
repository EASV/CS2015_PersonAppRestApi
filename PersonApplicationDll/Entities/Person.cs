using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonApplicationDll.Entities
{
    [Table("Persons")]
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PersonStatusId { get; set; }
        public PersonStatus Status { get; set; }
        public List<Wish> Wishes { get; set; }
        public List<Person> Friends { get; set; }
    }
}