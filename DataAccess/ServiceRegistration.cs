using Core.DataAccess;
using Core.Entities;
using DataAccess.Abstract.Chat;
using DataAccess.Abstract.ChatMember;
using DataAccess.Abstract.Message;
using DataAccess.Concrete;
using DataAccess.Concrete.Chat;
using DataAccess.Concrete.ChatMember;
using DataAccess.Concrete.Message;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddDbContext<Context>();
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<Context>();


            services.AddScoped<IMessageReadRepository, MessageReadRepository>();
            services.AddScoped<IMessageWriteRepository,MessageWriteRepository>();

            services.AddScoped<IChatReadRepository,ChatReadRepository>();
            services.AddScoped<IWriteChatRepository,ChatWriteRepository>();

            services.AddScoped<IChatMemberReadRepository,ChatMemberReadRepository>();
            services.AddScoped<IChatMemberWriteRepository,ChatMemberWriteRepository>();

        }
    }
}
