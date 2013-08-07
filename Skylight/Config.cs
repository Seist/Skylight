using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skylight
{
    public class Config : Object
    {
        public static String playerio_game_id = "everybody-edits-su9rn58o40itdbnw69plyw";
        public static int server_type_version = 143;
        public static String server_type_normalroom = "Everybodyedits" + server_type_version;
        public static String server_type_betaroom = "Beta" + server_type_version;
        public static String server_type_guestserviceroom = "LobbyGuest" + server_type_version;
        public static String server_type_serviceroom = "Lobby" + server_type_version;
        public static String server_type_authroom = "Auth" + server_type_version;
        public static String server_type_blacklistroom = "QuickInviteHandler" + server_type_version;
        public static String server_type_tutorialroom = "Tutorial" + server_type_version + "_world_";
        public static String server_type_trackingroom = "Tracking" + server_type_version;
        public static bool use_debug_server = false;
        public static bool run_in_development_mode = false;
        public static bool show_disabled_shopitems = false;
        public static String development_mode_autojoin_room = "PWe5nWk_AcbUI";
        public static String developer_server = "127.0.0.1:8184";
        public static bool forceArmor = false;
        public static String armor_userid = null;
        public static String armor_authtoken = null;
        public static bool forceMouseBreaker = false;
        public static String mousebreaker_authtoken = null;
        public static bool forceBeta = false;
        public static bool show_debug_profile = false;
        public static String debug_profile = "";
        public static bool disableCookie = false;
        public static bool show_debug_friendrequest = false;
        public static String debug_friendrequest = "";
        public static bool show_blacklist_invitation = false;
        public static String debug_invitation = "";
        public static int physics_ms_per_tick = 10;
        public static double physics_variable_multiplyer = 7.752;
        public static double physics_base_drag = Math.Pow(0.9981, physics_ms_per_tick) * 1.00016;
        public static double physics_no_modifier_drag = Math.Pow(0.99, physics_ms_per_tick) * 1.00016;
        public static double physics_water_drag = Math.Pow(0.995, physics_ms_per_tick) * 1.00016;
        public static double physics_jump_height = 26;
        public static double physics_gravity = 2;
        public static double physics_boost = 16;
        public static double physics_water_buoyancy = -0.5;
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
        public static string debug_news = "";
        public static bool disable_tracking = false;

        public Config()
        {
            return;
        }// end function

    }
}


