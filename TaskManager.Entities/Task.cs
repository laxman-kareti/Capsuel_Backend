using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TaskManager.Entities
{
    [Table("Task")]
    public class TaskEntity
    {
        [Key]
        public int TaskId { get; set; }

        public int? ParentId { get; set; }
        [NotMapped]
        public string ParentTask { get; set; }

        public string TaskName { get; set; }

        public int? Priority { get; set; }

        public int ProjectId { get; set; }
        //   [ForeignKey("ProjectId")]
        //  public Project Project { get; set; }

        public int UserId { get; set; }

        public string Status { get; set; }
       
        [Column(TypeName ="Date")]
       [JsonConverter (typeof(DateConverter))]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "Date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? EndDate { get; set; }
    }
}
