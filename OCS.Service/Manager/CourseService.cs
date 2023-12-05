using AutoMapper;
using OCS.Core.Model.Course;
using OCS.Core.ViewModel.Course;
using OCS.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Service.Manager
{
    public class CourseService
    {
        // database object
        ApplicationDB _db;
        public CourseService()
        {
            _db = new ApplicationDB();
        }

        //post method
        public int Post(CourseView vm)
        {
            var entity = Mapper.Map<CourseView, Course>(vm);
            _db.Courses.Add(entity);
            return _db.SaveChanges();
        }

        //get method
        public CourseView Get(int id)
        {
            var entity = _db.Courses.SingleOrDefault(m => m.Id == id);
            return Mapper.Map<Course, CourseView>(entity);
        }

        //get all method
        public IEnumerable<CourseView> GetAll()
        {
            var entities = _db.Courses.ToList();
            return entities.Select(Mapper.Map<Course, CourseView>);
        }

        //put method
        public int Put(int id, CourseView vm)
        {
            var entity = _db.Courses.SingleOrDefault(m => m.Id == id);
            Mapper.Map(vm, entity);
            return _db.SaveChanges();
        }

        //remove method
        public int Remove(int id)
        {
            var entity = _db.Courses.SingleOrDefault(m => m.Id == id);
            _db.Courses.Remove(entity);
            return _db.SaveChanges();
        }
    }
}
