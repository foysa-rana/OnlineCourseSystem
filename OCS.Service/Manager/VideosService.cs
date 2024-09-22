using AutoMapper;
using OCS.Core.Model.VideoModel;
using OCS.Core.ViewModel.VideosViewModel;
using OCS.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Service.Manager
{
    public class VideosService
    {
        //database object
        public ApplicationDB _db;
        public VideosService()
        {
            _db = new ApplicationDB();
        }

        //get method
        public VideosView Get(int id)
        {
            var entity = _db.Videos.Include("Course").SingleOrDefault(m => m.Id == id);
            return Mapper.Map<Videos, VideosView>(entity);
        }

        //get all method
        public IEnumerable<VideosView> GetAll()
        {
            var entities = _db.Videos.Include("Course").ToList();
            return entities.Select(Mapper.Map<Videos, VideosView>);
        }

        //post method
        public int Post(VideosView vm)
        {
            var entity = Mapper.Map<VideosView, Videos>(vm);
            _db.Videos.Add(entity);
            return _db.SaveChanges();
        }

        //put method
        public int Put(int id, VideosView vm)
        {
            var entity = _db.Videos.SingleOrDefault(m => m.Id == id);
            Mapper.Map(vm, entity);
            return _db.SaveChanges();
        }

        //delete method
        public int Delete(int id)
        {
            var entity = _db.Videos.SingleOrDefault(m => m.Id == id);
            _db.Videos.Remove(entity);
            return _db.SaveChanges();
        }
    }
}
