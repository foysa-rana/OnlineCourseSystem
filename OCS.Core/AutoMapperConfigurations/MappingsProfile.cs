using AutoMapper;
using OCS.Core.CommonModel;
using OCS.Core.Model.CourseModel;
using OCS.Core.Model.SeminarModel;
using OCS.Core.Model.SignUpModel;
using OCS.Core.Model.TrainerModel;
using OCS.Core.Model.VideoModel;
using OCS.Core.ViewModel.CourseViewModel;
using OCS.Core.ViewModel.SeminarViewModel;
using OCS.Core.ViewModel.SignUpViewModel;
using OCS.Core.ViewModel.TrainerViewModel;
using OCS.Core.ViewModel.VideosViewModel;
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

            CreateMap<UserSignUp, UserSignUpView>()
               .ForMember(vm => vm.BirthDate,
                   opt => opt.MapFrom(m => DateTimeFormatter.DateToString(m.BirthDate)));

            CreateMap<UserSignUpView, UserSignUp>()
                .ForMember(dto => dto.BirthDate,
                    opt => opt.MapFrom(m => DateTimeFormatter.StringToDate(m.BirthDate)));

            CreateMap<Videos, VideosView>();
            CreateMap<VideosView, Videos>();
        }
    }
}
