// <copyright file="Config.cs" company="">
//     Copyright 2014 (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace Skylight.Physics
{
    /// <summary>
    /// Class Configuration.
    /// </summary>
    public class Config : object
    {
        /// <summary>
        /// The PlayerIO game id.
        /// </summary>
        public static string PlayerioGameId = "everybody-edits-su9rn58o40itdbnw69plyw";
        /// <summary>
        /// The server version.
        /// </summary>
        public static int ServerTypeVersion = 176;
        /// <summary>
        /// The server_type_normalroom
        /// </summary>
        public static string ServerTypeNormalroom = "Everybodyedits" + ServerTypeVersion;
        /// <summary>
        /// The beta room
        /// </summary>
        public static string ServerTypeBetaroom = "Beta" + ServerTypeVersion;
        /// <summary>
        /// The guest only room
        /// </summary>
        public static string ServerTypeGuestserviceroom = "LobbyGuest" + ServerTypeVersion;
        /// <summary>
        /// The service room
        /// </summary>
        public static string ServerTypeServiceroom = "Lobby" + ServerTypeVersion;
        /// <summary>
        /// The authentication room (temp)
        /// </summary>
        public static string ServerTypeAuthroom = "Auth" + ServerTypeVersion;
        /// <summary>
        /// The blacklisted rooms
        /// </summary>
        public static string ServerTypeBlacklistroom = "QuickInviteHandler" + ServerTypeVersion;
        /// <summary>
        /// The tutorial room
        /// </summary>
        public static string ServerTypeTutorialroom = "Tutorial" + ServerTypeVersion + "_world_";
        /// <summary>
        /// The tracking room
        /// </summary>
        public static string ServerTypeTrackingroom = "Tracking" + ServerTypeVersion;
        /// <summary>
        /// The url for the Everybody Edits blog
        /// </summary>
        public static string UrlBlog = "http://blog.everybodyedits.com";
        /// <summary>
        /// The url to the club member page
        /// </summary>
        public static string UrlClubmemberAboutPage = "http://everybodyedits.com/club";
        /// <summary>
        /// The terms of service website
        /// </summary>
        public static string UrlTermsPage = "http://everybodyedits.com/terms";
        /// <summary>
        /// The help website
        /// </summary>
        public static string UrlHelpPage = "http://everybodyedits.com/help";
        /// <summary>
        /// Whether or not to use the debug server
        /// </summary>
        public static bool UseDebugServer = false;
        /// <summary>
        /// Whether or not to run in development mode
        /// </summary>
        public static bool RunInDevelopmentMode = false;
        /// <summary>
        /// The show_disabled_shopitems
        /// </summary>
        public static bool ShowDisabledShopitems = false;
        /// <summary>
        /// The development_mode_autojoin_room
        /// </summary>
        public static string DevelopmentModeAutojoinRoom = "PWvOaRIeIvbUI";
        /// <summary>
        /// The debug_news
        /// </summary>
        public static string DebugNews = "";
        /// <summary>
        /// The developer_server
        /// </summary>
        public static string DeveloperServer = "127.0.0.1:8184";
        /// <summary>
        /// The force armor authentication option
        /// </summary>
        public static bool ForceArmor = false;
        /// <summary>
        /// The armor_userid
        /// </summary>
        public static string ArmorUserid = null;
        /// <summary>
        /// The armor_authtoken
        /// </summary>
        public static string ArmorAuthtoken = null;
        /// <summary>
        /// The force mouse breaker
        /// </summary>
        public static bool ForceMouseBreaker = false;
        /// <summary>
        /// The mousebreaker_authtoken
        /// </summary>
        public static string MousebreakerAuthtoken = null;
        /// <summary>
        /// The force beta
        /// </summary>
        public static bool ForceBeta = false;
        /// <summary>
        /// The show_debug_profile
        /// </summary>
        public static bool ShowDebugProfile = true;
        /// <summary>
        /// The debug_profile
        /// </summary>
        public static string DebugProfile = "";
        /// <summary>
        /// The disable cookie
        /// </summary>
        public static bool DisableCookie = false;
        /// <summary>
        /// The show_debug_friendrequest
        /// </summary>
        public static bool ShowDebugFriendrequest = false;
        /// <summary>
        /// The debug_friendrequest
        /// </summary>
        public static string DebugFriendrequest = "";
        /// <summary>
        /// The show_blacklist_invitation
        /// </summary>
        public static bool ShowBlacklistInvitation = false;
        /// <summary>
        /// The debug_invitation
        /// </summary>
        public static string DebugInvitation = "";
        /// <summary>
        /// The physics_ms_per_tick
        /// </summary>
        public static int PhysicsMsPerTick = 10;
        /// <summary>
        /// The physics_variable_multiplyer
        /// </summary>
        public static double PhysicsVariableMultiplyer = 7.752;
        /// <summary>
        /// The physics_base_drag
        /// </summary>
        public static double PhysicsBaseDrag = Math.Pow(0.9981, PhysicsMsPerTick)*1.00016;
        /// <summary>
        /// The physics_no_modifier_drag
        /// </summary>
        public static double PhysicsNoModifierDrag = Math.Pow(0.99, PhysicsMsPerTick)*1.00016;
        /// <summary>
        /// The physics_water_drag
        /// </summary>
        public static double PhysicsWaterDrag = Math.Pow(0.995, PhysicsMsPerTick)*1.00016;
        /// <summary>
        /// The physics_mud_drag
        /// </summary>
        public static double PhysicsMudDrag = Math.Pow(0.975, PhysicsMsPerTick)*1.00016;
        /// <summary>
        /// The physics_jump_height
        /// </summary>
        public static double PhysicsJumpHeight = 26;
        /// <summary>
        /// The physics_gravity
        /// </summary>
        public static double PhysicsGravity = 2;
        /// <summary>
        /// The physics_boost
        /// </summary>
        public static double PhysicsBoost = 16;
        /// <summary>
        /// The physics_water_buoyancy
        /// </summary>
        public static double PhysicsWaterBuoyancy = -0.5;
        /// <summary>
        /// The physics_mud_buoyancy
        /// </summary>
        public static double PhysicsMudBuoyancy = 0.4;
        /// <summary>
        /// The physics_queue_length
        /// </summary>
        public static int PhysicsQueueLength = 2;
        /// <summary>
        /// The shop_potion_max
        /// </summary>
        public static int ShopPotionMax = 10;
        /// <summary>
        /// The camera_lag
        /// </summary>
        public static double CameraLag = 0.0625;
        /// <summary>
        /// The is mobile
        /// </summary>
        public static bool IsMobile = false;
        /// <summary>
        /// The enable debug shadow
        /// </summary>
        public static bool EnableDebugShadow = false;
        /// <summary>
        /// The maxwidth
        /// </summary>
        public static int Maxwidth = 850;
        /// <summary>
        /// The minwidth
        /// </summary>
        public static int Minwidth = 640;
        /// <summary>
        /// The width
        /// </summary>
        public static int Width = 640;
        /// <summary>
        /// The height
        /// </summary>
        public static int Height = 500;
        /// <summary>
        /// The maximum frame rate
        /// </summary>
        public static int MaxFrameRate = 120;
        /// <summary>
        /// The max_daily_woot
        /// </summary>
        public static int MaxDailyWoot = 10;
        /// <summary>
        /// The guest_color
        /// </summary>
        public static uint GuestColor = 3355443;
        /// <summary>
        /// The default_color
        /// </summary>
        public static uint DefaultColor = 15658734;
        /// <summary>
        /// The default_color_dark
        /// </summary>
        public static uint DefaultColorDark = 13421772;
        /// <summary>
        /// The friend_color
        /// </summary>
        public static uint FriendColor = 65280;
        /// <summary>
        /// The friend_color_dark
        /// </summary>
        public static uint FriendColorDark = 47872;
        /// <summary>
        /// The mod_color
        /// </summary>
        public static uint ModColor = 16759552;
        /// <summary>
        /// The admin_color
        /// </summary>
        public static uint AdminColor = 16757760;
        /// <summary>
        /// The tutorial_names
        /// </summary>
        public static string[] TutorialNames = {"Moving", "Gravity", "Edit"};
        /// <summary>
        /// The disable_tracking
        /// </summary>
        public static bool DisableTracking = false;
    }
}