using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Attributes;
using Tricentis.Automation.Engines.Technicals.Html.Chrome;

namespace Digital.HTML.Links.Technicals.Chrome
{
    [SupportedTechnicalTypeName("Chrome:BODY")]
    public class ChromeBodyTechnical : ChromeElementTechnical, IHtmlBodyTechnical
    {
        public ChromeBodyTechnical(ChromeContentObjectManager contentObjectManager, Validator validator) : base(contentObjectManager, validator)
        {
        }
    }
}
