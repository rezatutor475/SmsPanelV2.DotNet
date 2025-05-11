using IPE.SmsIrClient.Extensions;
using IPE.SmsIrClient.Models.Requests;
using IPE.SmsIrClient.Models.Results;
using IPE.SmsIrClient.Routes;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IPE.SmsIrClient
{
    public class SmsIr
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.sms.ir/v1/";

        public SmsIr(string apiKey)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }

        private async Task<SmsIrResult<T>> GetAsync<T>(string route) =>
            await _httpClient.GetRequestAsync<T>(route);

        private SmsIrResult<T> Get<T>(string route) =>
            _httpClient.GetRequest<T>(route);

        private async Task<SmsIrResult<T>> PostAsync<T>(string route, object body) =>
            await _httpClient.PostRequestAsync<T>(route, body);

        private SmsIrResult<T> Post<T>(string route, object body) =>
            _httpClient.PostRequest<T>(route, body);

        private async Task<SmsIrResult<T>> DeleteAsync<T>(string route) =>
            await _httpClient.DeleteRequestAsync<T>(route);

        private SmsIrResult<T> Delete<T>(string route) =>
            _httpClient.DeleteRequest<T>(route);

        public Task<SmsIrResult<decimal>> GetCreditAsync() => GetAsync<decimal>(CreditRoutes.GetCreditRoute());
        public SmsIrResult<decimal> GetCredit() => Get<decimal>(CreditRoutes.GetCreditRoute());

        public Task<SmsIrResult<long[]>> GetLinesAsync() => GetAsync<long[]>(LineRoutes.GetLinesRoute());
        public SmsIrResult<long[]> GetLines() => Get<long[]>(LineRoutes.GetLinesRoute());

        public Task<SmsIrResult<ReceivedMessageResult[]>> GetLatestReceivesAsync(int count = 100) =>
            GetAsync<ReceivedMessageResult[]>(ReceiveRoutes.GetLatestReceivesRoute(count));
        public SmsIrResult<ReceivedMessageResult[]> GetLatestReceives(int count = 100) =>
            Get<ReceivedMessageResult[]>(ReceiveRoutes.GetLatestReceivesRoute(count));

        public Task<SmsIrResult<ReceivedMessageResult[]>> GetLiveReceivesAsync(int page = 1, int size = 100, bool newest = false) =>
            GetAsync<ReceivedMessageResult[]>(ReceiveRoutes.GetLiveReceivesRoute(page, size, newest));
        public SmsIrResult<ReceivedMessageResult[]> GetLiveReceives(int page = 1, int size = 100, bool newest = false) =>
            Get<ReceivedMessageResult[]>(ReceiveRoutes.GetLiveReceivesRoute(page, size, newest));

        public Task<SmsIrResult<ReceivedMessageResult[]>> GetArchivedReceivesAsync(int page = 1, int size = 100, int? from = null, int? to = null) =>
            GetAsync<ReceivedMessageResult[]>(ReceiveRoutes.GetArchivedReceivesRoute(page, size, from, to));
        public SmsIrResult<ReceivedMessageResult[]> GetArchivedReceives(int page = 1, int size = 100, int? from = null, int? to = null) =>
            Get<ReceivedMessageResult[]>(ReceiveRoutes.GetArchivedReceivesRoute(page, size, from, to));

        public Task<SmsIrResult<SendResult>> BulkSendAsync(long line, string message, string[] mobiles, int? time = null) =>
            PostAsync<SendResult>(SendRoutes.BulkSendRoute(), new BulkSendRequest(line, message, mobiles, time));
        public SmsIrResult<SendResult> BulkSend(long line, string message, string[] mobiles, int? time = null) =>
            Post<SendResult>(SendRoutes.BulkSendRoute(), new BulkSendRequest(line, message, mobiles, time));

        public Task<SmsIrResult<SendResult>> LikeToLikeSendAsync(long line, string[] messages, string[] mobiles, int? time = null) =>
            PostAsync<SendResult>(SendRoutes.LikeToLikeSendRoute(), new LikeToLikeSendRequest(line, messages, mobiles, time));
        public SmsIrResult<SendResult> LikeToLikeSend(long line, string[] messages, string[] mobiles, int? time = null) =>
            Post<SendResult>(SendRoutes.LikeToLikeSendRoute(), new LikeToLikeSendRequest(line, messages, mobiles, time));

        public Task<SmsIrResult<RemoveScheduledMessagesResult>> RemoveScheduledMessagesAsync(Guid packId) =>
            DeleteAsync<RemoveScheduledMessagesResult>(SendRoutes.RemoveScheduledMessagesRoute(packId));
        public SmsIrResult<RemoveScheduledMessagesResult> RemoveScheduledMessages(Guid packId) =>
            Delete<RemoveScheduledMessagesResult>(SendRoutes.RemoveScheduledMessagesRoute(packId));

        public Task<SmsIrResult<VerifySendResult>> VerifySendAsync(string mobile, int templateId, VerifySendParameter[] parameters) =>
            PostAsync<VerifySendResult>(SendRoutes.VerifySendRoute(), new VerifySendRequest(mobile, templateId, parameters));
        public SmsIrResult<VerifySendResult> VerifySend(string mobile, int templateId, VerifySendParameter[] parameters) =>
            Post<VerifySendResult>(SendRoutes.VerifySendRoute(), new VerifySendRequest(mobile, templateId, parameters));

        public Task<SmsIrResult<MessageReportResult>> GetReportAsync(int messageId) =>
            GetAsync<MessageReportResult>(ReportRoutes.GetSingleMessageReportRoute(messageId));
        public SmsIrResult<MessageReportResult> GetReport(int messageId) =>
            Get<MessageReportResult>(ReportRoutes.GetSingleMessageReportRoute(messageId));

        public Task<SmsIrResult<MessageReportResult[]>> GetReportAsync(Guid packId) =>
            GetAsync<MessageReportResult[]>(ReportRoutes.GetPackReportRoute(packId));
        public SmsIrResult<MessageReportResult[]> GetReport(Guid packId) =>
            Get<MessageReportResult[]>(ReportRoutes.GetPackReportRoute(packId));

        public Task<SmsIrResult<MessageReportResult[]>> GetLiveReportAsync(int page = 1, int size = 100) =>
            GetAsync<MessageReportResult[]>(ReportRoutes.GetLiveReportRoute(page, size));
        public SmsIrResult<MessageReportResult[]> GetLiveReport(int page = 1, int size = 100) =>
            Get<MessageReportResult[]>(ReportRoutes.GetLiveReportRoute(page, size));

        public Task<SmsIrResult<MessageReportResult[]>> GetArchivedReportAsync(int page = 1, int size = 100, int? from = null, int? to = null) =>
            GetAsync<MessageReportResult[]>(ReportRoutes.GetArchivedReportRoute(page, size, from, to));
        public SmsIrResult<MessageReportResult[]> GetArchivedReport(int page = 1, int size = 100, int? from = null, int? to = null) =>
            Get<MessageReportResult[]>(ReportRoutes.GetArchivedReportRoute(page, size, from, to));

        public Task<SmsIrResult<PackResult[]>> GetSendPacksAsync(int page = 1, int size = 100) =>
            GetAsync<PackResult[]>(ReportRoutes.GetSendPacksRoute(page, size));
        public SmsIrResult<PackResult[]> GetSendPacks(int page = 1, int size = 100) =>
            Get<PackResult[]>(ReportRoutes.GetSendPacksRoute(page, size));
    }
}
