using ShortestRouteOptimizer.Data.Loaders;
using ShortestRouteOptimizer.Service.Services;

namespace ShortestRouteOptimizer.Test
{
    public class PathOptimizerServiceTests
    {
        private readonly PathOptimizerService _pathOptimizerService;

        public PathOptimizerServiceTests()
        {
            _pathOptimizerService = new PathOptimizerService();
        }

        /// <summary>
        /// Tests that the ShortestPath method returns the correct path and distance when a path exists between the nodes.
        /// </summary>
        [Fact]
        public void ShortestPath_ReturnsCorrectPath_WhenPathExists()
        {
            // Arrange
            var graphNodes = GraphDataLoader.GetNodeGraphData();
            var fromNodeName = "A";
            var toNodeName = "D";

            // Act
            var result = _pathOptimizerService.ShortestPath(fromNodeName, toNodeName, graphNodes);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(11, result.Distance);
            Assert.Equal(new List<string> { "A", "B", "F", "G", "D" }, result.NodeNames);
        }

        /// <summary>
        /// Tests that the ShortestPath method returns null when no path exists between the nodes.
        /// </summary>
        [Fact]
        public void ShortestPath_ReturnsNull_WhenPathDoesNotExist()
        {
            // Arrange
            var graphNodes = GraphDataLoader.GetNodeGraphData();
            var fromNodeName = "A";
            var toNodeName = "X";

            // Act
            var result = _pathOptimizerService.ShortestPath(fromNodeName, toNodeName, graphNodes);

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Tests that the ShortestPath method returns a path with a distance of zero when the start and end nodes are the same.
        /// </summary>
        [Fact]
        public void ShortestPath_ReturnsCorrectPath_WhenStartAndEndNodesAreSame()
        {
            // Arrange
            var graphNodes = GraphDataLoader.GetNodeGraphData();
            var fromNodeName = "A";
            var toNodeName = "A";

            // Act
            var result = _pathOptimizerService.ShortestPath(fromNodeName, toNodeName, graphNodes);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Distance);
            Assert.Equal(new List<string> { "A" }, result.NodeNames);
        }
    }
}