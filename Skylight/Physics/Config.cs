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
        public static string playerio_game_id = "everybody-edits-su9rn58o40itdbnw69plyw";
        /// <summary>
        /// The server version.
        /// </summary>
        public static int server_type_version = 176;
        /// <summary>
        /// The server_type_normalroom
        /// </summary>
        public static string server_type_normalroom = "Everybodyedits" + server_type_version;
        /// <summary>
        /// The beta room
        /// </summary>
        public static string server_type_betaroom = "Beta" + server_type_version;
        /// <summary>
        /// The guest only room
        /// </summary>
        public static string server_type_guestserviceroom = "LobbyGuest" + server_type_version;
        /// <summary>
        /// The service room
        /// </summary>
        public static string server_type_serviceroom = "Lobby" + server_type_version;
        /// <summary>
        /// The authentication room (temp)
        /// </summary>
        public static string server_type_authroom = "Auth" + server_type_version;
        /// <summary>
        /// The blacklisted rooms
        /// </summary>
        public static string server_type_blacklistroom = "QuickInviteHandler" + server_type_version;
        /// <summary>
        /// The tutorial room
        /// </summary>
        public static string server_type_tutorialroom = "Tutorial" + server_type_version + "_world_";
        /// <summary>
        /// The tracking room
        /// </summary>
        public static string server_type_trackingroom = "Tracking" + server_type_version;
        /// <summary>
        /// The url for the Everybody Edits blog
        /// </summary>
        public static string url_blog = "http://blog.everybodyedits.com";
        /// <summary>
        /// The url to the club member page
        /// </summary>
        public static string url_clubmember_about_page = "http://everybodyedits.com/club";
        /// <summary>
        /// The terms of service website
        /// </summary>
        public static string url_terms_page = "http://everybodyedits.com/terms";
        /// <summary>
        /// The help website
        /// </summary>
        public static string url_help_page = "http://everybodyedits.com/help";
        /// <summary>
        /// Whether or not to use the debug server
        /// </summary>
        public static bool use_debug_server = false;
        /// <summary>
        /// Whether or not to run in development mode
        /// </summary>
        public static bool run_in_development_mode = false;
        /// <summary>
        /// The show_disabled_shopitems
        /// </summary>
        public static bool show_disabled_shopitems = false;
        /// <summary>
        /// The development_mode_autojoin_room
        /// </summary>
        public static string development_mode_autojoin_room = "PWvOaRIeIvbUI";
        /// <summary>
        /// The debug_news
        /// </summary>
        public static string debug_news = "";
        /// <summary>
        /// The developer_server
        /// </summary>
        public static string developer_server = "127.0.0.1:8184";
        /// <summary>
        /// The force armor
        /// </summary>
        public static bool forceArmor = false;
        /// <summary>
        /// The armor_userid
        /// </summary>
        public static string armor_userid = null;
        /// <summary>
        /// The armor_authtoken
        /// </summary>
        public static string armor_authtoken = null;
        /// <summary>
        /// The force mouse breaker
        /// </summary>
        public static bool forceMouseBreaker = false;
        /// <summary>
        /// The mousebreaker_authtoken
        /// </summary>
        public static string mousebreaker_authtoken = null;
        /// <summary>
        /// The force beta
        /// </summary>
        public static bool forceBeta = false;
        /// <summary>
        /// The show_debug_profile
        /// </summary>
        public static bool show_debug_profile = true;
        /// <summary>
        /// The debug_profile
        /// </summary>
        public static string debug_profile = "";
        /// <summary>
        /// The disable cookie
        /// </summary>
        public static bool disableCookie = false;
        /// <summary>
        /// The show_debug_friendrequest
        /// </summary>
        public static bool show_debug_friendrequest = false;
        /// <summary>
        /// The debug_friendrequest
        /// </summary>
        public static string debug_friendrequest = "";
        /// <summary>
        /// The show_blacklist_invitation
        /// </summary>
        public static bool show_blacklist_invitation = false;
        /// <summary>
        /// The debug_invitation
        /// </summary>
        public static string debug_invitation = "";
        /// <summary>
        /// The physics_ms_per_tick
        /// </summary>
        public static int physics_ms_per_tick = 10;
        /// <summary>
        /// The physics_variable_multiplyer
        /// </summary>
        public static double physics_variable_multiplyer = 7.752;
        /// <summary>
        /// The physics_base_drag
        /// </summary>
        public static double physics_base_drag = Math.Pow(0.9981, physics_ms_per_tick)*1.00016;
        /// <summary>
        /// The physics_no_modifier_drag
        /// </summary>
        public static double physics_no_modifier_drag = Math.Pow(0.99, physics_ms_per_tick)*1.00016;
        /// <summary>
        /// The physics_water_drag
        /// </summary>
        public static double physics_water_drag = Math.Pow(0.995, physics_ms_per_tick)*1.00016;
        /// <summary>
        /// The physics_mud_drag
        /// </summary>
        public static double physics_mud_drag = Math.Pow(0.975, physics_ms_per_tick)*1.00016;
        /// <summary>
        /// The physics_jump_height
        /// </summary>
        public static double physics_jump_height = 26;
        /// <summary>
        /// The physics_gravity
        /// </summary>
        public static double physics_gravity = 2;
        /// <summary>
        /// The physics_boost
        /// </summary>
        public static double physics_boost = 16;
        /// <summary>
        /// The physics_water_buoyancy
        /// </summary>
        public static double physics_water_buoyancy = -0.5;
        /// <summary>
        /// The physics_mud_buoyancy
        /// </summary>
        public static double physics_mud_buoyancy = 0.4;
        /// <summary>
        /// The physics_queue_length
        /// </summary>
        public static int physics_queue_length = 2;
        /// <summary>
        /// The shop_potion_max
        /// </summary>
        public static int shop_potion_max = 10;
        /// <summary>
        /// The camera_lag
        /// </summary>
        public static double camera_lag = 0.0625;
        /// <summary>
        /// The is mobile
        /// </summary>
        public static bool isMobile = false;
        /// <summary>
        /// The enable debug shadow
        /// </summary>
        public static bool enableDebugShadow = false;
        /// <summary>
        /// The maxwidth
        /// </summary>
        public static int maxwidth = 850;
        /// <summary>
        /// The minwidth
        /// </summary>
        public static int minwidth = 640;
        /// <summary>
        /// The width
        /// </summary>
        public static int width = 640;
        /// <summary>
        /// The height
        /// </summary>
        public static int height = 500;
        /// <summary>
        /// The maximum frame rate
        /// </summary>
        public static int maxFrameRate = 120;
        /// <summary>
        /// The max_daily_woot
        /// </summary>
        public static int max_daily_woot = 10;
        /// <summary>
        /// The guest_color
        /// </summary>
        public static uint guest_color = 3355443;
        /// <summary>
        /// The default_color
        /// </summary>
        public static uint default_color = 15658734;
        /// <summary>
        /// The default_color_dark
        /// </summary>
        public static uint default_color_dark = 13421772;
        /// <summary>
        /// The friend_color
        /// </summary>
        public static uint friend_color = 65280;
        /// <summary>
        /// The friend_color_dark
        /// </summary>
        public static uint friend_color_dark = 47872;
        /// <summary>
        /// The mod_color
        /// </summary>
        public static uint mod_color = 16759552;
        /// <summary>
        /// The admin_color
        /// </summary>
        public static uint admin_color = 16757760;
        /// <summary>
        /// The tutorial_names
        /// </summary>
        public static string[] tutorial_names = {"Moving", "Gravity", "Edit"};
        /// <summary>
        /// The disable_tracking
        /// </summary>
        public static bool disable_tracking = false;
    }
}