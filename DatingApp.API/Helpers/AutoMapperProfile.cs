using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Helpers;
using DatingApp.API.Models;

namespace DatingApp
{

  public class AutoMapperProfile : Profile
  {

    public AutoMapperProfile()
    {
      CreateMap<User, UserForDetailedDto>()
        .ForMember(dest => dest.PhotoUrl, opt =>
        {
          opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
        })
        .ForMember(dest => dest.Age, opt =>
        {
          opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
        });

      CreateMap<User, UserForListDto>()
        .ForMember(dest => dest.PhotoUrl, opt =>
        {
          opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
        })
        .ForMember(dest => dest.Age, opt =>
        {
          opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
        });

      CreateMap<Photo, PhotosForDetailedDto>();

      CreateMap<UserForUpdateDto, User>();
    }

  }


}