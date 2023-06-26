using AutoMapper;
using LMS_System.LMSSystym.Model.DTOs;
using LMS_System.LMSSystym.Models.Models;

namespace LMS_System.Helper.Mapper
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Courses, CoursesDTO>().ReverseMap();
            CreateMap<Document, DocumentDTO>().ReverseMap();
            CreateMap<Exam, ExamDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<Notification, NotificationDTO>().ReverseMap();
            CreateMap<PersionalDocument, PersionalDocumentDTO>().ReverseMap();
            CreateMap<Question, QuestionDTO>().ReverseMap();
            CreateMap<Roles, RoleDTO>().ReverseMap();
            CreateMap<Subject, SubjectDTO>().ReverseMap();
        }

    }
}
