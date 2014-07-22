// <copyright file="ItemId.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


namespace Skylight
{
    /// <summary>
    ///     Class item id.
    /// </summary>
    public class ItemId
    {

        /// <summary>
        ///     Determines whether the specified block is solid.
        /// </summary>
        /// <param name="blockId">The id of the block</param>
        /// <returns><c>true</c> if the specified block is solid; otherwise, <c>false</c>.</returns>
        public static bool IsSolid(int blockId)
        {
            return blockId >= 9 && blockId <= 97 || blockId >= 122 && blockId <= 217;
        } // end function

        /// <summary>
        ///     Determines whether the specified block is climbable.
        /// </summary>
        /// <param name="blockId">The block id</param>
        /// <returns><c>true</c> if the specified block is climbable; otherwise, <c>false</c>.</returns>
        public static bool IsClimbable(int blockId)
        {
            switch (blockId)
            {
                case BlockIds.Action.Ladders.Ladder:
                case BlockIds.Action.Ladders.Chain:
                case BlockIds.Action.Ladders.Horizontalvine:
                case BlockIds.Action.Ladders.Verticalvine:
                {
                    return true;
                }
                default:
                {
                    break;
                }
            }
            return false;
        }


        /// <summary>
        ///     Determines whether the specified block is able to be rotated.
        /// </summary>
        /// <param name="blockId">The id of the block</param>
        /// <returns><c>true</c> if the specified block is able to be rotated; otherwise, <c>false</c>.</returns>
        public static bool IsBlockRotateable(int blockId)
        {
            switch (blockId)
            {
                case BlockIds.Decorative.SciFi2013.Bluestraight:
                case BlockIds.Decorative.SciFi2013.Bluebend:
                case BlockIds.Decorative.SciFi2013.Greenstraight:
                case BlockIds.Decorative.SciFi2013.Greenbend:
                case BlockIds.Decorative.SciFi2013.Orangestraight:
                case BlockIds.Decorative.SciFi2013.Orangebend:
                {
                    return true;
                }
                default:
                {
                    break;
                }
            }
            return false;
        }
    }
}