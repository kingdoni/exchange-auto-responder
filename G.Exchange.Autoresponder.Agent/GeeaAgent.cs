using Microsoft.Exchange.Data.Transport;
using Microsoft.Exchange.Data.Transport.Smtp;

namespace G.Exchange.Autoresponder.Agent
{
    internal class GeeaAgent : SmtpReceiveAgent
    {
        private SmtpServer _server;

        public GeeaAgent(SmtpServer server)
        {
            this._server = server;
        }
    }
}