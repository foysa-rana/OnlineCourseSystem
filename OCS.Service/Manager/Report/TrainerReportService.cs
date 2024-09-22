using OCS.Core.ReportModel.ReportViewModel;
using OCS.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Service.Manager.Report
{
    public class TrainerReportService
    {
        // database connection ovject
        ApplicationDB _db;
        public TrainerReportService()
        {
            _db = new ApplicationDB();
        }

        //get all method
        public IEnumerable<TrainerViewModel> GetAllTrainer()
        {
            var trainers = _db.Trainers.ToList();
            var entities = new List<TrainerViewModel>();

            foreach(var trainer in trainers)
            {
                var model = new TrainerViewModel()
                {
                    TrainerId = trainer.TrainerId,
                    FName = trainer.FName,
                    LName = trainer.LName,
                    Position = trainer.Position,
                    Salary = trainer.Salary
                };
                entities.Add(model);
            }
            return entities;
        }

        //get method
        public IEnumerable<TrainerViewModel> GetIndividualTrainer(int id)
        {
            var trainers = _db.Trainers.ToList().Where(m => m.Id == id);
            var entity = new List<TrainerViewModel>();

            foreach(var trainer in trainers)
            {
                var model = new TrainerViewModel()
                {
                    TrainerId = trainer.TrainerId,
                    Photo = trainer.Photo,
                    FName = trainer.FName,
                    LName = trainer.LName,
                    BirthDate = trainer.BirthDate.ToString(),
                    Gender = trainer.Gender,
                    Phone = trainer.Phone,
                    Email = trainer.Email,
                    JobTitle = trainer.JobTitle,
                    Position = trainer.Position,
                    JoiningDate = trainer.JoiningDate.ToString(),
                    PresentAddress = trainer.PresentAddress,
                    PermanentAddress = trainer.PermanentAddress,
                    Salary = trainer.Salary,
                    About = trainer.About
                };
                entity.Add(model);
            }
            
            return entity;
        }
    }
}
