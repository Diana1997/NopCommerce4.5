using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.FocusPoint.SLSyncPortal.Models;
using Nop.Plugin.FocusPoint.SLSyncPortal.Responses;
using Nop.Plugin.FocusPoint.SLSyncPortal.Services;
using Nop.Services.Configuration;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.FocusPoint.SLSyncPortal.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class SLSyncPortalController :  BasePluginController
    {
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IHttpService _httpService;
        private readonly SLSyncPortalPluginSettings _settings;
        public SLSyncPortalController(
            ISettingService settingService,
            IStoreContext storeContext,
            IHttpService httpService,
            SLSyncPortalPluginSettings settings)
        {
            _settingService = settingService;
            _storeContext = storeContext;
            _httpService = httpService;
            _settings = settings;
        }

   
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            VersionResponse version = null;
            if(_settings != null)
            {
                version = await _httpService.Get<VersionResponse>($"{_settings.Url}/portal/settings/value",
                    CancellationToken.None);
            }

            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Index.cshtml", version);
        }
        
        [HttpGet]
        public IActionResult Configure()
        {
            var model = new ConfigurationModel()
            {
                Url = _settings.Url
            };
           return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Configure.cshtml", model);
        }

        
        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
                return Configure();
            
            await   _settingService.SaveSettingAsync(new SLSyncPortalPluginSettings
            {
                Url = model.Url
            });
            return Configure();
        }

        [Route("SLSyncPortal")]
        [HttpGet]
        public IActionResult Settings()
        {
           var url = _settings.Url;

            var request = WebRequest.Create(url);
            request.Method = "GET";
            string data = "init string";
            using(var response = request.GetResponse())
            {
                using(var sr = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(sr))
                    {
                         data = reader.ReadToEnd();
                    }
                               
                }
            }
            
            ViewBag.GetResponse = data;
            ViewBag.Content = data;
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Settings.cshtml");
        }
        
    }
}