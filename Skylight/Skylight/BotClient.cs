namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using PlayerIOClient;

    internal class BotClient
    {
        private Client client;

        private List<Connection> connections = new List<Connection>();

        public Client Client
        {
            get
            {
                return this.client;
            }

            internal set
            {
                this.client = value;
            }
        }

        public List<Connection> Connections
        {
            get
            {
                return this.connections;
            }

            internal set
            {
                this.connections = value;
            }
        }
    }
}
