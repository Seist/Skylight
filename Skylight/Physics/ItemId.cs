namespace Skylight.Physics
{

    public class ItemId : object
    {
        public const int SWITCH_PURPLE = 113;
        public const int DOOR_PURPLE = 184;
        public const int GATE_PURPLE = 185;
        public const int DOOR_CLUB = 200;
        public const int GATE_CLUB = 201;
        public const int SPEED_LEFT = 114;
        public const int SPEED_RIGHT = 115;
        public const int SPEED_UP = 116;
        public const int SPEED_DOWN = 117;
        public const int CHAIN = 118;
        public const int WATER = 119;
        public const int NINJA_LADDER = 120;
        public const int BRICK_COMPLETE = 121;
        public const int TIMEDOOR = 156;
        public const int TIMEGATE = 157;
        public const int COINDOOR = 43;
        public const int COINGATE = 165;
        public const int WINE_V = 98;
        public const int WINE_H = 99;
        public const int DIAMOND = 241;
        public const int WAVE = 300;
        public const int CAKE = 337;
        public const int CHECKPOINT = 360;
        public const int SPIKE = 361;
        public const int FIRE = 368;
        public const int MUD = 369;
        public const int MUD_BUBBLE = 370;
        public const int PORTAL = 242;
        public const int WORLD_PORTAL = 374;
        public const int ZOMBIE_GATE = 206;
        public const int ZOMBIE_DOOR = 207;
        public const int GLOWYLINE_BLUE_SLOPE = 375;
        public const int GLOWY_LINE_BLUE_STRAIGHT = 376;
        public const int GLOWY_LINE_GREEN_SLOPE = 379;
        public const int GLOWY_LINE_GREEN_STRAIGHT = 380;
        public const int GLOWY_LINE_YELLOW_SLOPE = 377;
        public const int GLOWY_LINE_YELLOW_STRAIGHT = 378;
        public const int PORTAL_INVISIBLE = 381;
        public const int TEXT_SIGN = 385;

        public ItemId()
        {
            return;
        }// end function

        public static bool isSolid(int param1)
        {
            return param1 >= 9 && param1 <= 97 || param1 >= 122 && param1 <= 217;
        }// end function

        public static bool isClimbable(int param1)
        {
            switch(param1)
            {
                case NINJA_LADDER:
                case CHAIN:
                case WINE_V:
                case WINE_H:
                {
                    return true;
                }
                default:
                {
                    break;
                }
            }
            return false;
        }// end function

        public static bool isBackgroundRotateable(int param1)
        {
            return false;
        }// end function

        public static bool isDecorationRotateable(int param1)
        {
            switch(param1)
            {
                case GLOWY_LINE_BLUE_STRAIGHT:
                case GLOWYLINE_BLUE_SLOPE:
                case GLOWY_LINE_GREEN_SLOPE:
                case GLOWY_LINE_GREEN_STRAIGHT:
                case GLOWY_LINE_YELLOW_SLOPE:
                case GLOWY_LINE_YELLOW_STRAIGHT:
                {
                    return true;
                }
                default:
                {
                    break;
                }
            }
            return false;
        }// end function

    }
}
