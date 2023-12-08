using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Core.ViewModel.Trainer
{
    public class TrainerView
    {
        public int Id { get; set; }
        public string TrainerId { get; set; }
        public string Photo { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string JobTitle { get; set; }
        public string Position { get; set; }
        public string JoiningDate { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public int Salary { get; set; }
    }
}
