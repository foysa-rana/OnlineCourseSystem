using AutoMapper;
using OCS.Core.Model.Seminar;
using OCS.Core.ViewModel.Seminar;
using OCS.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Service.Manager
{
    public class SeminarService
    {
        // database object
        ApplicationDB _db;
        public SeminarService()
        {
            _db = new ApplicationDB();
        }

        //post method
        public int Post(SeminarView vm)
        {
            var entity = Mapper.Map<SeminarView, Seminar>(vm);
            _db.Seminars.Add(entity);
            return _db.SaveChanges();
        }

        //get method
        public SeminarView Get(int id)
        {
            var entity = _db.Seminars.SingleOrDefault(m => m.Id == id);
            return Mapper.Map<Seminar, SeminarView>(entity);
        }

        //get all method
        public IEnumerable<SeminarView> GetAll()
        {
            var entities = _db.Seminars.ToList();
            return entities.Select(Mapper.Map<Seminar, SeminarView>);
        }

        //put method
        public int Put(int id, SeminarView vm)
        {
            var entity = _db.Seminars.SingleOrDefault(m => m.Id == id);
            Mapper.Map(vm, entity);
            return _db.SaveChanges();
        }

        //remove method
        public int Remove(int id)
        {
            var entity = _db.Seminars.SingleOrDefault(m => m.Id == id);
            _db.Seminars.Remove(entity);
            return _db.SaveChanges();
        }
    }
}
