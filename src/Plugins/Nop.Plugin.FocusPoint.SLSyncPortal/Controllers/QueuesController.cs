using System;
using System.Collections.Generic;
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
    [Route("Admin/SLSyncPortal/[controller]/[action]")]
    public class QueuesController : BasePluginController
    {
        private const int MAX_PAGING_ELEMENTS = 5;
        private readonly IHttpService _httpService;
        private readonly  SLSyncPortalPluginSettings _settings;

        public QueuesController(
            ISettingService settingService,
            IStoreContext storeContext, 
            IHttpService httpService, SLSyncPortalPluginSettings settings)
        {
            _httpService = httpService;
            _settings = settings;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 25, [FromQuery] QueuesFilterModel filter = null)
        {
            
           var result = await _httpService.Get<IList<QueuesItem>>($"{_settings.Url}//portal/queue?page-number={page}&page-size={pageSize}",
               CancellationToken.None);

           var totalCountResponse = await _httpService.Get<QueueCountResponse>($"{_settings.Url}//portal/queue/count", CancellationToken.None);

           var model = new QueuesModel();
            model.Items = result;//allItems.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            model.CurrentPage = page;
            model.PageSize = pageSize;
            model.TotalPages = (int)Math.Ceiling((decimal) totalCountResponse.Count / pageSize);
            model.ItemsCount = totalCountResponse.Count;
            
            
            
            model.StartPage  = Math.Max(1, page - MAX_PAGING_ELEMENTS / 2);
           model.EndPage = Math.Min(model.TotalPages,  model.StartPage + MAX_PAGING_ELEMENTS - 1);
            //portal/queue/count 
            return View("~/Plugins/FocusPoint.SLSyncPortal/Views/Queues/Index.cshtml", model);
        }
        
        [HttpGet]
        public async Task<IActionResult> ClearQueue()
        {
            var response = await _httpService.Get($"{_settings.Url}/portal/clearQueue", CancellationToken.None);
            return Json(new { success = true, message = "Queue cleared" });
        }
    }
}