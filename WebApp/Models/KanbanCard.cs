using System.ComponentModel.DataAnnotations;

namespace WebApp.Models{
    public class KanbanCard{
        public int ID { get; set; }
        public string Title { get; set; }

        [Range(0, int.MaxValue)]
        public int Column { get; set; } = 0;
        public string Details { get; set; }
    }
}