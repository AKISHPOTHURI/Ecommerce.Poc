using AutoMapper;
using Ecommerce.Api.ModelDTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Common.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<System.Data.DataRow, CartDTO>()
                .ForMember(a => a.quantity, s => s.MapFrom(s => (int)s.ItemArray[1]))
                .ForMember(a => a.productName, s=>s.MapFrom(s=>s.ItemArray[2].ToString()))
                .ForMember(a=>a.description,s=>s.MapFrom(s=>s.ItemArray[3].ToString()))
                .ForMember(a=>a.price,s=>s.MapFrom(s=>s.ItemArray[4].ToString()))
                .ForMember(a=>a.imageurl,s=>s.MapFrom(s=>s.ItemArray[5].ToString()))
                .ForMember(a=>a.colour,s=>s.MapFrom(s=>s.ItemArray[6].ToString()))
                .ForMember(a=>a.category,s=>s.MapFrom(s=>s.ItemArray[7].ToString()))
                .ReverseMap();

            CreateMap<System.Data.DataRow, ProductsDTO>()
                .ForMember(a => a.productId, s => s.MapFrom(s => (int)s.ItemArray[0]))
                .ForMember(a => a.sellerID, s => s.MapFrom(s => (int)s.ItemArray[1]))
                .ForMember(a => a.sellerName, s => s.MapFrom(s => s.ItemArray[2].ToString()))
                .ForMember(a => a.productName, s => s.MapFrom(s => s.ItemArray[3].ToString()))
                .ForMember(a => a.price, s => s.MapFrom(s => s.ItemArray[4].ToString()))
                .ForMember(a => a.colour, s => s.MapFrom(s => s.ItemArray[5].ToString()))
                .ForMember(a => a.category, s => s.MapFrom(s => s.ItemArray[6].ToString()))
                .ForMember(a => a.description, s => s.MapFrom(s => s.ItemArray[7].ToString()))
                .ForMember(a => a.image, s => s.MapFrom(s => s.ItemArray[8].ToString()))
                .ReverseMap();
        }
    }
}
