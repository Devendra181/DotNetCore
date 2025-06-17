using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastrucure services to the dependecy injection container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection
            AddCore(this IServiceCollection services)
        {
            //TO DO: Add services to the IoC container
            //Infrasture services often include data access, caching and othre low-level components.

            services.AddTransient<IUsersService, UsersService>();
            return services;
        }


    }
}
