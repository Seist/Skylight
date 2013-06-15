using System;
using PlayerIOClient;

namespace Skylight
{
    internal static class GameVersion
    {
        private static string storedVersion;

        internal static string Value(bool cached = true, string prefix = Tools.NormalRoom)
        {
            if (!cached || storedVersion == null)
                return prefix + Refresh();

            return prefix + storedVersion;
        }

        internal static string Refresh()
        {
            try
            {
                var c = PlayerIO.QuickConnect.SimpleConnect(Tools.GameID, Tools.GuestEmail, Tools.GuestPassword);
                c.Multiplayer.CreateJoinRoom("null", "null", false, null, null);

                throw new Exception("Unable to query game version.");
            }
            catch (PlayerIOError e)
            {
                if (e.ErrorCode == ErrorCode.UnknownRoomType)
                {
                    string[] errMsg = e.Message.Split('[')[1].Split(' ');

                    for (int i = errMsg.Length - 1; i >= 0; i--)
                    {
                        string currentRoomType = errMsg[i];

                        if (currentRoomType.StartsWith(Tools.NormalRoom, StringComparison.Ordinal))
                        {
                            storedVersion = currentRoomType.Substring(Tools.NormalRoom.Length, currentRoomType.Length - Tools.NormalRoom.Length - 1);
                            return storedVersion;
                        }
                    }

                    throw new Exception("Unable to extract game version.");
                }

                Tools.SkylightMessage("Cannot get game version: " + e.Message);
                return null;
            }
        }
    }
}
