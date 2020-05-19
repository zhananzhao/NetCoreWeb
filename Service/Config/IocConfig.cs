using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using CoreTools;

namespace Service.Config
{
    public class IocConfig:Autofac.Module
    {


        /// <summary>Override to add registrations to the container.</summary>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        protected override void Load(ContainerBuilder builder)
        {

            //builder.RegisterAssemblyTypes()
            //Type typeBase = typeof(IDependency);
            //Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies().Where<Assembly>(t=>t.);
            
            //builder.RegisterAssemblyTypes()
        }

        
    }
}
