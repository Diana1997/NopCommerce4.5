﻿using System;

namespace Nop.Plugin.FocusPoint.SLSyncPortal.Models
{
    public class QueuesFilterModel
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Type { get; set; }
        public string Key { get; set; }
    }
    
}