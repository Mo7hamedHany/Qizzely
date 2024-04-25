using AutoMapper;
using Quizzely.Core.DataTransferObjects;
using Quizzely.Core.Models;

namespace Qizzely.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Exam, ExamDto>().ReverseMap();

            CreateMap<McqQuestion, McqDto>()
               .ForMember(d => d.ExamName, o => o.MapFrom(s => s.Exam.Name));

            CreateMap<TofQuestion, TofDto>()
               .ForMember(d => d.ExamName, o => o.MapFrom(s => s.Exam.Name));
        }
    }
}
