using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Infrastructure.Persistent.Ef.CategoryAgg;
using Shop.Infrastructure.Persistent.Ef.CommentAgg;
using Shop.Infrastructure.Persistent.Ef.OrderAgg;
using Shop.Infrastructure.Persistent.Ef.ProductAgg;
using Shop.Infrastructure.Persistent.Ef.RoleAgg;
using Shop.Infrastructure.Persistent.Ef.SellerAgg;
using Shop.Infrastructure.Persistent.Ef.siteEntity.Banner;
using Shop.Infrastructure.Persistent.Ef.siteEntity.Slider;
using Shop.Infrastructure.Persistent.Ef.UsersAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CommentAgg.Repository;
using Shop.Domain.OrderAgg.Repository;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.RoleAgg.Repository;
using Shop.Domain.SellerAgg.Repository;
using Shop.Domain.SiteEntities.Repository;
using Shop.Domain.UserAgg.Repository;
using Shop.Infrastructure.Persistent.Dapper;

namespace Shop.Infrastructure
{
    internal class InfrastructureBootstrapper
    {
        public static void Init(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICategoryDomainRepository, CategoryRepository>();
            services.AddTransient<IOrderDomainRepository, OrderRepository>();
            services.AddTransient<IProductDomainRepository, ProductRepository>();
            services.AddTransient<IRoleDomainRepository, RoleRepository>();
            services.AddTransient<ISellerDomainRepository, SellerRepository>();
            services.AddTransient<IBannerDomainRepository, BannerRepository>();
            services.AddTransient<ISliderDomainRepository, SliderRepository>();
            services.AddTransient<IUserDomainRepository, UserRepository>();
            services.AddTransient<ICommentDomainRepository, CommentRepository>();
            

            services.AddTransient(_ => new DapperContext(connectionString));
            services.AddDbContext<ShopContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
        }
    }
}
