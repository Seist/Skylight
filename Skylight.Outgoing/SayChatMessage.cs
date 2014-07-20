using System;
using System.Threading;
using Skylight.Miscellaneous;

namespace Skylight
{
    public class SayChatMessage
    {
        private readonly Out _out;

        public SayChatMessage(Out @out)
        {
            _out = @out;
        }

        /// <summary>
        ///     Says the specified message.
        /// </summary>
        /// <param name="s">The message.</param>
        /// <param name="useChatPrefix">if set to <c>true</c> then [use chat prefix].</param>
        public void Say(string s, bool useChatPrefix = true)
        {
            try
            {
                if (s.StartsWith("/") || !useChatPrefix)
                {
                    if (s.Length <= 80 && s.Length > 0)
                    {
                        _out.C.Send("say", s);
                        Thread.Sleep(_out.Bot.SpeechDelay);
                    }
                    else
                    {
                        // Say what you can.
                        Say(s.Substring(0, 80));

                        // Delete what you just said.
                        s = s.Substring(80);

                        // Repeat the process.
                        Say(s);
                    }
                }
                else
                {
                    if (s.Length + _out.Bot.ChatPrefix.Length > 80)
                    {
                        // Say what you can.
                        Say(s.Substring(0, 80 - _out.Bot.ChatPrefix.Length));

                        // Delete what you just said.
                        s = s.Substring(80 - _out.Bot.ChatPrefix.Length);

                        // Repeat the process.
                        Say(s);
                    }
                    else
                    {
                        _out.C.Send("say", _out.Bot.ChatPrefix + s);
                        Thread.Sleep(_out.Bot.SpeechDelay);
                    }
                }
            }
            catch (Exception)
            {
                Tools.SkylightMessage("Error: attempted to use Out.Say before connecting");
            }
        }
    }
}