namespace Skylight.Physics
{

    using System;

    public class Config : object
    {
        public static readonly string playerio_game_id = "everybody-edits-su9rn58o40itdbnw69plyw";
        public static readonly int server_type_version = 176;
        public static readonly string server_type_normalroom = "Everybodyedits" + server_type_version;
        public static readonly string server_type_betaroom = "Beta" + server_type_version;
        public static readonly string server_type_guestserviceroom = "LobbyGuest" + server_type_version;
        public static readonly string server_type_serviceroom = "Lobby" + server_type_version;
        public static readonly string server_type_authroom = "Auth" + server_type_version;
        public static readonly string server_type_blacklistroom = "QuickInviteHandler" + server_type_version;
        public static readonly string server_type_tutorialroom = "Tutorial" + server_type_version + "_world_";
        public static readonly string server_type_trackingroom = "Tracking" + server_type_version;
        public static readonly string url_blog = "http://blog.everybodyedits.com";
        public static readonly string url_clubmember_about_page = "http://everybodyedits.com/club";
        public static readonly string url_terms_page = "http://everybodyedits.com/terms";
        public static readonly string url_help_page = "http://everybodyedits.com/help";
        public static readonly bool use_debug_server = false;
        public static readonly bool run_in_development_mode = false;
        public static readonly bool show_disabled_shopitems = false;
        public static readonly string development_mode_autojoin_room = "PWvOaRIeIvbUI";
        public static readonly string debug_news = "";
        public static readonly string developer_server = "127.0.0.1:8184";
        public static readonly bool forceArmor = false;
        public static readonly string armor_userid = null;
        public static readonly string armor_authtoken = null;
        public static readonly bool forceMouseBreaker = false;
        public static readonly string mousebreaker_authtoken = null;
        public static readonly bool forceBeta = false;
        public static readonly bool show_debug_profile = true;
        public static readonly string debug_profile = "";
        public static readonly bool disableCookie = false;
        public static readonly bool show_debug_friendrequest = false;
        public static readonly string debug_friendrequest = "";
        public static readonly bool show_blacklist_invitation = false;
        public static readonly string debug_invitation = "";
        public static readonly int physics_ms_per_tick = 10;
        public static readonly double physics_variable_multiplyer = 7.752;
        public static readonly double physics_base_drag = Math.Pow(0.9981, physics_ms_per_tick) * 1.00016;
        public static readonly double physics_no_modifier_drag = Math.Pow(0.99, physics_ms_per_tick) * 1.00016;
        public static readonly double physics_water_drag = Math.Pow(0.995, physics_ms_per_tick) * 1.00016;
        public static readonly double physics_mud_drag = Math.Pow(0.975, physics_ms_per_tick) * 1.00016;
        public static readonly double physics_jump_height = 26;
        public static readonly double physics_gravity = 2;
        public static readonly double physics_boost = 16;
        public static readonly double physics_water_buoyancy = -0.5;
        public static readonly double physics_mud_buoyancy = 0.4;
        public static readonly int physics_queue_length = 2;
        public static readonly int shop_potion_max = 10;
        public static readonly double camera_lag = 0.0625;
        public static readonly bool isMobile = false;
        public static readonly bool enableDebugShadow = false;
        public static readonly int maxwidth = 850;
        public static readonly int minwidth = 640;
        public static readonly int width = 640;
        public static readonly int height = 500;
        public static readonly int maxFrameRate = 120;
        public static readonly int max_daily_woot = 10;
        public static readonly uint guest_color = 3355443;
        public static readonly uint default_color = 15658734;
        public static readonly uint default_color_dark = 13421772;
        public static readonly uint friend_color = 65280;
        public static readonly uint friend_color_dark = 47872;
        public static readonly uint mod_color = 16759552;
        public static readonly uint admin_color = 16757760;
        public static readonly string[] tutorial_names = { "Moving", "Gravity", "Edit" };
        public static readonly bool disable_tracking = false;

        public Config()
        {
            return;
        }
    }
}