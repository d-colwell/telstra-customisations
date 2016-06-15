using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Tricentis.Automation.AutomationInstructions.TestActions;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines;
using Tricentis.Automation.Engines.SpecialExecutionTasks;
using Tricentis.Automation.Engines.SpecialExecutionTasks.Attributes;

namespace RMSSET
{
    [SpecialExecutionTaskName("UrlValidator")]
    public class UrlValidator : SpecialExecutionTask
    {
        public UrlValidator(Validator validator) : base(validator)
        {
        }

        public override ActionResult Execute(ISpecialExecutionTaskTestAction testAction)
        {
            var urlsParam = testAction.GetParameterAsInputValue("URLs", false);
            var delimeterParam = testAction.GetParameterAsInputValue("Delimeter", true);
            var threadsParam = testAction.GetParameterAsInputValue("Threads", true);

            List<string> errors = new List<string>();
            string urls = string.Empty;
            string delimeter = ";";
            int threads = 8;

            if (threadsParam != null && !string.IsNullOrEmpty(threadsParam.Value))
                threads = int.Parse(threadsParam.Value);

            if (delimeterParam != null && !string.IsNullOrEmpty(delimeterParam.Value))
                delimeter = delimeterParam.Value;

            if (string.IsNullOrEmpty(urlsParam.Value))
                return new PassedActionResult("No URLS provided");
            urls = urlsParam.Value;
            string[] urlArray = urls.Split(new string[] { delimeter }, StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> distinctUrls = new HashSet<string>();

            foreach (var url in urlArray)
            {
                distinctUrls.Add(url);
            }
            var distinctURLParalell = distinctUrls.AsParallel();
            threads = Math.Min(distinctUrls.Count / 2, threads);
            if (threads == 0)
                threads = 1;

            var results = (from url in distinctURLParalell.WithDegreeOfParallelism(threads)
                           select EvaluateURL(url)).ToList();

            if (results.Any(x => x.IsError))
            {
                var errorTexts = results.Where(x => x.IsError).Select(x => string.Format("Result: {0} | URL: {1}", x.Status, x.URL));
                return new NotFoundFailedActionResult(
                    string.Format("{0} URL(s) failed to resolve", errorTexts.Count()), errorTexts.Aggregate((x, y) => string.Format("{0}\r\n{1}", x, y)));
            }
            else
            {

                return new PassedActionResult(string.Format("All {0} URL(s) resolve successfuly",results.Count),
                    results.Select(r => string.Format("Result: {0} | URL: {1}",r.Status, r.URL)).Aggregate((x,y) => string.Format("{0}\r\n{1}",x,y)),string.Empty);
            }
        }

        private EvaluationResult EvaluateURL(string url)
        {
            var request = WebRequest.Create(url);
            int code = 404;
            var result = new EvaluationResult { URL = url, IsError = false };
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                code = (int)response.StatusCode;
            }
            catch (Exception)
            {
                //eat all the exceptions... nom nom nom
            }
            result.Status = code.ToString();
            if (code > 400)
            {
                result.IsError = true;
            }
            return result;
        }
    }

    class EvaluationResult
    {
        public string Status { get; set; }
        public string URL { get; set; }
        public bool IsError { get; set; }
    }
}
