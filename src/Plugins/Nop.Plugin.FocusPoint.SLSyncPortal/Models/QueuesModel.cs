using System.Collections.Generic;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.FocusPoint.SLSyncPortal.Models
{
    public record class QueuesModel : BaseNopModel
    {
        public QueuesFilterModel Filter { set; get; }
        public IList<QueuesItem>  Items { set; get; }
        public int CurrentPage { set; get; }
        public int PageSize  { set; get; }
        public int TotalPages   { set; get; }
        
    }
}