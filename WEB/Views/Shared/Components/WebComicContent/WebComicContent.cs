using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Views.Shared.Components.WebComic
{
    [ViewComponent(Name = "WebComicContent")]
    public class WebComicContentViewComponent: ViewComponent
    {
        public WebComicContentViewComponent()
        { }

        public async Task<IViewComponentResult> InvokeAsync(Domain.Model.WebComic webComic )        
        {
            return View(webComic);
        }
    }
}
