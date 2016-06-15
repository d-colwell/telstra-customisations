using Digital.HTML.Links.Technicals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.Engines.Adapters.Attributes;
using Tricentis.Automation.Engines.Adapters.Html;
using Tricentis.Automation.Engines.Adapters.Html.Generic;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals.Html;

namespace Digital.HTML.Links.Adapters
{

    [SupportedTechnical(typeof(IHtmlBodyTechnical))]
    public class HtmlBodyAdapter : AbstractHtmlDomNodeAdapter<IHtmlBodyTechnical>, IHtmlElementAdapter<IHtmlBodyTechnical>
    {
        public HtmlBodyAdapter(IHtmlBodyTechnical technical, Validator validator) : base(technical, validator)
        {
        }
    }
}
