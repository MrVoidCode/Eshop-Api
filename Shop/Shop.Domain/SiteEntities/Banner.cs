using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SiteEntities
{
    public class Banner : BaseEntity
    {
        public string Link { get; private set; }
        public string ImageName { get; private set; }
        public BannerPosition Position { get; private set; }

        public Banner(string link, string imageName, BannerPosition position)
        {
            Guard(link, imageName);
            Link = link;
            ImageName = imageName;
            Position = position;
        }

        public void Guard(string link, string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
        }

        public void Edit(string link,  BannerPosition position)
        {
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
            Link = link;
            Position = position;
        }
        public void SetImage(string image)
        {
            NullOrEmptyDomainDataException.CheckString(image, nameof(image));
            ImageName = image;
        }
        
    }

    public enum BannerPosition
    {
        زیر_اسلایدر,
        سمت_راست_اسلایدر

    }
}
