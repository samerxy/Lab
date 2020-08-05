using AutoMapper;
using Labs.infrastructure;
using Labs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labs.Mapper
{
    public class Userprofile:Profile
    {
        public Userprofile()
        {
            CreateMap<CreateUser, User>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && srcMember.ToString() != ""));
        }
    }
}
