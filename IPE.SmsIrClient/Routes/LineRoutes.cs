namespace IPE.SmsIrClient.Routes
{
    /// <summary>
    /// Provides route definitions for line-related API endpoints.
    /// </summary>
    internal static class LineRoutes
    {
        /// <summary>
        /// Gets the route for retrieving available SMS lines.
        /// </summary>
        /// <returns>The API endpoint string for fetching SMS lines.</returns>
        internal static string GetLinesRoute() => "line";

        /// <summary>
        /// Gets the route for retrieving details of a specific line.
        /// </summary>
        /// <param name="lineId">The ID of the line.</param>
        /// <returns>The API endpoint string for fetching details of the specified line.</returns>
        internal static string GetLineDetailsRoute(long lineId) => $"line/{lineId}";

        /// <summary>
        /// Gets the route for retrieving the status of a specific line.
        /// </summary>
        /// <param name="lineId">The ID of the line.</param>
        /// <returns>The API endpoint string for fetching the status of the specified line.</returns>
        internal static string GetLineStatusRoute(long lineId) => $"line/{lineId}/status";

        /// <summary>
        /// Gets the route for updating the configuration of a specific line.
        /// </summary>
        /// <param name="lineId">The ID of the line.</param>
        /// <returns>The API endpoint string for updating the specified line.</returns>
        internal static string UpdateLineConfigRoute(long lineId) => $"line/{lineId}/config";
    }
}
