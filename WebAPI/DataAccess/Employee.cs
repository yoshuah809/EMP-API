using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DataAccess
{
    [Table("Employee")]
    public class Employee
    {
        [Column("EmployeeId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int EmployeeId { get; set; }

        [Column("EmployeeName")]
        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }
       
        [Column("DateOfJoining")]
        public string DateOfJoining { get; set; }

        [Column("PhotoFileName")]
        public string PhotoFileName { get; set; }

        [ForeignKey("DepartmentId")]
        [Required]
        public int DeparmentId { get; set; }

        public virtual Department Deparment { get; set; }
    }
}
