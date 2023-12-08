using AutoMapper;
using OCS.Core.CommonModel;
using OCS.Core.Model.Course;
using OCS.Core.Model.Seminar;
using OCS.Core.Model.Trainer;
using OCS.Core.ViewModel.Course;
using OCS.Core.ViewModel.Seminar;
using OCS.Core.ViewModel.Trainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Core.AutoMapperConfigurations
{
    public class MappingsProfile : Profile
    {
        public override string ProfileName => "MappingsProfile";
        public MappingsProfile()
        {
            CreateMap<Course, CourseView>();
            CreateMap<CourseView, Course>();

            CreateMap<Seminar, SeminarView>();
            CreateMap<SeminarView, Seminar>();

            CreateMap<Trainer, TrainerView>();
            CreateMap<TrainerView, Trainer>();

            CreateMap<Trainer, TrainerView>()
               .ForMember(vm => vm.BirthDate,
                   opt => opt.MapFrom(m => DateTimeFormatter.DateToString(m.BirthDate)))
                   .ForMember(dto => dto.JoiningDate,
                   opt => opt.MapFrom(m => DateTimeFormatter.DateToString(m.JoiningDate)));

            CreateMap<TrainerView, Trainer>()
                .ForMember(dto => dto.BirthDate,
                    opt => opt.MapFrom(m => DateTimeFormatter.StringToDate(m.BirthDate)))
                .ForMember(dto => dto.JoiningDate,
                    opt => opt.MapFrom(m => DateTimeFormatter.StringToDate(m.JoiningDate)));
        }
    }
}
