using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortestRouteOptimizer.Data.Interfaces;
using ShortestRouteOptimizer.Data.Loaders;
using ShortestRouteOptimizer.Models.Models;
using ShortestRouteOptimizer.Service.Interfaces;
using ShortestRouteOptimizer.Service.Services;

namespace ShortestRouteOptimizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PathController : ControllerBase
    {
        private readonly IGraphDataLoader _graphDataLoader;
        private readonly IPathOptimizerService _pathOptimizerService;

        public PathController(IPathOptimizerService pathOptimizerService, IGraphDataLoader graphDataLoader)
        {
            _graphDataLoader = graphDataLoader;
            _pathOptimizerService = pathOptimizerService;
        }

        [HttpPost]
        public ActionResult<ShortestPathData> GetShortestPath([FromBody] PathRequest request)
        {
            var graphNodes = _graphDataLoader.GetNodeGraphData();
            var result = _pathOptimizerService.ShortestPath(request.FromNode, request.ToNode, graphNodes);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
