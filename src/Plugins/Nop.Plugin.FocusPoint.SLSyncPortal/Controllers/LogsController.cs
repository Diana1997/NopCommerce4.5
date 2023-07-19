using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.FocusPoint.SLSyncPortal.Services;
using Nop.Services.Configuration;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.FocusPoint.SLSyncPortal.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [Route("Admin/SLSyncPortal/[controller]/[action]")]
    public class LogsController : BasePluginController
    {
        private readonly IHttpService _httpService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly SLSyncPortalPluginSettings _settings;

        public LogsController(
            IHttpService httpService, 
            ISettingService settingService, 
            IStoreContext storeContext, SLSyncPortalPluginSettings settings)
        {
            _httpService = httpService;
            _settingService = settingService;
            _storeContext = storeContext;
            _settings = settings;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
          //  var settings = GetSettings();
            var response = await _httpService.Get<IList<string>>($"{_settings.Url}/portal/log", CancellationToken.None);
            
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Logs/Index.cshtml", response);
        }
        
        /*private SLSyncPortalPluginSettings GetSettings()
        {
            int storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var settings = _settingService.LoadSetting<SLSyncPortalPluginSettings>(storeScope);
            return settings;
        }*/
    }
}