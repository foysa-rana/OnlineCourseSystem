using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Core.Model.TrainerModel
{
    public class Trainer
    {
        public int Id { get; set; }
        [Required]
        public string TrainerId { get; set; }
        public string Photo { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        [Required]
        public string PresentAddress { get; set; }
        [Required]
        public string PermanentAddress { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string About { get; set; }
    }
}
