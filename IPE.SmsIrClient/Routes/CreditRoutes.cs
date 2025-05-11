namespace IPE.SmsIrClient.Routes
{
    /// <summary>
    /// Provides route definitions for credit-related API endpoints.
    /// </summary>
    internal static class CreditRoutes
    {
        /// <summary>
        /// Gets the route for retrieving account credit.
        /// </summary>
        /// <returns>The API endpoint string for checking credit.</returns>
        internal static string GetCreditRoute() => "credit";

        /// <summary>
        /// Gets the route for retrieving credit history.
        /// </summary>
        /// <returns>The API endpoint string for credit history.</returns>
        internal static string GetCreditHistoryRoute() => "credit/history";

        /// <summary>
        /// Gets the route for retrieving credit usage summary.
        /// </summary>
        /// <returns>The API endpoint string for credit usage summary.</returns>
        internal static string GetCreditUsageRoute() => "credit/usage";

        /// <summary>
        /// Gets the route for retrieving billing details.
        /// </summary>
        /// <returns>The API endpoint string for billing details.</returns>
        internal static string GetBillingDetailsRoute() => "credit/billing";
    }
}
