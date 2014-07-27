// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.cs" company="">
//   
// </copyright>
// <summary>
//   Class Configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Skylight
{
    using System;

    /// <summary>
    ///     Class Configuration.
    /// </summary>
    public class Config : object
    {
        #region Static Fields

        /// <summary>
        ///     The admin color
        /// </summary>
        public static uint AdminColor = 16757760;

        /// <summary>
        ///     The camera lag
        /// </summary>
        public static double CameraLag = 0.0625;

        /// <summary>
        ///     The default color
        /// </summary>
        public static uint DefaultColor = 15658734;

        /// <summary>
        ///     The default dark color
        /// </summary>
        public static uint DefaultColorDark = 13421772;

        /// <summary>
        ///     The friend color
        /// </summary>
        public static uint FriendColor = 65280;

        /// <summary>
        ///     The darker friend color
        /// </summary>
        public static uint FriendColorDark = 47872;

        /// <summary>
        ///     The color of a guest
        /// </summary>
        public static uint GuestColor = 3355443;

        /// <summary>
        ///     The maximum daily woots for a player
        /// </summary>
        public static int MaxDailyWoot = 10;

        /// <summary>
        ///     The maximum frame rate
        /// </summary>
        public static int MaxFrameRate = 120;

        /// <summary>
        ///     The mod color
        /// </summary>
        public static uint ModColor = 16759552;

        /// <summary>
        ///     The physics base drag
        /// </summary>
        public static double PhysicsBaseDrag = Math.Pow(0.9981, PhysicsMsPerTick) * 1.00016;

        /// <summary>
        ///     The physics boost
        /// </summary>
        public static double PhysicsBoost = 16;

        /// <summary>
        ///     The gravity
        /// </summary>
        public static double PhysicsGravity = 2;

        /// <summary>
        ///     The jump height
        /// </summary>
        public static double PhysicsJumpHeight = 26;

        /// <summary>
        ///     The milliseconds that constitute one player physics tick
        /// </summary>
        public static int PhysicsMsPerTick = 10;

        /// <summary>
        ///     The physics mud buoyancy
        /// </summary>
        public static double PhysicsMudBuoyancy = 0.4;

        /// <summary>
        ///     The physics mud drag
        /// </summary>
        public static double PhysicsMudDrag = Math.Pow(0.975, PhysicsMsPerTick) * 1.00016;

        /// <summary>
        ///     The physics no modifier drag
        /// </summary>
        public static double PhysicsNoModifierDrag = Math.Pow(0.99, PhysicsMsPerTick) * 1.00016;

        /// <summary>
        ///     The physics queue length
        /// </summary>
        public static int PhysicsQueueLength = 2;

        /// <summary>
        ///     The physics variable multiplyer
        /// </summary>
        public static double PhysicsVariableMultiplyer = 7.752;

        /// <summary>
        ///     The physics water buoyancy
        /// </summary>
        public static double PhysicsWaterBuoyancy = -0.5;

        /// <summary>
        ///     The physics water drag
        /// </summary>
        public static double PhysicsWaterDrag = Math.Pow(0.995, PhysicsMsPerTick) * 1.00016;

        /// <summary>
        ///     The PlayerIO game id.
        /// </summary>
        public static string PlayerioGameId = "everybody-edits-su9rn58o40itdbnw69plyw";

        /// <summary>
        ///     The authentication room used for ArmorGames authentication
        /// </summary>
        public static string ServerTypeAuthroom = "Auth" + ServerTypeVersion;

        /// <summary>
        ///     The beta room
        /// </summary>
        public static string ServerTypeBetaroom = "Beta" + ServerTypeVersion;

        /// <summary>
        ///     The blacklisted room
        /// </summary>
        public static string ServerTypeBlacklistroom = "QuickInviteHandler" + ServerTypeVersion;

        /// <summary>
        ///     The guest only room
        /// </summary>
        public static string ServerTypeGuestserviceroom = "LobbyGuest" + ServerTypeVersion;

        /// <summary>
        ///     The server type normal room combined with the everybody edits version.
        /// </summary>
        public static string ServerTypeNormalroom = "Everybodyedits" + ServerTypeVersion;

        /// <summary>
        ///     The service room
        /// </summary>
        public static string ServerTypeServiceroom = "Lobby" + ServerTypeVersion;

        /// <summary>
        ///     The tracking room
        /// </summary>
        public static string ServerTypeTrackingroom = "Tracking" + ServerTypeVersion;

        /// <summary>
        ///     The tutorial room
        /// </summary>
        public static string ServerTypeTutorialroom = "Tutorial" + ServerTypeVersion + "_world_";

        /// <summary>
        ///     The server version.
        /// </summary>
        public static int ServerTypeVersion = 176;

        /// <summary>
        ///     The shop_potion_max
        /// </summary>
        public static int ShopPotionMax = 10;

        /// <summary>
        ///     The tutorial room names
        /// </summary>
        public static string[] TutorialNames = { "Moving", "Gravity", "Edit" };

        /// <summary>
        ///     The url for the Everybody Edits blog
        /// </summary>
        public static string UrlBlog = "http://blog.everybodyedits.com";

        /// <summary>
        ///     The url to the club member page
        /// </summary>
        public static string UrlClubmemberAboutPage = "http://everybodyedits.com/club";

        /// <summary>
        ///     The help website
        /// </summary>
        public static string UrlHelpPage = "http://everybodyedits.com/help";

        /// <summary>
        ///     The terms of service website
        /// </summary>
        public static string UrlTermsPage = "http://everybodyedits.com/terms";

        #endregion
    }
}