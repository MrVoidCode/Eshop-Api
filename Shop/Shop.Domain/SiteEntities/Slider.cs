using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SiteEntities
{
    public class Slider : BaseEntity
    {
        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Link { get; private set; }
        public bool IsActive { get; private set; }

        public Slider(string title, string imageName, string link)
        {
            Guard(title, link);
            Title = title;
            ImageName = imageName;
            Link = link;
            IsActive = false;
        }

        public void Guard(string title, string link)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
        }

        public void Edit(string title, string link)
        {
            Guard(title,link);
            Title = title;
            Link = link;
        }
        public void SetImage(string image)
        {
            NullOrEmptyDomainDataException.CheckString(image, nameof(image));
            ImageName = image;
        }

        public void SetActive()
        {
            IsActive = true;
        }
    }
}
