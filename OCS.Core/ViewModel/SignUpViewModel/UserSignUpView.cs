using OCS.Core.Model.CourseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Core.ViewModel.SignUpViewModel
{
    public class UserSignUpView
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Photo { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
        [Required]
        public string UserRole { get; set; }
    }
}
