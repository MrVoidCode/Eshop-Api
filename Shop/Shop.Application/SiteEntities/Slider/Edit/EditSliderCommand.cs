using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.SiteEntities.Slider.Edit
{
    internal class EditSliderCommand : IBaseCommand
    {
        public EditSliderCommand(long sliderId, string title, string link, IFormFile? imageFile)
        {
            SliderId = sliderId;
            Title = title;
            Link = link;
            ImageFile = imageFile;
        }
        public long SliderId { get; private set; }
        public string Title { get; private set; }
        public string Link { get; private set; }
        public IFormFile? ImageFile { get; private set; }
    }   
}
