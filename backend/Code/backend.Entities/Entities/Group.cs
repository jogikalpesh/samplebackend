
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace backend.Entities.Entities
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id  { get; set; }
        public string number  { get; set; }
        public string name  { get; set; }
        public string type  { get; set; }
        public string streetAddress  { get; set; }
        public string contactDetails  { get; set; }
        public DateTime effectiveEndDate {get;set;}
        public DateTime effectiveStartDate {get;set;}
        
    }

}
