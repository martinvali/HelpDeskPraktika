namespace AgileWorks.Models {
    public class Ticket {
        
        public int Id { get; set; }
        public string Description { get;set; }
        public DateTime DateCreated { get;set; }
        public DateTime DueDate { get;set; }
    }
}
