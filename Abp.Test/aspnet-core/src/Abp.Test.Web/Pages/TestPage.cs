﻿using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.Test.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Abp.Test.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits Abp.Test.Web.Pages.TestPage
     */
    public abstract class TestPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<TestResource> L { get; set; }
    }
}
