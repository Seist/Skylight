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
                case (int)BlockIds.Ladders.LADDER:
                case (int)BlockIds.Ladders.CHAIN:
                case (int)BlockIds.Ladders.HORIZONTALVINE:
                case (int)BlockIds.Ladders.VERTICALVINE:
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
                case (int)BlockIds.SciFi2013.BLUESTRAIGHT:
                case (int)BlockIds.SciFi2013.BLUEBEND:
                case (int)BlockIds.SciFi2013.GREENSTRAIGHT:
                case (int)BlockIds.SciFi2013.GREENBEND:
                case (int)BlockIds.SciFi2013.ORANGESTRAIGHT:
                case (int)BlockIds.SciFi2013.ORANGEBEND:
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
