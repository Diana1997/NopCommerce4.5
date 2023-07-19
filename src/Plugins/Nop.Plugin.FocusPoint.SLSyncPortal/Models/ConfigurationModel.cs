using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.FocusPoint.SLSyncPortal.Models
{
    public  record class ConfigurationModel : BaseNopModel
    {
        [Required]
        public string Url { set; get; }
    }
}