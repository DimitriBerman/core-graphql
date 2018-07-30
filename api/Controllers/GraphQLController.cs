using System;
using System.Threading.Tasks;
using MusicStore.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MusicStore.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        ILogger<GraphQLController> _logger;

        public GraphQLController(IDocumentExecuter documentExecuter,ISchema schema, ILogger<GraphQLController> logger)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            _logger.LogInformation($"GraphQLQuery.POST at : {DateTime.UtcNow}", query);

            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var executionOptions = new ExecutionOptions { 
                Schema = _schema, 
                Query = query.Query ,
                Inputs = query.Variables.ToInputs()
            };

            try
            {
                var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

                if (result.Errors?.Count > 0)
                {
                    _logger.LogError("GraphQLQuery.Post.Error > 0 (BadRequest)", result.Errors, query);
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                 _logger.LogError(ex, "GraphQLQuery.Post.Catch (BadRequest)", query);
                return BadRequest(ex);
            }
        }
    }
}