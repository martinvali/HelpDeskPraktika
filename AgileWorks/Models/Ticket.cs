using System.ComponentModel.DataAnnotations;

namespace AgileWorks.Models {
    public class Ticket {
        
        public Ticket() {
            DateCreated = DateTime.Now;
            MarkedAsUrgent = false;
        }
        public int Id { get; set; }

        [Required]

        public string? Description { get;set; }

        [Required]
        [ScaffoldColumn(false)]
        [Display(Name="Created at")]
        public DateTime DateCreated { get;set; }

        [Display(Name = "Due")]
        public DateTime DueDate { get;set; }

        [Required]
        [ScaffoldColumn(false)]
        public bool MarkedAsUrgent { get; set; }
    }
}
