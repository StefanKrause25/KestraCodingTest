using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KestraCodingTest.Models
{
    public class PetFormModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PetName { get; set; }
        public int PetAge { get; set; }
        public string PetType { get; set; }
    }
}
