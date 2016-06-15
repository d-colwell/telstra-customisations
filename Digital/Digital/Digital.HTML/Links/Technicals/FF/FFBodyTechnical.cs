using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Html.FF;

namespace Digital.HTML.Links.Technicals.FF
{

    [SupportedTechnicalTypeName("FF:BODY")]
    public class FFBodyTechnical : FFElementTechnical, IHtmlBodyTechnical
    {
        public FFBodyTechnical(FFContentObjectManager contentObjectManager, Validator validator) : base(contentObjectManager, validator)
        {
        }
    }
}
