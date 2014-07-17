// ***********************************************************************
// <copyright file="PotionIds.cs" company="">
//     Copyright 2014 (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Skylight.Miscellaneous
{
    /// <summary>
    /// Class PotionIds.
    /// </summary>
    public static class PotionIds
    {
        /// <summary>
        /// The curse
        /// </summary>
        public static readonly int
            Curse = 6, Invulnerable = 8, Zombie = 9, Respawn = 10, Flauntlevel = 12, Solitude = 13;

        /// <summary>
        /// Class Auras.
        /// </summary>
        public static class Auras
        {
            /// <summary>
            /// The aura colors
            /// </summary>
            public static readonly int
                Red = 1, Blue = 2, Yellow = 3, Green = 5, Fire = 7;
        }

        /// <summary>
        /// Class GravityModifiers.
        /// </summary>
        public static class GravityModifiers
        {
            /// <summary>
            /// The jumpboost class
            /// </summary>
            public static readonly int
                Jumpboost = 4, Levitation = 11;
        }
    }
}