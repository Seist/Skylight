// ***********************************************************************
// Assembly         : Skylight
// Author           : TakoMan02
// Created          : 07-21-2014
//
// Last Modified By : TakoMan02
// Last Modified On : 07-21-2014
// ***********************************************************************
// <copyright file="BlockIds.cs" company="">
//     Copyright (c) 2014. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Skylight
{
    /// <summary>
    ///     Class BlockIds.
    /// </summary>
    public static class BlockIds
    {
        /// <summary>
        ///     Class Action.
        /// </summary>
        public static class Action
        {
            /// <summary>
            ///     The layer that the block is on. Default is foreground.
            /// </summary>
            public const int Layer = 0;

            /// <summary>
            ///     Class Boost.
            /// </summary>
            public static class Boost
            {
                /// <summary>
                ///     The directions.
                /// </summary>
                public const int
                    Left = 114,
                    Right = 115,
                    Up = 116,
                    Down = 117;
            }

            /// <summary>
            ///     Class Cake.
            /// </summary>
            public static class Cake
            {
                /// <summary>
                ///     The cake
                /// </summary>
                public const int
                    CAKE = 337;
            }

            /// <summary>
            ///     Class Coins.
            /// </summary>
            public static class Coins
            {
                /// <summary>
                ///     The colors of coins.
                /// </summary>
                public const int
                    Gold = 100,
                    Blue = 101;
            }

            /// <summary>
            ///     Class Crowns.
            /// </summary>
            public static class Crowns
            {
                /// <summary>
                ///     The gold crown is the only one.
                /// </summary>
                public const int
                    Gold = 5;
            }

            /// <summary>
            ///     Class Diamond.
            /// </summary>
            public static class Diamond
            {
                /// <summary>
                ///     The diamond block
                /// </summary>
                public const int
                    Diamondblock = 241;
            }

            /// <summary>
            ///     Class Doors.
            /// </summary>
            public static class Doors
            {
                /// <summary>
                ///     The types of doors that are available. All doors require that the player
                ///     triggers an event. For example, the red door requires that the red key
                ///     has been pressed in order for it to close.
                /// </summary>
                public const int
                    Red = 23,
                    Green = 24,
                    Blue = 25,
                    Coin = 43,
                    Time = 156,
                    Switch = 184,
                    Club = 200,
                    Zombie = 207;
            }

            /// <summary>
            ///     Class Gates.
            /// </summary>
            public static class Gates
            {
                /// <summary>
                ///     The gates are the inverse of the doors. This means that when the red
                ///     key is pressed the red gate will open.
                /// </summary>
                public const int
                    Red = 26,
                    Green = 27,
                    Blue = 28,
                    Coin = 165,
                    Time = 157,
                    Switch = 185,
                    Club = 201,
                    Zombie = 206;
            }

            /// <summary>
            ///     Class Gravity.
            /// </summary>
            public static class Gravity
            {
                /// <summary>
                ///     Types of gravity (pseudonym of boost)
                /// </summary>
                public const int
                    Down = 0,
                    Left = 1,
                    Up = 2,
                    Right = 3,
                    Zero = 4;
            }

            /// <summary>
            ///     Class Hazards.
            /// </summary>
            public static class Hazards
            {
                /// <summary>
                ///     Upon touching spikes or fire will immediately trigger a respawn.
                /// </summary>
                public const int
                    Spike = 361,
                    Fire = 368;
            }

            /// <summary>
            ///     Class Keys.
            /// </summary>
            public static class Keys
            {
                /// <summary>
                ///     The red, green and blue keys.
                /// </summary>
                public const int
                    Red = 6,
                    Green = 7,
                    Blue = 8;
            }

            /// <summary>
            ///     Class Ladders.
            /// </summary>
            public static class Ladders
            {
                /// <summary>
                ///     The chain, ladder and vines.
                /// </summary>
                public const int
                    Chain = 118,
                    Ladder = 120,
                    Verticalvine = 98,
                    Horizontalvine = 99;
            }

            /// <summary>
            ///     Class Liquids.
            /// </summary>
            public static class Liquids
            {
                /// <summary>
                ///     The water or mud.
                /// </summary>
                public const int
                    Water = 119,
                    Mud = 173;
            }

            /// <summary>
            ///     Class Music.
            /// </summary>
            public static class Music
            {
                /// <summary>
                ///     The piano or percussion.
                /// </summary>
                public const int
                    Piano = 77,
                    Percussion = 83;
            }

            /// <summary>
            ///     Class Portals.
            /// </summary>
            public static class Portals
            {
                /// <summary>
                ///     The invisible, normal or world portal.
                /// </summary>
                public const int
                    Invisible = 381,
                    Normal = 242,
                    World = 374;
            }

            /// <summary>
            ///     Class Sign. Signs can be read by a player going over top of it.
            /// </summary>
            public static class Sign
            {
                /// <summary>
                ///     The text sign.
                /// </summary>
                public const int
                    Textsign = 385;
            }

            /// <summary>
            ///     Class Switches.
            /// </summary>
            public static class Switches
            {
                /// <summary>
                ///     The switch.
                /// </summary>
                public const int
                    Switch = 113;
            }

            /// <summary>
            ///     Class Tools.
            /// </summary>
            public static class Tools
            {
                /// <summary>
                ///     A regular spawn point. Players spawn here if they die or enter the room.
                ///     Having multiple spawn points will cause the players to spawn at a different one
                ///     each time.
                /// </summary>
                public const int
                    Spawn = 255;

                /// <summary>
                ///     Respawns the player at the most recent checkpoint that they touched
                ///     when they die. Resets when the player leaves the room.
                /// </summary>
                public const int
                    Checkpoint = 360;

                /// <summary>
                ///     A trophy. Not a spawn point.
                /// </summary>
                public const int
                    Trophy = 121;
            }
        }

        /// <summary>
        ///     Class Background.
        /// </summary>
        public static class Background
        {
            /// <summary>
            ///     The layer. By default the backgrounds are on the background layer (layer 1).
            /// </summary>
            public const int
                Layer = 1;

            /// <summary>
            ///     Class Basic.
            /// </summary>
            public static class Basic
            {
                /// <summary>
                ///     The different colored backgrounds.
                /// </summary>
                public const int
                    Gray = 500,
                    Blue = 501,
                    Purple = 502,
                    Red = 503,
                    Yellow = 504,
                    Green = 505,
                    Cyan = 506;
            }

            /// <summary>
            ///     Class Brick.
            /// </summary>
            public static class Brick
            {
                /// <summary>
                ///     The different colors of brick.
                /// </summary>
                public const int
                    Orange = 507,
                    Teal = 508,
                    Purple = 509,
                    Green = 510,
                    Red = 511,
                    Tan = 512;
            }

            /// <summary>
            ///     Class Candy.
            /// </summary>
            public static class Candy
            {
                /// <summary>
                ///     The different colors of candy.
                /// </summary>
                public const int
                    Pink = 539,
                    Blue = 540;
            }

            /// <summary>
            ///     Class Canvas.
            /// </summary>
            public static class Canvas
            {
                /// <summary>
                ///     The different colors of the canvas background.
                /// </summary>
                public const int
                    Red = 533,
                    Tan = 534,
                    Gold = 535,
                    Lime = 536,
                    Blue = 537,
                    Gray = 538;
            }

            /// <summary>
            ///     Class Carnival.
            /// </summary>
            public static class Carnival
            {
                /// <summary>
                ///     The different types of carnival colors.
                /// </summary>
                public const int
                    Redstripe = 545,
                    Bluestripe = 546,
                    Pink = 547,
                    Checker = 548,
                    Green = 549;
            }

            /// <summary>
            ///     Class Castle.
            /// </summary>
            public static class Castle
            {
                /// <summary>
                ///     The brick. There is only one castle block.
                /// </summary>
                public const int
                    Bricks = 599;
            }

            /// <summary>
            ///     Class Checker.
            /// </summary>
            public static class Checker
            {
                /// <summary>
                ///     The different colors of the checker block.
                /// </summary>
                public const int
                    Gray = 513,
                    Blue = 514,
                    Purple = 515,
                    Red = 516,
                    Yellow = 517,
                    Green = 518,
                    Cyan = 519;
            }

            /// <summary>
            ///     Class Christmas 2012.
            /// </summary>
            public static class Christmas2012
            {
                /// <summary>
                ///     The different patterns available.
                /// </summary>
                public const int
                    Yellowpattern = 624,
                    Greenpattern = 625,
                    Bluepattern = 626;
            }

            /// <summary>
            ///     Class Cowboy.
            /// </summary>
            public static class Cowboy
            {
                /// <summary>
                ///     The different building materials inspired by this theme.
                /// </summary>
                public const int
                    Brownplank = 568,
                    Darkbrownplank = 569,
                    Redplank = 570,
                    Darkredplank = 571,
                    Blueplank = 572,
                    Darkblueplank = 573;
            }

            /// <summary>
            ///     Class Dark.
            /// </summary>
            public static class Dark
            {
                /// <summary>
                ///     The darker colors (darker from basic).
                /// </summary>
                public const int
                    Gray = 520,
                    Blue = 521,
                    Purple = 522,
                    Red = 523,
                    Yellow = 524,
                    Green = 525,
                    Cyan = 526;
            }

            /// <summary>
            ///     Class Halloween 2011.
            /// </summary>
            public static class Halloween2011
            {
                /// <summary>
                ///     The different building materials for Halloween.
                /// </summary>
                public const int
                    Wall = 541,
                    Brick = 542,
                    Leftcornerstair = 543,
                    Rightcornerstair = 544;
            }

            /// <summary>
            ///     Class Jungle.
            /// </summary>
            public static class Jungle
            {
                /// <summary>
                ///     The different types of plants.
                /// </summary>
                public const int
                    Brightplants = 621,
                    Plants = 622,
                    Darkplants = 623;
            }

            /// <summary>
            ///     Class Jungle Ruins.
            /// </summary>
            public static class JungleRuins
            {
                /// <summary>
                ///     The blocks that are used when the jungle is ruined.
                /// </summary>
                public const int
                    Gray = 617,
                    Red = 618,
                    Blue = 619,
                    Yellow = 620;
            }

            /// <summary>
            ///     Class Lava.
            /// </summary>
            public static class Lava
            {
                /// <summary>
                ///     The different types of lava colors.
                /// </summary>
                public const int
                    Yellow = 627,
                    Orange = 628,
                    Red = 629;
            }

            /// <summary>
            ///     Class Mars.
            /// </summary>
            public static class Mars
            {
                /// <summary>
                ///     These are space themed.
                /// </summary>
                public const int
                    Blue = 605,
                    Littlestar = 606,
                    Bigstar = 607;
            }

            /// <summary>
            ///     Class Medieval.
            /// </summary>
            public static class Medieval
            {
                /// <summary>
                ///     There is only one block, and it's name is planks.
                /// </summary>
                public const int
                    Planks = 600;
            }

            /// <summary>
            ///     Class Monster.
            /// </summary>
            public static class Monster
            {
                /// <summary>
                ///     The different types of fur available.
                /// </summary>
                public const int
                    Lightfur = 608,
                    Darkfur = 609;
            }

            /// <summary>
            ///     Class Ninja.
            /// </summary>
            public static class Ninja
            {
                /// <summary>
                ///     The types of ninja building materials. These materials are
                ///     based on housing material.
                /// </summary>
                public const int
                    White = 564,
                    Gray = 565,
                    Lightshingles = 566,
                    Darkshingles = 567;
            }

            /// <summary>
            ///     Class Normal.
            /// </summary>
            public static class Normal
            {
                /// <summary>
                ///     The diferent colors of normal blocks.
                /// </summary>
                public const int
                    Gray = 610,
                    Blue = 611,
                    Purple = 612,
                    Red = 613,
                    Yellow = 614,
                    Green = 615,
                    Cyan = 616;
            }

            /// <summary>
            ///     Class Pastel.
            /// </summary>
            public static class Pastel
            {
                /// <summary>
                ///     The pastel blocks
                /// </summary>
                public const int
                    Orange = 527,
                    Green = 528,
                    Yellow = 529,
                    Cyan = 530,
                    Blue = 531,
                    Red = 532;
            }

            /// <summary>
            ///     Class Pirate.
            /// </summary>
            public static class Pirate
            {
                /// <summary>
                ///     The types of pirate blocks. Themed from the pirate ship.
                /// </summary>
                public const int
                    Darkplank = 554,
                    Lightplank = 555,
                    Peggedplank = 556,
                    Lifesaver = 557,
                    Window = 558,
                    Cannon = 559,
                    Flag = 560;
            }

            /// <summary>
            ///     Class Plate Iron.
            /// </summary>
            public static class PlateIron
            {
                /// <summary>
                ///     The different colors of plate iron.
                /// </summary>
                public const int
                    Plain = 585,
                    Gray = 586,
                    Grey = 586,
                    Blue = 587,
                    Green = 588,
                    Orange = 589;
            }

            /// <summary>
            ///     Class Prison.
            /// </summary>
            public static class Prison
            {
                /// <summary>
                ///     The types of prison blocks.
                /// </summary>
                public const int
                    Brick = 550,
                    Window = 551,
                    Bars = 552,
                    Brokenbars = 553;
            }

            /// <summary>
            ///     Class Rocket.
            /// </summary>
            public static class Rocket
            {
                /// <summary>
                ///     The types of rocket blocks.
                /// </summary>
                public const int
                    Gray = 601,
                    Blue = 602,
                    Green = 603,
                    Red = 604;
            }

            /// <summary>
            ///     Class Sand.
            /// </summary>
            public static class Sand
            {
                /// <summary>
                ///     The different colors of sand.
                /// </summary>
                public const int
                    White = 579,
                    Gray = 580,
                    Yellow = 581,
                    Orange = 582,
                    Tan = 583,
                    Brown = 584;
            }

            /// <summary>
            ///     Class Sci-Fi 2013.
            /// </summary>
            public static class SciFi2013
            {
                /// <summary>
                ///     The tile block. There is only one block.
                /// </summary>
                public const int
                    Tile = 637;
            }

            /// <summary>
            ///     Class Sparta.
            /// </summary>
            public static class Sparta
            {
                /// <summary>
                ///     The different colors of sparta blocks.
                /// </summary>
                public const int
                    Blue = 638,
                    Green = 639,
                    Red = 640;
            }

            /// <summary>
            ///     Class Swamp.
            /// </summary>
            public static class Swamp
            {
                /// <summary>
                ///     The underbrush block.
                /// </summary>
                public const int
                    Underbrush = 630;
            }

            /// <summary>
            ///     Class Timbered.
            /// </summary>
            public static class Timbered
            {
                /// <summary>
                ///     The different types of wooden blocks. Meant to be made in
                ///     a house-type of way.
                /// </summary>
                public const int
                    Thatchroof = 590,
                    Redshingles = 591,
                    Tealshingles = 592,
                    Vsupport = 593,
                    Leftdiagonalsupport = 594,
                    Rightdiagonalsupport = 595,
                    Horizontalsupport = 596,
                    Tsupport = 597,
                    Closedwindow = 598;
            }

            /// <summary>
            ///     Class Vikings.
            /// </summary>
            public static class Vikings
            {
                /// <summary>
                ///     The viking blocks.
                /// </summary>
                public const int
                    Fullbrick = 561,
                    Halfbrick = 562,
                    Redwhitestripes = 563;
            }

            /// <summary>
            ///     Class Water.
            /// </summary>
            public static class Water
            {
                /// <summary>
                ///     The ocean-themed blocks.
                /// </summary>
                public const int
                    Plain = 574,
                    Squid = 575,
                    Fish = 576,
                    Seahorse = 577,
                    Seaweed = 578;
            }
        }

        /// <summary>
        ///     Class Blocks.
        /// </summary>
        public static class Blocks
        {
            /// <summary>
            ///     The default foreground layer.
            /// </summary>
            public const int Layer = 0;

            /// <summary>
            ///     Class Basic.
            /// </summary>
            public static class Basic
            {
                /// <summary>
                ///     The different types of basic blocks.
                /// </summary>
                public const int
                    Gray = 9,
                    Blue = 10,
                    Purple = 11,
                    Red = 12,
                    Yellow = 13,
                    Green = 14,
                    Cyan = 15,
                    Darkgray = 182;
            }

            /// <summary>
            ///     Class Beta.
            /// </summary>
            public static class Beta
            {
                /// <summary>
                ///     The different colors of beta blocks. Beta blocks are only
                ///     available to beta members.
                /// </summary>
                public const int
                    Purple = 37,
                    Green = 38,
                    Blue = 39,
                    Red = 40,
                    Gold = 41,
                    Gray = 42;
            }

            /// <summary>
            ///     Class Brick.
            /// </summary>
            public static class Brick
            {
                /// <summary>
                ///     The bricks colors.
                /// </summary>
                public const int
                    Orange = 16,
                    Teal = 17,
                    Purple = 18,
                    Green = 19,
                    Red = 20,
                    Tan = 21;
            }

            /// <summary>
            ///     Class Candy.
            /// </summary>
            public static class Candy
            {
                /// <summary>
                ///     The different types of candy.
                /// </summary>
                public const int
                    Pink = 60,
                    Candycane = 65,
                    Candycorn = 66,
                    Gingerbread = 67;

                /// <summary>
                ///     Class One way. One way blocks mean that the player can only
                ///     jump through the block and cannot go the opposite way through it
                ///     except sometimes sideways.
                /// </summary>
                public static class Oneway
                {
                    /// <summary>
                    ///     The pink oneway block
                    /// </summary>
                    public const int
                        PINK = 61;

                    /// <summary>
                    ///     The red oneway block
                    /// </summary>
                    public const int
                        Red = 62;

                    /// <summary>
                    ///     The cyan oneway block
                    /// </summary>
                    public const int
                        Cyan = 63;

                    /// <summary>
                    ///     The green oneway block
                    /// </summary>
                    public const int
                        Green = 64;
                }
            }

            /// <summary>
            ///     Class Castle.
            /// </summary>
            public static class Castle
            {
                /// <summary>
                ///     The brick
                /// </summary>
                public const int
                    Brick = 159,
                    Window = 160;

                /// <summary>
                ///     Class Oneway.
                /// </summary>
                public static class Oneway
                {
                    /// <summary>
                    ///     The gray
                    /// </summary>
                    public const int
                        Gray = 158;
                }
            }

            /// <summary>
            ///     Class Checker.
            /// </summary>
            public static class Checker
            {
                /// <summary>
                ///     The different color of checkers.
                /// </summary>
                public const int
                    Gray = 186,
                    Blue = 187,
                    Purple = 188,
                    Red = 189,
                    Yellow = 190,
                    Green = 191,
                    Cyan = 192;
            }

            /// <summary>
            ///     Class Christmas.
            /// </summary>
            public static class Christmas
            {
                /// <summary>
                ///     The types of christmas blocks.
                /// </summary>
                public const int
                    Yellow = 78,
                    White = 79,
                    Red = 80,
                    Blue = 81,
                    Green = 82;
            }

            /// <summary>
            ///     Class Cloud.
            /// </summary>
            public static class Cloud
            {
                /// <summary>
                ///     The white cloud.
                /// </summary>
                public const int
                    White = 143;
            }

            /// <summary>
            ///     Class Cowboy.
            /// </summary>
            public static class Cowboy
            {
                /// <summary>
                ///     The cowboy themed blocks.
                /// </summary>
                public const int
                    Tan = 125,
                    Red = 126,
                    Blue = 127;

                /// <summary>
                ///     Class Oneway.
                /// </summary>
                public static class Oneway
                {
                    /// <summary>
                    ///     The tan
                    /// </summary>
                    public const int
                        TAN = 122;

                    /// <summary>
                    ///     The tan
                    /// </summary>
                    public const int
                        RED = 123;

                    /// <summary>
                    ///     The tan
                    /// </summary>
                    public const int
                        BLUE = 124;
                }
            }

            /// <summary>
            ///     Class Factory.
            /// </summary>
            public static class Factory
            {
                /// <summary>
                ///     The tancross
                /// </summary>
                public const int
                    Tancross = 45,
                    Planks = 46,
                    Sandpaper = 47,
                    Browncross = 48,
                    Fishscales = 49;
            }

            /// <summary>
            ///     Class Farm.
            /// </summary>
            public static class Farm
            {
                /// <summary>
                ///     The hay
                /// </summary>
                public const int
                    Hay = 212;
            }

            /// <summary>
            ///     Class Glass.
            /// </summary>
            public static class Glass
            {
                /// <summary>
                ///     The red
                /// </summary>
                public const int
                    Red = 51,
                    Purple = 52,
                    Indigo = 53,
                    Blue = 54,
                    Cyan = 55,
                    Green = 56,
                    Yellow = 57,
                    Orange = 58;
            }

            /// <summary>
            ///     Class Grass.
            /// </summary>
            public static class Grass
            {
                /// <summary>
                ///     The left
                /// </summary>
                public const int
                    Left = 34,
                    Middle = 35,
                    Right = 36;
            }

            /// <summary>
            ///     Class Halloween.
            /// </summary>
            public static class Halloween
            {
                /// <summary>
                ///     The blood
                /// </summary>
                public const int
                    Blood = 68,
                    Brick = 69;
            }

            /// <summary>
            ///     Class Industrial.
            /// </summary>
            public static class Industrial
            {
                /// <summary>
                ///     The crosssupport
                /// </summary>
                public const int
                    Crosssupport = 147,
                    Elevator = 148,
                    Support = 149,
                    Leftconveyor = 150,
                    Supportedmiddleconveyor = 151,
                    Middleconveyor = 152,
                    Rightconveyor = 153;

                /// <summary>
                ///     Class Oneway.
                /// </summary>
                public static class Oneway
                {
                    /// <summary>
                    ///     The platform
                    /// </summary>
                    public const int
                        Platform = 146;
                }
            }

            /// <summary>
            ///     Class JungleRuins.
            /// </summary>
            public static class JungleRuins
            {
                /// <summary>
                ///     The head
                /// </summary>
                public const int
                    Head = 193,
                    Gray = 195,
                    Red = 196,
                    Blue = 197,
                    Yellow = 198,
                    Pot = 199;

                /// <summary>
                ///     Class Oneway.
                /// </summary>
                public static class Oneway
                {
                    /// <summary>
                    ///     The gray
                    /// </summary>
                    public const int
                        GRAY = 194;
                }
            }

            /// <summary>
            ///     Class Lava.
            /// </summary>
            public static class Lava
            {
                /// <summary>
                ///     The yellow
                /// </summary>
                public const int
                    Yellow = 202,
                    Orange = 203,
                    Darkorange = 204;
            }

            /// <summary>
            ///     Class Mars.
            /// </summary>
            public static class Mars
            {
                /// <summary>
                ///     The sand
                /// </summary>
                public const int
                    Sand = 176,
                    Pattern1 = 177,
                    Pattern2 = 178,
                    Pattern3 = 179,
                    Rock1 = 180,
                    Rock2 = 181;
            }

            /// <summary>
            ///     Class Medieval.
            /// </summary>
            public static class Medieval
            {
                /// <summary>
                ///     The types of medieval weapons
                /// </summary>
                public const int
                    Anvil = 162,
                    Barrel = 163;
            }

            /// <summary>
            ///     Class Metal.
            /// </summary>
            public static class Metal
            {
                /// <summary>
                ///     The types of metal
                /// </summary>
                public const int
                    Silver = 29,
                    Bronze = 30,
                    Gold = 31;
            }

            /// <summary>
            ///     Class Minerals.
            /// </summary>
            public static class Minerals
            {
                /// <summary>
                ///     The red
                /// </summary>
                public const int
                    Red = 70,
                    Pink = 71,
                    Blue = 72,
                    Cyan = 73,
                    Green = 74,
                    Yellow = 75,
                    Orange = 76;
            }

            /// <summary>
            ///     Class Ninja.
            /// </summary>
            public static class Ninja
            {
                /// <summary>
                ///     Class Oneway.
                /// </summary>
                public static class Oneway
                {
                    /// <summary>
                    ///     The different colors of shingles
                    /// </summary>
                    public const int
                        White = 96,
                        Gray = 97;
                }
            }

            /// <summary>
            ///     Class Pipes.
            /// </summary>
            public static class Pipes
            {
                /// <summary>
                ///     The directions of the pipes
                /// </summary>
                public const int
                    Left = 166,
                    Horizontal = 167,
                    Right = 168,
                    Up = 169,
                    Vertical = 170,
                    Down = 171;
            }

            /// <summary>
            ///     Class Pirate.
            /// </summary>
            public static class Pirate
            {
                /// <summary>
                ///     The plank and chest
                /// </summary>
                public const int
                    Planks = 93,
                    Chest = 94;
            }

            /// <summary>
            ///     Class Plastic.
            /// </summary>
            public static class Plastic
            {
                /// <summary>
                ///     The different colors of plastic
                /// </summary>
                public const int
                    Lime = 128,
                    Red = 129,
                    Yellow = 130,
                    Cyan = 131,
                    Blue = 132,
                    Pink = 133,
                    Green = 134,
                    Orange = 135;
            }

            /// <summary>
            ///     Class Plate Iron.
            /// </summary>
            public static class PlateIron
            {
                /// <summary>
                ///     The plate iron types.
                /// </summary>
                public const int
                    Plateiron = 144,
                    Wires = 145;
            }

            /// <summary>
            ///     Class Prison.
            /// </summary>
            public static class Prison
            {
                /// <summary>
                ///     The prison brick
                /// </summary>
                public const int
                    Brick = 92;
            }

            /// <summary>
            ///     Class Rocket.
            /// </summary>
            public static class Rocket
            {
                /// <summary>
                ///     The colors of a rocket.
                /// </summary>
                public const int
                    White = 172,
                    Blue = 173,
                    Green = 174,
                    Red = 175;
            }

            /// <summary>
            ///     Class Sand.
            /// </summary>
            public static class Sand
            {
                /// <summary>
                ///     The types of sand colors
                /// </summary>
                public const int
                    White = 137,
                    Gray = 138,
                    Lighttan = 139,
                    Orange = 140,
                    Tan = 141,
                    Brown = 142;
            }

            /// <summary>
            ///     Class Sci-fi.
            /// </summary>
            public static class Scifi
            {
                /// <summary>
                ///     The colors of regular scifi blocks
                /// </summary>
                public const int
                    Red = 84,
                    Blue = 85,
                    Gray = 86,
                    White = 87,
                    Brown = 88;

                /// <summary>
                ///     Class One way.
                /// </summary>
                public static class Oneway
                {
                    /// <summary>
                    ///     The colors of oneway blocks
                    /// </summary>
                    public const int
                        RED = 89,
                        BLUE = 90,
                        Green = 91;
                }
            }

            /// <summary>
            ///     Class Secrets.
            /// </summary>
            public static class Secrets
            {
                /// <summary>
                ///     The types of secret blocks.
                /// </summary>
                public const int
                    Solid = 50,
                    NONSOLID = 243;
            }

            /// <summary>
            ///     Class Sparta.
            /// </summary>
            public static class Sparta
            {
                /// <summary>
                ///     The different spartian colors.
                /// </summary>
                public const int
                    Blue = 208,
                    Green = 209,
                    Red = 210,
                    Pillar = 211;
            }

            /// <summary>
            ///     Class Special.
            /// </summary>
            public static class Special
            {
                /// <summary>
                ///     The special blocks
                /// </summary>
                public const int
                    Striped = 22,
                    Face = 32,
                    Glossyblack = 33,
                    Fullyblack = 44;
            }

            /// <summary>
            ///     Class Summer 2011.
            /// </summary>
            public static class Summer2011
            {
                /// <summary>
                ///     The sand
                /// </summary>
                public const int
                    Sand = 59;
            }

            /// <summary>
            ///     Class Timbered.
            /// </summary>
            public static class Timbered
            {
                /// <summary>
                ///     Class Oneway.
                /// </summary>
                public static class Oneway
                {
                    /// <summary>
                    ///     The timbered oneway block
                    /// </summary>
                    public const int
                        Timbered = 154;
                }
            }

            /// <summary>
            ///     Class Viking.
            /// </summary>
            public static class Viking
            {
                /// <summary>
                ///     The gray
                /// </summary>
                public const int
                    Gray = 95;
            }
        }

        /// <summary>
        ///     Class Decorative.
        /// </summary>
        public static class Decorative
        {
            /// <summary>
            ///     The layer
            /// </summary>
            public const int Layer = 0;

            /// <summary>
            ///     Class Candy.
            /// </summary>
            public static class Candy
            {
                /// <summary>
                ///     The topping
                /// </summary>
                public const int
                    Topping = 227;
            }

            /// <summary>
            ///     Class Castle.
            /// </summary>
            public static class Castle
            {
                /// <summary>
                ///     The roof support
                /// </summary>
                public const int
                    Roofsupport = 325,
                    Merlon = 326;
            }

            /// <summary>
            ///     Class Christmas 2010.
            /// </summary>
            public static class Christmas2010
            {
                /// <summary>
                ///     The building materials
                /// </summary>
                public const int
                    Rightcornersnow = 249,
                    Leftcornersnow = 250,
                    Tree = 251,
                    Snowytree = 252,
                    Snowyfence = 253,
                    Fence = 254;
            }

            /// <summary>
            ///     Class Christmas 2011.
            /// </summary>
            public static class Christmas2011
            {
                /// <summary>
                ///     The ordaments
                /// </summary>
                public const int
                    Redornament = 218,
                    Greenornament = 219,
                    Blueornament = 220,
                    Wreath = 221,
                    Star = 222;
            }

            /// <summary>
            ///     Class Christmas 2012.
            /// </summary>
            public static class Christmas2012
            {
                /// <summary>
                ///     The types of ribbons
                /// </summary>
                public const int
                    Blueverticalribbon = 362,
                    Bluehorizontalribbon = 363,
                    Bluecrossedribbon = 364,
                    Redverticalribbon = 365,
                    Redhorizontalribbon = 366,
                    Redcrossedribbon = 367;
            }

            /// <summary>
            ///     Class Cloud.
            /// </summary>
            public static class Cloud
            {
                /// <summary>
                ///     The different pieces of a cloud
                /// </summary>
                public const int
                    Bottom = 311,
                    Top = 312,
                    Right = 313,
                    Left = 314,
                    Bottomleftcorner = 315,
                    Bottomrightcorner = 316,
                    Toprightcorner = 317,
                    Topleftcorner = 318;
            }

            /// <summary>
            ///     Class Cowboy.
            /// </summary>
            public static class Cowboy
            {
                /// <summary>
                ///     The types of bars and rails
                /// </summary>
                public const int
                    Whitebar = 285,
                    Graybar = 286,
                    Leftbrowndoor = 287,
                    Rightbrowndoor = 288,
                    Leftreddoor = 289,
                    Rightreddoor = 290,
                    Leftbluedoor = 291,
                    Rightbluedoor = 292,
                    Curtains = 293,
                    Lightbrownrail = 294,
                    Darkbrownrail = 295,
                    Lightredrail = 296,
                    Darkredrail = 297,
                    Cyanrail = 298,
                    Darkbluerail = 299;
            }

            /// <summary>
            ///     Class Easter 2012.
            /// </summary>
            public static class Easter2012
            {
                /// <summary>
                ///     The colors of the eggs
                /// </summary>
                public const int
                    Blue = 256,
                    Purple = 257,
                    Yellow = 258,
                    Red = 259,
                    Green = 260;
            }

            /// <summary>
            ///     Class Farm.
            /// </summary>
            public static class Farm
            {
                /// <summary>
                ///     The farm supplies
                /// </summary>
                public const int
                    Hay = 386,
                    Corn = 387,
                    Leftfence = 388,
                    Rightfence = 389;
            }

            /// <summary>
            ///     Class Fog.
            /// </summary>
            public static class Fog
            {
                /// <summary>
                ///     The pieces of a fog
                /// </summary>
                public const int
                    Full = 343,
                    Bottom = 344,
                    Top = 345,
                    Right = 346,
                    Left = 347,
                    Bottomleftcorner = 348,
                    Bottomrightcorner = 349,
                    Toprightcorner = 350,
                    Topleftcorner = 351;
            }

            /// <summary>
            ///     Class Halloween 2011.
            /// </summary>
            public static class Halloween2011
            {
                /// <summary>
                ///     The tombstone and spider web pieces
                /// </summary>
                public const int
                    Tombstone = 224,
                    Leftcornerweb = 225,
                    Rightcornerweb = 226;
            }

            /// <summary>
            ///     Class Halloween2012.
            /// </summary>
            public static class Halloween2012
            {
                /// <summary>
                ///     The teslacap
                /// </summary>
                public const int
                    Teslacap = 352,
                    Teslacoil = 353,
                    Verticalwires = 354,
                    Horizontalwires = 355,
                    Electricity = 356;
            }

            /// <summary>
            ///     Class Jungle.
            /// </summary>
            public static class Jungle
            {
                /// <summary>
                ///     The undergrowth
                /// </summary>
                public const int
                    Undergrowth = 357,
                    Log = 358,
                    Idol = 359;
            }

            /// <summary>
            ///     Class Mars.
            /// </summary>
            public static class Mars
            {
                /// <summary>
                ///     The rock
                /// </summary>
                public const int
                    Rock = 336;
            }

            /// <summary>
            ///     Class Medieval.
            /// </summary>
            public static class Medieval
            {
                /// <summary>
                ///     The blueflag
                /// </summary>
                public const int
                    Blueflag = 327,
                    Redflag = 328,
                    Sword = 329,
                    Shield = 330,
                    Rocks = 331;
            }

            /// <summary>
            ///     Class Monster.
            /// </summary>
            public static class Monster
            {
                /// <summary>
                ///     The pieces of a monster
                /// </summary>
                public const int
                    Bigtoothbottom = 338,
                    Smallteethbottom = 339,
                    Smallteethtop = 340,
                    Orangeeye = 341,
                    Blueeye = 342;
            }

            /// <summary>
            ///     Class New Year 2010.
            /// </summary>
            public static class NewYear2010
            {
                /// <summary>
                ///     The colors of a New Year's celebration
                /// </summary>
                public const int
                    Purple = 244,
                    Yellow = 245,
                    Blue = 246,
                    Red = 247,
                    Green = 248;
            }

            /// <summary>
            ///     Class Ninja.
            /// </summary>
            public static class Ninja
            {
                /// <summary>
                ///     The various ninja blocks
                /// </summary>
                public const int
                    Leftbrightrooftop = 276,
                    Rightbrightrooftop = 277,
                    Brightwindow = 278,
                    Leftdarkrooftop = 279,
                    Rightdarkrooftop = 280,
                    Darkwindow = 281,
                    Ladder = 282,
                    Antennae = 283,
                    Yinyang = 284;
            }

            /// <summary>
            ///     Class Priate.
            /// </summary>
            public static class Priate
            {
                /// <summary>
                ///     The canoncover
                /// </summary>
                public const int
                    Canoncover = 271,
                    Skull = 272;
            }

            /// <summary>
            ///     Class Prison.
            /// </summary>
            public static class Prison
            {
                /// <summary>
                ///     The bars
                /// </summary>
                public const int
                    Bars = 261;
            }

            /// <summary>
            ///     Class Rocket.
            /// </summary>
            public static class Rocket
            {
                /// <summary>
                ///     The computer screen and rocket controls
                /// </summary>
                public const int
                    Computerscreen = 332,
                    Redlight = 333,
                    Bluelight = 334,
                    Controlpanel = 335;
            }

            /// <summary>
            ///     Class Sand.
            /// </summary>
            public static class Sand
            {
                /// <summary>
                ///     The colors of sand
                /// </summary>
                public const int
                    White = 301,
                    Gray = 302,
                    Lighttan = 303,
                    Orange = 304,
                    Tan = 305,
                    Brown = 306;
            }

            /// <summary>
            ///     Class SciFi2013.
            /// </summary>
            public static class SciFi2013
            {
                /// <summary>
                ///     The bluebend
                /// </summary>
                public const int
                    Bluebend = 375,
                    Bluestraight = 376,
                    Orangebend = 377,
                    Orangestraight = 378,
                    Greenbend = 379,
                    Greenstraight = 380;
            }

            /// <summary>
            ///     Class Signs.
            /// </summary>
            public static class Signs
            {
                /// <summary>
                ///     The flame
                /// </summary>
                public const int
                    Flame = 319,
                    Skull = 320,
                    Bolt = 321,
                    Cross = 322,
                    Horizontalbar = 323,
                    Verticalbar = 324;
            }

            /// <summary>
            ///     Class Sparta.
            /// </summary>
            public static class Sparta
            {
                /// <summary>
                ///     The capital
                /// </summary>
                public const int
                    Capital = 382,
                    Shaft = 383,
                    Base = 384;
            }

            /// <summary>
            ///     Class Spring 2011.
            /// </summary>
            public static class Spring2011
            {
                /// <summary>
                ///     The types of plants
                /// </summary>
                public const int
                    Leftgrass = 233,
                    Middlegrass = 234,
                    Rightgrass = 235,
                    Leftbush = 236,
                    Middlebush = 237,
                    Rightbush = 238,
                    Flower = 239,
                    Shrub = 240;
            }

            /// <summary>
            ///     Class Summer 2011.
            /// </summary>
            public static class Summer2011
            {
                /// <summary>
                ///     The summer-themed blocks
                /// </summary>
                public const int
                    Umbrella = 228,
                    Rightcornersand = 229,
                    Leftcornersand = 230,
                    Rock = 231,
                    Bush = 232;
            }

            /// <summary>
            ///     Class Summer 2012.
            /// </summary>
            public static class Summer2012
            {
                /// <summary>
                ///     The ball
                /// </summary>
                public const int
                    Ball = 307,
                    Bucket = 308,
                    Shovel = 309,
                    Martini = 310;
            }

            /// <summary>
            ///     Class Swamp.
            /// </summary>
            public static class Swamp
            {
                /// <summary>
                ///     The mudbubbles
                /// </summary>
                public const int
                    Mudbubbles = 370,
                    Grass = 371,
                    Log = 372,
                    Sign = 373;
            }

            /// <summary>
            ///     Class Vikings.
            /// </summary>
            public static class Vikings
            {
                /// <summary>
                ///     The shields
                /// </summary>
                public const int
                    Redshield = 273,
                    Blueshield = 274,
                    Axe = 275;
            }

            /// <summary>
            ///     Class Water.
            /// </summary>
            public static class Water
            {
                /// <summary>
                ///     The waves
                /// </summary>
                public const int
                    Waves = 300;
            }

            /// <summary>
            ///     Class Windows.
            /// </summary>
            public static class Windows
            {
                /// <summary>
                ///     The clear
                /// </summary>
                public const int
                    Clear = 262,
                    Green = 263,
                    Teal = 264,
                    Blue = 265,
                    Purple = 266,
                    Pink = 267,
                    Red = 268,
                    Orange = 269,
                    Yellow = 270;
            }
        }
    }
}