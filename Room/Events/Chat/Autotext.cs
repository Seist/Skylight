// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Autotext.cs" company="None">
//   
// </copyright>
// <summary>
//   Class Autotext.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Skylight
{
    using System.Collections.Generic;

    using PlayerIOClient;

    /// <summary>
    /// Class Autotext.
    /// </summary>
    public class Autotext
    {
        /// <summary>
        /// The _receiver
        /// </summary>
        private readonly Receiver _receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="Autotext"/> class.
        /// </summary>
        /// <param name="in">The in.</param>
        public Autotext(Receiver @in)
        {
            _receiver = @in;
        }

        /// <summary>
        /// All of the delegates for ChatEvent. Chat events are when the player
        /// says something, and distinguishes between auto text and system messages
        /// and much more.
        /// </summary>
        public event Receiver.ChatEvent
            AutotextEvent = delegate { };

        /// <summary>
        /// Called when someone says a message using the auto text function.
        /// </summary>
        /// <param name="m">The m.</param>
        public void OnAutotext(Message m)
        {
            // Extract data.
            int id = m.GetInteger(0);

            string message = m.GetString(1);

            var autoTextConversions = new Dictionary<int, string>
                                          {
                                              { 0, "Left." },
                                              { 1, "Hi." },
                                              { 2, "Goodbye." },
                                              { 3, "Help me!" },
                                              { 4, "Thank you." },
                                              { 5, "Follow me." },
                                              { 6, "Stop!" },
                                              { 7, "Yes." },
                                              { 8, "No." },
                                              { 9, "Right." }
                                          };

            // Update relevant objects.
            Player subject = Tools.GetPlayer(id, this._receiver.Source);

            this._receiver.Source.ChatLog.Add(new KeyValuePair<string, Player>(message, subject));

            // Fire the event.
            var e = new ChatEventArgs(subject, m, this._receiver.Source, message);

            this._receiver.Source.MainReceiver.Autotext.AutotextEvent(e);
        }
    }
}
