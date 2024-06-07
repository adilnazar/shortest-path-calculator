using Microsoft.AspNetCore.Mvc;
using ShortestRouteOptimizer.Data.Loaders;
using ShortestRouteOptimizer.Models.Models;
using ShortestRouteOptimizer.Service.Interfaces;

namespace ShortestRouteOptimizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PathController : ControllerBase
    {
        private readonly IPathOptimizerService _pathOptimizerService;

        public PathController(IPathOptimizerService pathOptimizerService)
        {
            _pathOptimizerService = pathOptimizerService;
        }

        /// <summary>
        ///  Gets the shortest path between two nodes.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ShortestPathData> GetShortestPath([FromBody] PathRequest request)
        {
            var graphNodes = GraphDataLoader.GetNodeGraphData();
            var result = _pathOptimizerService.ShortestPath(request.FromNode, request.ToNode, graphNodes);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
