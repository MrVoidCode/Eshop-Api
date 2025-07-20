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

        public Slider(string title, string imageName, string link, bool isActive)
        {
            Guard(title, imageName, link);
            Title = title;
            ImageName = imageName;
            Link = link;
            IsActive = false;
        }

        public void Guard(string title, string imageName, string link)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
        }

        public void edit(string title, string imageName, string link)
        {
            Guard(title, imageName, link);
            Title = title;
            ImageName = imageName;
            Link = link;
        }

        public void SetActive()
        {
            IsActive = true;
        }
    }
}
