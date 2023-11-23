
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace backend.Entities.Entities
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id  { get; set; }
        public string name  { get; set; }
        public string gender  { get; set; }
        public string Address  { get; set; }
        public string MaritalStatus  { get; set; }
        public string ssn  { get; set; }
        public string contact  { get; set; }
        public string email  { get; set; }
        public DateTime birthdate {get; set;}
        public DateTime hireDate{ get; set; }
    }

}
