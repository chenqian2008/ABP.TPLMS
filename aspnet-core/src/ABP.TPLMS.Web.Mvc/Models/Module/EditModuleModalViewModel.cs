using System.Collections.Generic;
using System.Linq;
using ABP.TPLMS.Modules.Dto;

namespace ABP.TPLMS.Web.Models.Module
{
    public class EditModuleModalViewModel
    {
        public CreateUpdateModuleDto Module { get; set; }

        public IReadOnlyList<ModuleDto> Modules { get; set; }

    }
}