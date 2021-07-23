using System.Collections.Generic;

namespace WebApp.Models {
    public class KanbanBoard {
        public IEnumerable<KanbanCard> Backlog {get; set;}
        public IEnumerable<KanbanCard> InProgress { get; set; }
        public IEnumerable<KanbanCard> Review { get; set; }
        public IEnumerable<KanbanCard> Testing { get; set; }
        public IEnumerable<KanbanCard> Done { get; set; }
        public string NewTitle { get; set; }
        public string NewDesc { get; set; }


        public KanbanBoard() { 
            Backlog = new List<KanbanCard>();
            InProgress = new List<KanbanCard>();
            Review = new List<KanbanCard>();
            Testing = new List<KanbanCard>();
            Done = new List<KanbanCard>();
        }
    }
}