using OCS.Core.Model.CourseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Core.ViewModel.VideosViewModel
{
    public class VideosView
    {
        public int Id { get; set; }
        [Required]
        public string Video { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
