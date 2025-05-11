using System.Text;

namespace IPE.SmsIrClient.Routes
{
    /// <summary>
    /// Provides route definitions for receiving SMS messages.
    /// </summary>
    internal static class ReceiveRoutes
    {
        /// <summary>
        /// Gets the route to fetch the latest received messages.
        /// </summary>
        /// <param name="count">The number of messages to retrieve.</param>
        /// <returns>API route for latest received messages.</returns>
        internal static string GetLatestReceivesRoute(int count) => $"receive/latest?count={count}";

        /// <summary>
        /// Gets the route to fetch live received messages with pagination and sorting.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The number of messages per page.</param>
        /// <param name="sortByNewest">Determines if results should be sorted by newest first.</param>
        /// <returns>API route for live received messages.</returns>
        internal static string GetLiveReceivesRoute(int pageNumber, int pageSize, bool sortByNewest)
            => $"receive/live?pageNumber={pageNumber}&pageSize={pageSize}&sortByNewest={sortByNewest}";

        /// <summary>
        /// Gets the route to fetch archived received messages with optional date filtering.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination.</param>
        /// <param name="pageSize">The number of messages per page.</param>
        /// <param name="fromDate">Optional start date for filtering.</param>
        /// <param name="toDate">Optional end date for filtering.</param>
        /// <returns>API route for archived received messages.</returns>
        internal static string GetArchivedReceivesRoute(int pageNumber, int pageSize, int? fromDate, int? toDate)
        {
            var uriBuilder = new StringBuilder($"receive/archive?pageNumber={pageNumber}&pageSize={pageSize}");

            if (fromDate.HasValue)
                uriBuilder.Append($"&fromDate={fromDate.Value}");

            if (toDate.HasValue)
                uriBuilder.Append($"&toDate={toDate.Value}");

            return uriBuilder.ToString();
        }

        /// <summary>
        /// Gets the route for counting total received messages.
        /// </summary>
        /// <returns>API route for count of received messages.</returns>
        internal static string GetReceivedCountRoute() => "receive/count";

        /// <summary>
        /// Gets the route to retrieve message details by message ID.
        /// </summary>
        /// <param name="messageId">The ID of the message.</param>
        /// <returns>API route to get a message by ID.</returns>
        internal static string GetReceiveByIdRoute(int messageId) => $"receive/{messageId}";

        /// <summary>
        /// Gets the route to search received messages by mobile number.
        /// </summary>
        /// <param name="mobile">The mobile number to search messages for.</param>
        /// <returns>API route for searching received messages by mobile.</returns>
        internal static string GetReceivedByMobileRoute(string mobile) => $"receive/byMobile?mobile={mobile}";
    }
}
