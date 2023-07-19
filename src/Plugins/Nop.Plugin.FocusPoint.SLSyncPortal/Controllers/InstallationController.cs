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
    public class InstallationController :  BasePluginController
    {
        private readonly  ISettingService _settingService;
        private readonly IHttpService _httpService;
        private readonly SLSyncPortalPluginSettings _settings;

        public InstallationController(
            ISettingService settingService,
            IStoreContext storeContext, 
            IHttpService httpService, SLSyncPortalPluginSettings settings)
        {
            _httpService = httpService;
            _settings = settings;
            _settingService = settingService;
            //_settings = settingService.LoadSettingAsync<SLSyncPortalPluginSettings>(storeContext.ActiveStoreScopeConfiguration);
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Installations/Index.cshtml");
        }


        [HttpGet]
        public async Task<IActionResult> CreateUo()
        {
            
            var response = await _httpService.Get($"{_settings.Url}/portal/install/Create.UO", CancellationToken.None, true);
            return Json(response);
        }
        
        [HttpGet]
        public async Task<IActionResult> InstallWs1()
        {
            var response = await _httpService.Get($"{_settings.Url}/portal/install/WS1", CancellationToken.None);
            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> StoredProcedures()
        {
            var response = await _httpService.Get($"{_settings.Url}/portal/install/StoredProcedures", CancellationToken.None);
            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> EventUDT()
        {
            var response = await _httpService.Get($"{_settings.Url}/portal/install/PTN", CancellationToken.None);
            return Json(response);
        }
        
    }
}