using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonApplicationDll.Entities
{
    public class PersonStatus
    {
        public int Id { get; set; }

        [Display(Name = "StatusName")]
        public string Name { get; set; }

        public List<Person> Persons { get; set; }
    }
}