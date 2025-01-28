using AutoMapper;
using BookshopApi.Models;
using BookshopApi.Requests;

namespace BookshopApi.Profiles
{
    public class Profiles:Profile
    {
        public Profiles() 
        { 
            CreateMap<AddBook, Book>().ReverseMap();
        }
    }
}
