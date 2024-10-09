using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Services.Mapper.Profiles;

namespace Services.Mapper
{
    public class ProfileFactory: Profile
    {
        public static Type[] GetAllAsTypes()
        {
            return new Type[]
            {
                typeof(EntityToDtoProfile)
            };
        }
    }
}
