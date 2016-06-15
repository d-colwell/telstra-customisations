using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.Engines.Representations.Attributes;
using Tricentis.Automation.Engines.Adapters.Controllers;
using Digital.HTML.Links.Adapters;
using Tricentis.Automation.Engines;
using Tricentis.Automation.Engines.Adapters;
using Tricentis.Automation.AutomationInstructions.TestActions;
using Tricentis.Automation.Creation;
using Tricentis.Automation.AutomationInstructions.TestActions.Associations;

namespace Digital.HTML.Links.Controllers
{
    [SupportedAdapter(typeof(Adapters.HtmlBodyAdapter))]
    public class HtmlBodyAdapterController : ContextAdapterController<Adapters.HtmlBodyAdapter>//  IContextAdapterController<Adapters.HtmlBodyAdapter>// IHtmlElementAdapterController<Adapters.HtmlBodyAdapter>
    {
        public HtmlBodyAdapterController(HtmlBodyAdapter contextAdapter, ISearchQuery query, Validator validator) : base(contextAdapter, query, validator)
        {
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ParentBusinessAssociation businessAssociation)
        {
            yield return new TechnicalAssociation("ParentNode");
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ChildrenBusinessAssociation businessAssociation)
        {
            yield return new TechnicalAssociation("Children");
        }
    }
}
