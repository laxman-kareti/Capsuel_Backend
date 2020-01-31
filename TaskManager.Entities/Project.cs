using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TaskManager.Entities
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }
        [Column(TypeName = "Date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "Date")]
        [JsonConverter(typeof(DateConverter))]
        public DateTime? EndDate { get; set; }

        public int Priority { get; set; }
        [NotMapped]
        public int? CompletedTasks { get; set; }
        [NotMapped]
        public int? TotalTasks { get; set; }

        public int UserId { get; set; }

        //public ICollection<TaskEntity> Tasks { get; set; }

        // public ICollection<User> Users { get; set; }


    }
}
