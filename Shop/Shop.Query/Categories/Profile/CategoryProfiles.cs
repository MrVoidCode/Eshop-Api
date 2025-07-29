using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.Profiles
{
    internal class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, ChildCategoryDto>();
        }
    }
}
