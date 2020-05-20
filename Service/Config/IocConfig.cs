using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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


            var typeBase = typeof(IDependency);
           
            builder.RegisterAssemblyTypes(GetDIAssembly()).Where(t=>typeBase.IsAssignableFrom(t)&&t!=typeBase&&!t.IsAbstract).PublicOnly().AsImplementedInterfaces().InstancePerLifetimeScope();
           
        }


        /// <summary>
        /// 过滤掉系统程序集
        /// </summary>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        private Assembly[] GetDIAssembly() 
        {
            
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => !Regex.IsMatch(assembly.FullName, "^System|^mscorlib|^Microsoft|^AutoMapper|^Newtonsoft|^Autofac"))
                .ToArray();
            return assemblies;

        }
        
    }
}
