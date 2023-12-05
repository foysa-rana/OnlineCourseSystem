using AutoMapper;
using OCS.Core.Model.Trainer;
using OCS.Core.ViewModel.Trainer;
using OCS.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Service.Manager
{
    public class TrainerService
    {
        // database connection ovject
        ApplicationDB _db;
        public TrainerService()
        {
            _db = new ApplicationDB();
        }

        // get method 
        public TrainerView Get(int id)
        {
            var entity = _db.Trainers.SingleOrDefault(m => m.Id == id);
            return Mapper.Map<Trainer, TrainerView>(entity);
        }

        //getall method 
        public IEnumerable<TrainerView> GetAll()
        {
            var entities = _db.Trainers.ToList();
            return entities.Select(Mapper.Map<Trainer, TrainerView>);
        }

        //post method
        public int Post(TrainerView vm)
        {
            var entity = Mapper.Map<TrainerView, Trainer>(vm);
            _db.Trainers.Add(entity);
            return _db.SaveChanges();
        }

        //put method
        public int Put(int id, TrainerView vm)
        {
            var entity = _db.Trainers.SingleOrDefault(m => m.Id == id);
            Mapper.Map(vm, entity);
            return _db.SaveChanges();
        }

        //delete method
        public int Delete(int id)
        {
            var entity = _db.Trainers.SingleOrDefault(m => m.Id == id);
            _db.Trainers.Remove(entity);
            return _db.SaveChanges();
        }
    }
}
