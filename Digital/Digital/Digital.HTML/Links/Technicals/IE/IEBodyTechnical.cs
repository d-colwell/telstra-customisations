using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Html.IE;

namespace Digital.HTML.Links.Technicals.IE
{
    [SupportedTechnicalTypeName("IE:BODY")]
    public class IEBodyTechnical : IEElementTechnical, IHtmlBodyTechnical
    {
        public IEBodyTechnical(IIEContentObjectManager objectManager, Validator validator) : base(objectManager, validator)
        {
        }
    }
}
