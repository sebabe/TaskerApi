using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Persistence;

namespace API.Extentions
{
    public static class IdentityServiceExtencions
    {
        public static IServiceCollection AddIdentityServiceExtencions(this IServiceCollection services, IConfiguration config){
            services.AddIdentityCore<AppUser>(opt => {
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<DataContext>();
            services.AddAuthentication();
            return services;
        }
    }
}