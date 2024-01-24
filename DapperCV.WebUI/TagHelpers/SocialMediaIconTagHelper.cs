using AutoMapper;
using DapperCV.Business.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DapperCV.WebUI.TagHelpers
{
    //sosyal medya ikonlarını getirmek için tanımlandı
    [HtmlTargetElement("GetIcons")] //<geticons></geticons> şeklinde yazımı sağlar
    public class SocialMediaIconTagHelper:TagHelper
    {
        private readonly IAppUserService _appUserService;
        private readonly ISocialMediaIconService _socialMediaIconService;
        private readonly IMapper _mapper;

        public SocialMediaIconTagHelper(IAppUserService appUserService, ISocialMediaIconService socialMediaIconService, IMapper mapper)
        {
            _appUserService = appUserService;
            _socialMediaIconService = socialMediaIconService;
            _mapper = mapper;
        }

        public int AppUserId { get; set; }



        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var icons= _socialMediaIconService.GetByUserIdService(AppUserId);
            string data = $"<div class='social-icons'>";

            foreach (var item in icons)
            {
                //data += $@"<a class='social-icon' href='{item.Link}'><i class='fab fa-linkedin-in'></i></a>";
                data += $@"<a class='social-icon' href='{item.Link}'><i class='{item.Icon}'></i></a>";
            }

            data += "</div>";

            output.Content.SetHtmlContent(data);
        }
    }
}
