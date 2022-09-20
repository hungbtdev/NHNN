using FirebaseAdmin.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vinorsoft.Notify.Interface
{
    public interface IFCMService
    {
        Task<BatchResponse> SendAllAsync(IEnumerable<Message> messages);
        Task<BatchResponse> SendAllAsync(IEnumerable<Message> messages, CancellationToken cancellationToken);
        Task<BatchResponse> SendAllAsync(IEnumerable<Message> messages, bool dryRun);
        Task<BatchResponse> SendAllAsync(IEnumerable<Message> messages, bool dryRun, CancellationToken cancellationToken);
        Task<string> SendAsync(Message message);
        Task<string> SendAsync(Message message, CancellationToken cancellationToken);
        Task<string> SendAsync(Message message, bool dryRun);
        Task<string> SendAsync(Message message, bool dryRun, CancellationToken cancellationToken);
        Task<BatchResponse> SendMulticastAsync(MulticastMessage message);
        Task<BatchResponse> SendMulticastAsync(MulticastMessage message, CancellationToken cancellationToken);
        Task<BatchResponse> SendMulticastAsync(MulticastMessage message, bool dryRun);
        Task<BatchResponse> SendMulticastAsync(MulticastMessage message, bool dryRun, CancellationToken cancellationToken);
        Task<TopicManagementResponse> SubscribeToTopicAsync(IReadOnlyList<string> registrationTokens, string topic);
        Task<TopicManagementResponse> UnsubscribeFromTopicAsync(IReadOnlyList<string> registrationTokens, string topic);
    }
}
