namespace Skylight.Physics
{

    public class ItemId : object
    {
        public ItemId()
        {
            return;
        }

        public static bool isSolid(int block_id)
        {
            return (block_id >= 9 && block_id <= 97) || (block_id >= 122 && block_id <= 217);
        }

        public static bool isClimbable(int block_id)
        {
            switch (block_id)
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
                        return false;
                    }
            }
        }

        public static bool isRotateable(int block_id)
        {
            switch (block_id)
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
                        return false;
                    }
            }
        }

    }
}
