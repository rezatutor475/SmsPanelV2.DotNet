using System;
using System.Text;

namespace IPE.SmsIrClient.Routes
{
    /// <summary>
    /// Provides route definitions for reporting-related SMS operations.
    /// </summary>
    internal static class ReportRoutes
    {
        /// <summary>
        /// Gets the route for a single message report.
        /// </summary>
        internal static string GetSingleMessageReportRoute(int messageId) => $"send/{messageId}";

        /// <summary>
        /// Gets the route for a report of a message pack.
        /// </summary>
        internal static string GetPackReportRoute(Guid packId) => $"send/pack/{packId}";

        /// <summary>
        /// Gets the route for live report data with pagination.
        /// </summary>
        internal static string GetLiveReportRoute(int pageNumber, int pageSize) => $"send/live?pageNumber={pageNumber}&pageSize={pageSize}";

        /// <summary>
        /// Gets the route for archived report data with optional date filtering.
        /// </summary>
        internal static string GetArchivedReportRoute(int pageNumber, int pageSize, int? fromDate, int? toDate)
        {
            var uriBuilder = new StringBuilder($"send/archive?pageNumber={pageNumber}&pageSize={pageSize}");

            if (fromDate.HasValue)
                uriBuilder.Append($"&fromDate={fromDate.Value}");

            if (toDate.HasValue)
                uriBuilder.Append($"&toDate={toDate.Value}");

            return uriBuilder.ToString();
        }

        /// <summary>
        /// Gets the route to retrieve a list of sent message packs with pagination.
        /// </summary>
        internal static string GetSendPacksRoute(int pageNumber, int pageSize) => $"send/pack?pageNumber={pageNumber}&pageSize={pageSize}";

        /// <summary>
        /// Gets the route to retrieve the delivery status summary of a pack.
        /// </summary>
        internal static string GetDeliveryStatusRoute(Guid packId) => $"send/status/{packId}";

        /// <summary>
        /// Gets the route for checking total count of messages sent in a date range.
        /// </summary>
        internal static string GetSentMessagesCountRoute(int? fromDate, int? toDate)
        {
            var uriBuilder = new StringBuilder("send/count");
            bool hasQuery = false;

            if (fromDate.HasValue)
            {
                uriBuilder.Append($"?fromDate={fromDate.Value}");
                hasQuery = true;
            }

            if (toDate.HasValue)
            {
                uriBuilder.Append(hasQuery ? "&" : "?");
                uriBuilder.Append($"toDate={toDate.Value}");
            }

            return uriBuilder.ToString();
        }
    }
}
