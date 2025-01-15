using AutoMapper;
using TheByteMagazine.Application.DTOs;
using TheByteMagazine.Application.Helpers;
using TheByteMagazine.Domain;
using TheByteMagazine.Domain.Entities;

namespace TheByteMagazine.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Issue, IssueDTO>()
            .ForMember(
            dest => dest.CoverImageUrl,
            (opt) => opt.MapFrom(src => $"{FileManager.IssuesCoverImagesPath}/{src.CoverImageUrl}")

            ).ReverseMap().ForMember(
            dest => dest.CoverImageUrl,
            (opt) => opt.MapFrom(src => Path.GetFileName(src.CoverImageUrl))
            );


        CreateMap<Contribution, IssueContributorDTO>()
            .ForCtorParam("fullName", (opt) => opt.MapFrom(src => $"{src.Volunteer.FirstName} {src.Volunteer.LastName}"))
            .ForCtorParam("personalImageUrl", (opt) =>  opt.MapFrom(src => 
                    string.IsNullOrEmpty(src.Volunteer.PersonalImagePath) 
                        ? null 
                        : $"{FileManager.VolunteersImagesPath}/{src.Volunteer.PersonalImagePath}"))
            .ForCtorParam("linkedInProfileUrl", (opt) => opt.MapFrom(src => src.Volunteer.LinkedInProfileUrl))
            .ForCtorParam("role", (opt) => opt.MapFrom(src => src.RoleType.Name));


        CreateMap<Volunteer, VolunteerWithContributionsDTO>()
            .ForMember(dest => dest.PersonalImagePath, opt =>
                opt.MapFrom(src => 
                    string.IsNullOrEmpty(src.PersonalImagePath) 
                        ? null 
                        : $"{FileManager.VolunteersImagesPath}/{src.PersonalImagePath}"));

        CreateMap<Volunteer, VolunteerDTO>()
            .ForMember(dest => dest.FullName, opt =>
                opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.PersonalImagePath, opt =>
                opt.MapFrom(src => 
                    string.IsNullOrEmpty(src.PersonalImagePath) 
                        ? null 
                        : $"{FileManager.VolunteersImagesPath}/{src.PersonalImagePath}"));

        CreateMap<Contribution, ContributionDTO>()
            .ForCtorParam("IssueId", (opt) => opt.MapFrom(src => src.IssueId))
            .ForCtorParam("IssueTitle", (opt) => opt.MapFrom(src => src.Issue.Title))
            .ForCtorParam("Role", (opt) => opt.MapFrom(src => src.RoleType.Name));

        CreateMap<PaginatedList<Issue>, PaginatedList<IssueDTO>>();
        CreateMap<PaginatedList<Volunteer>, PaginatedList<VolunteerDTO>>();

        CreateMap<Message, MessageDTO>();
        CreateMap<MessageDTO, Message>();

        CreateMap<ArticleDTO, Article>();
        CreateMap<Article, ArticleDTO>();

    }
}
