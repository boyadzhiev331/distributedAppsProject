using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SR.MVCWebSite.ViewModels.Shared
{
    public abstract class BaseIndexVM<TEntityDTO>
        where TEntityDTO : class, new()
    {
        public List<TEntityDTO> Items { get; set; }
    }
}