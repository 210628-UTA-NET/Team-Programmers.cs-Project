using System.Collections.Generic;

namespace WebApp.Models {
    public class KanbanBoard {
        public IEnumerable<KanbanCard> Backlog {get; set;}
        public IEnumerable<KanbanCard> InProgress { get; set; }
        public IEnumerable<KanbanCard> Review { get; set; }
        public IEnumerable<KanbanCard> Testing { get; set; }
        public IEnumerable<KanbanCard> Done { get; set; }
        int NCols { get; set; }


        public KanbanBoard() {
            NCols = 5;
            Backlog = new List<KanbanCard>();
            InProgress = new List<KanbanCard>();
            Review = new List<KanbanCard>();
            Testing = new List<KanbanCard>();
            Done = new List<KanbanCard>();
        }
    }
}