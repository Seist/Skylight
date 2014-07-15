namespace Skylight.Physics
{

    using System;

    public class Config : object
    {
        public static string playerio_game_id = "everybody-edits-su9rn58o40itdbnw69plyw";
        public static int server_type_version = 176;
        public static string server_type_normalroom = "Everybodyedits" + server_type_version;
        public static string server_type_betaroom = "Beta" + server_type_version;
        public static string server_type_guestserviceroom = "LobbyGuest" + server_type_version;
        public static string server_type_serviceroom = "Lobby" + server_type_version;
        public static string server_type_authroom = "Auth" + server_type_version;
        public static string server_type_blacklistroom = "QuickInviteHandler" + server_type_version;
        public static string server_type_tutorialroom = "Tutorial" + server_type_version + "_world_";
        public static string server_type_trackingroom = "Tracking" + server_type_version;
        public static string url_blog = "http://blog.everybodyedits.com";
        public static string url_clubmember_about_page = "http://everybodyedits.com/club";
        public static string url_terms_page = "http://everybodyedits.com/terms";
        public static string url_help_page = "http://everybodyedits.com/help";
        public static bool use_debug_server = false;
        public static bool run_in_development_mode = false;
        public static bool show_disabled_shopitems = false;
        public static string development_mode_autojoin_room = "PWvOaRIeIvbUI";
        public static string debug_news = "";
        public static string developer_server = "127.0.0.1:8184";
        public static bool forceArmor = false;
        public static string armor_userid = null;
        public static string armor_authtoken = null;
        public static bool forceMouseBreaker = false;
        public static string mousebreaker_authtoken = null;
        public static bool forceBeta = false;
        public static bool show_debug_profile = true;
        public static string debug_profile = "";
        public static bool disableCookie = false;
        public static bool show_debug_friendrequest = false;
        public static string debug_friendrequest = "";
        public static bool show_blacklist_invitation = false;
        public static string debug_invitation = "";
        public static int physics_ms_per_tick = 10;
        public static double physics_variable_multiplyer = 7.752;
        public static double physics_base_drag = Math.Pow(0.9981, physics_ms_per_tick) * 1.00016;
        public static double physics_no_modifier_drag = Math.Pow(0.99, physics_ms_per_tick) * 1.00016;
        public static double physics_water_drag = Math.Pow(0.995, physics_ms_per_tick) * 1.00016;
        public static double physics_mud_drag = Math.Pow(0.975, physics_ms_per_tick) * 1.00016;
        public static double physics_jump_height = 26;
        public static double physics_gravity = 2;
        public static double physics_boost = 16;
        public static double physics_water_buoyancy = -0.5;
        public static double physics_mud_buoyancy = 0.4;
        public static int physics_queue_length = 2;
        public static int shop_potion_max = 10;
        public static double camera_lag = 0.0625;
        public static bool isMobile = false;
        public static bool enableDebugShadow = false;
        public static int maxwidth = 850;
        public static int minwidth = 640;
        public static int width = 640;
        public static int height = 500;
        public static int maxFrameRate = 120;
        public static int max_daily_woot = 10;
        public static uint guest_color = 3355443;
        public static uint default_color = 15658734;
        public static uint default_color_dark = 13421772;
        public static uint friend_color = 65280;
        public static uint friend_color_dark = 47872;
        public static uint mod_color = 16759552;
        public static uint admin_color = 16757760;
        public static string[] tutorial_names = { "Moving", "Gravity", "Edit" };
        public static bool disable_tracking = false;

        public Config()
        {
            return;
        }
    }
}