using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TaskManager.Entities
{
    [Table("Users")]
   public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int EmployeeId { get; set; }

       
       
        //[ForeignKey("ProjectId")]
      //  public Project Project { get; set; }

        
       
        //[ForeignKey("TaskId")]
      //  public TaskEntity Task { get; set; }






    }
}
