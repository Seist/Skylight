namespace Skylight.Physics
{
    public class ItemId : object
    {
        public ItemId()
        {
        } // end function

        public static bool isSolid(int param1)
        {
            return param1 >= 9 && param1 <= 97 || param1 >= 122 && param1 <= 217;
        } // end function

        public static bool isClimbable(int param1)
        {
            switch (param1)
            {
                case BlockIds.Action.Ladders.LADDER:
                case BlockIds.Action.Ladders.CHAIN:
                case BlockIds.Action.Ladders.HORIZONTALVINE:
                case BlockIds.Action.Ladders.VERTICALVINE:
                {
                    return true;
                }
                default:
                {
                    break;
                }
            }
            return false;
        } // end function

        public static bool isBackgroundRotateable(int param1)
        {
            return false;
        } // end function

        public static bool isDecorationRotateable(int param1)
        {
            switch (param1)
            {
                case BlockIds.Decorative.SciFi2013.BLUESTRAIGHT:
                case BlockIds.Decorative.SciFi2013.BLUEBEND:
                case BlockIds.Decorative.SciFi2013.GREENSTRAIGHT:
                case BlockIds.Decorative.SciFi2013.GREENBEND:
                case BlockIds.Decorative.SciFi2013.ORANGESTRAIGHT:
                case BlockIds.Decorative.SciFi2013.ORANGEBEND:
                {
                    return true;
                }
                default:
                {
                    break;
                }
            }
            return false;
        } // end function
    }
}