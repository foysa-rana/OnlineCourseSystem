using OCS.Core.Model.TrainerModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Core.Model.CourseModel
{
    public class Course
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Fee { get; set; }
        [Required]
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string Description { get; set; }
        public int PurchaseCount { get; set; }
    }
}
