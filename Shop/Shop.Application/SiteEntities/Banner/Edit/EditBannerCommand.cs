using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Banner.Edit
{
    public class EditBannerCommand : IBaseCommand
    {
        public EditBannerCommand(long bannerId, string link, IFormFile? imageFile, BannerPosition position)
        {
            BannerId = bannerId;
            Link = link;
            ImageFile = imageFile;
            Position = position;
        }
        public long BannerId { get; private set; }
        public string Link { get; private set; }
        public IFormFile? ImageFile { get; private set; }
        public BannerPosition Position { get; private set; }
    }
}
