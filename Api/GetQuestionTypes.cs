using Api.Helper;
using Api.Model;

using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using System.Linq;

namespace Cloudies.Function
{
    public class GetQuestionTypes
    {
        [FunctionName("GetQuestionTypes")]
        public QuestionType[] Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            QuestionType[] questionTypes = OTDBHelper.GetQuestionTypes()
                .Select(x => new QuestionType { Id = x.id, Name = x.name })
                .ToArray();
            return questionTypes;
        }
    }
}
