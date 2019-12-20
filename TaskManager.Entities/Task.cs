using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskManager.Entities
{
    [Table("Task")]
    public class TaskEntity
    {
        [Key]
        public int TaskId { get; set; }

        public int? ParentId { get; set; }

        public string TaskName { get; set; }

        public int? Priority { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
