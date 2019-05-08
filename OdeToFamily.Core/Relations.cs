using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OdeToFamily.Core
{
    public class Relations
    {
        [Key, DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int PeopleId { get; set; }
        public People People { get; set; }
        [Required]
        public int PeopleRelateToId { get; set; }
        public People PeopleRelateTo { get; set; }
        public RelationType Relation { get; set; }
    }
}
