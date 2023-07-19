using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.FocusPoint.SLSyncPortal
{
    public class SLSyncPortalPlugin  : BasePlugin, IWidgetPlugin
    {
        private readonly IWebHelper _webHelper;

        public SLSyncPortalPlugin(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }
        
        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/SLSyncPortal/Configure";
        }
        

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return "SLSyncPortal";
        }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageTop });
        }

        public bool HideInWidgetList => false;

    } 
}