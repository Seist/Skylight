// <copyright file="ItemId.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Skylight.Blocks;

namespace Skylight.Physics
{
    /// <summary>
    ///     Class item id.
    /// </summary>
    public class ItemId : object
    {
        // end function

        /// <summary>
        ///     Determines whether the specified block is solid.
        /// </summary>
        /// <param name="param1">The param1.</param>
        /// <returns><c>true</c> if the specified block is solid; otherwise, <c>false</c>.</returns>
        public static bool IsSolid(int param1)
        {
            return param1 >= 9 && param1 <= 97 || param1 >= 122 && param1 <= 217;
        } // end function

        /// <summary>
        ///     Determines whether the specified block is climbable.
        /// </summary>
        /// <param name="param1">The block.</param>
        /// <returns><c>true</c> if the specified block is climbable; otherwise, <c>false</c>.</returns>
        public static bool IsClimbable(int param1)
        {
            switch (param1)
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
        } // end function

        /// <summary>
        ///     Determines whether [is background rotateable] [the specified block].
        /// </summary>
        /// <param name="param1">The param1.</param>
        /// <returns><c>true</c> if [is background rotateable] [the specified block]; otherwise, <c>false</c>.</returns>
        public static bool IsBackgroundRotateable(int param1)
        {
            return false;
        } // end function

        /// <summary>
        ///     Determines whether [is decoration rotateable] [the specified block].
        /// </summary>
        /// <param name="param1">The param1.</param>
        /// <returns><c>true</c> if [is decoration rotateable] [the specified block]; otherwise, <c>false</c>.</returns>
        public static bool IsDecorationRotateable(int param1)
        {
            switch (param1)
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
        } // end function
    }
}