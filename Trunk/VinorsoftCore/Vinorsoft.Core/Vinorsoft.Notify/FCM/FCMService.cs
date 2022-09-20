using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Vinorsoft.Notify.Interface;

namespace Vinorsoft.Notify
{
    public class FCMService : IFCMService
    {
        private readonly IFCMConfiguration _fCMConfiguration;
        private readonly FirebaseMessaging messaging;
        public FCMService(IFCMConfiguration fCMConfiguration)
        {
            //var app = FirebaseApp.Create(new AppOptions() { Credential = GoogleCredential.FromFile("serviceAccountKey.json").CreateScoped("https://www.googleapis.com/auth/firebase.messaging")});           
            _fCMConfiguration = fCMConfiguration;
            var app = FirebaseApp.Create(new AppOptions() {
                Credential = fCMConfiguration.GoogleCredential
            });
            messaging = FirebaseMessaging.GetMessaging(app);
        }

        public Task<BatchResponse> SendAllAsync(IEnumerable<Message> messages)
        {
            return messaging.SendAllAsync(messages);
        }

        public Task<BatchResponse> SendAllAsync(IEnumerable<Message> messages, CancellationToken cancellationToken)
        {
            return messaging.SendAllAsync(messages, cancellationToken);
        }

        public Task<BatchResponse> SendAllAsync(IEnumerable<Message> messages, bool dryRun)
        {
            return messaging.SendAllAsync(messages, dryRun);

        }

        public Task<BatchResponse> SendAllAsync(IEnumerable<Message> messages, bool dryRun, CancellationToken cancellationToken)
        {
            return messaging.SendAllAsync(messages, dryRun, cancellationToken);
        }

        public Task<string> SendAsync(Message message)
        {
            return messaging.SendAsync(message);
        }

        public Task<string> SendAsync(Message message, CancellationToken cancellationToken)
        {
            return messaging.SendAsync(message, cancellationToken);
        }

        public Task<string> SendAsync(Message message, bool dryRun)
        {
            return messaging.SendAsync(message, dryRun);
        }

        public Task<string> SendAsync(Message message, bool dryRun, CancellationToken cancellationToken)
        {
            return messaging.SendAsync(message, dryRun, cancellationToken);
        }

        public Task<BatchResponse> SendMulticastAsync(MulticastMessage message)
        {
            return messaging.SendMulticastAsync(message);
        }

        public Task<BatchResponse> SendMulticastAsync(MulticastMessage message, CancellationToken cancellationToken)
        {
            return messaging.SendMulticastAsync(message, cancellationToken);
        }

        public Task<BatchResponse> SendMulticastAsync(MulticastMessage message, bool dryRun)
        {
            return messaging.SendMulticastAsync(message, dryRun);
        }

        public Task<BatchResponse> SendMulticastAsync(MulticastMessage message, bool dryRun, CancellationToken cancellationToken)
        {
            return messaging.SendMulticastAsync(message, dryRun, cancellationToken);
        }

        public Task<TopicManagementResponse> SubscribeToTopicAsync(IReadOnlyList<string> registrationTokens, string topic)
        {
            return messaging.SubscribeToTopicAsync(registrationTokens, topic);
        }

        public Task<TopicManagementResponse> UnsubscribeFromTopicAsync(IReadOnlyList<string> registrationTokens, string topic)
        {
            return messaging.UnsubscribeFromTopicAsync(registrationTokens, topic);
        }
    }
}
