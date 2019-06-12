using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SR.MVCWebSite.ViewModels.Shared
{
    public abstract class BaseEditVM<TEntityDTO>
        where TEntityDTO : class, new()
    {
        public abstract void PopulateEntityDTO(TEntityDTO item);
        public abstract void PopulateModel(TEntityDTO item);
    }
}