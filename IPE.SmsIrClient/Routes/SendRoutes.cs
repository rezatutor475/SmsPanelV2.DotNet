using System;
using System.Text;

namespace IPE.SmsIrClient.Routes
{
    /// <summary>
    /// Contains route definitions related to sending messages.
    /// </summary>
    internal static class SendRoutes
    {
        /// <summary>
        /// Route for bulk message sending.
        /// </summary>
        internal static string BulkSendRoute() => "send/bulk";

        /// <summary>
        /// Route for like-to-like message sending.
        /// </summary>
        internal static string LikeToLikeSendRoute() => "send/likeTolike";

        /// <summary>
        /// Route for removing scheduled messages by pack ID.
        /// </summary>
        internal static string RemoveScheduledMessagesRoute(Guid packId) => $"send/scheduled/{packId}";

        /// <summary>
        /// Route for verifying message sends.
        /// </summary>
        internal static string VerifySendRoute() => "send/verify";

        /// <summary>
        /// Route for retrieving delivery status of a specific message.
        /// </summary>
        internal static string GetMessageStatusRoute(int messageId) => $"send/status/{messageId}";

        /// <summary>
        /// Route for cancelling a scheduled message send by pack ID.
        /// </summary>
        internal static string CancelScheduledSendRoute(Guid packId) => $"send/scheduled/cancel/{packId}";

        /// <summary>
        /// Route for retrieving delivery status of multiple messages in a pack.
        /// </summary>
        internal static string GetPackStatusRoute(Guid packId) => $"send/pack/status/{packId}";

        /// <summary>
        /// Route for sending a quick message with minimal parameters.
        /// </summary>
        internal static string QuickSendRoute() => "send/quick";

        /// <summary>
        /// Route for retrieving the history of sent messages.
        /// </summary>
        internal static string GetSendHistoryRoute(int pageNumber, int pageSize)
        {
            var uriBuilder = new StringBuilder("send/history");
            uriBuilder.Append($"?pageNumber={pageNumber}&pageSize={pageSize}");
            return uriBuilder.ToString();
        }
    }
}
