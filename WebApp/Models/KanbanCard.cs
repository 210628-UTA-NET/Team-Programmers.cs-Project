using System.ComponentModel.DataAnnotations;

namespace WebApp.Models{
    public class KanbanCard{
        public KanbanCard(){

        }
        public int ID { get; set; }
        public string Title { get; set; }
        public string ColumnType { get; set; }
        public string Details { get; set; }
    }
}