using AutoMapper;
using OCS.Core.Model.SignUpModel;
using OCS.Core.PatchModel;
using OCS.Core.ViewModel.SignUpViewModel;
using OCS.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Service.Manager
{
    public class UserSignUpService
    {
        // database connection ovject
        ApplicationDB _db;
        public UserSignUpService()
        {
            _db = new ApplicationDB();
        }

        // get method 
        public UserSignUpView Get(int id)
        {
            var entity = _db.Users.Include("Course").SingleOrDefault(m => m.Id == id);
            return Mapper.Map<UserSignUp, UserSignUpView>(entity);
        }

        //getall method 
        public IEnumerable<UserSignUpView> GetAll()
        {
            var entities = _db.Users.ToList();
            return entities.Select(Mapper.Map<UserSignUp, UserSignUpView>);
        }

        //post method
        public int Post(UserSignUpView vm)
        {
            vm.UserRole = "User";
            var entity = Mapper.Map<UserSignUpView, UserSignUp>(vm);
            _db.Users.Add(entity);
            return _db.SaveChanges();
        }

        //put method
        public int Put(int id, UserSignUpView vm)
        {
            var entity = _db.Users.SingleOrDefault(m => m.Id == id);
            Mapper.Map(vm, entity);
            return _db.SaveChanges();
        }
        
        //patch method
        public int Patch(int id, string vm)
        {
            var entity = _db.Users.SingleOrDefault(m => m.Id == id);
            entity.CourseId = vm;
            //Mapper.Map(vm, entity);
            return _db.SaveChanges();
        }

        //delete method
        public int Delete(int id)
        {
            var entity = _db.Users.SingleOrDefault(m => m.Id == id);
            _db.Users.Remove(entity);
            return _db.SaveChanges();
        }
    }
}
