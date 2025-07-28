using Common.Application;
using Microsoft.AspNetCore.Http;
using Shop.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Slider.Create
{
    internal class CreateSliderCommand : IBaseCommand
    {
        public CreateSliderCommand(string link, IFormFile imageFile, string title)
        {
            Link = link;
            ImageFile = imageFile;
            Title = title;
        }
        public string Title { get; private set; }
        public string Link { get; private set; }
        public IFormFile ImageFile { get; private set; }
    }
}
