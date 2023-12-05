using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.Core.AutoMapperConfigurations
{
    public class AutoMapperConfigurations
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            x.AddProfile<MappingsProfile>());
        }
    }
}
