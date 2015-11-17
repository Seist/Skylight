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

            public const int
                CAKE = 337;
            

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
                    Blue = 101,
                    GoldGate = 165,
                    GoldDoor = 43,
                    BlueGate = 214,
                    BlueDoor = 213;
            }

            public const int
                Diamondblock = 241;
            

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
                    LightBlue = 1005,
                    Purple = 1006,
                    Yellow = 1007;
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
                    LightBlue = 1008,
                    Purple = 1009,
                    Yellow = 1010;
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
                    Zero = 4,
                    InvisibleLeft = 411,
                    InvisibleUp = 412,
                    InvisibleRight = 413,
                    InvisibleZero = 414;
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
                    Blue = 8,
                    LightBlue = 408,
                    Purple = 409,
                    Yellow = 410;
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
                    Mud = 173,
                    Lava = 416;
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

            public const int
                Sign = 385;

            /// <summary>
            ///     Class Switches.
            /// </summary>
            public static class Switches
            {
                /// <summary>
                ///     The switch.
                /// </summary>
                public const int
                    Switch = 113,
                    Gate = 185,
                    Door = 184;
            }

            public static class Death
            {
                public const int
                    Gate = 1012,
                    Door = 1011;
            }

            public static class Zombie
            {
                public const int
                    Infector = 422,
                    Gate = 206,
                    Door = 207;
            }

            public static class Teams
            {
                public const int
                    Activator = 423,
                    Gate = 1028,
                    Door = 1027;
            }

            public static class Timed
            {
                public const int
                    Gate = 157,
                    Door = 156;
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
                    Crown = 5,
                    Spawn = 255,
                    Checkpoint = 360,
                    Trophy = 121;
            }

            public const int
                    Hologram = 397;

            public static class Effect
            {
                public const int
                    Jump = 417,
                    Fly = 418,
                    Speed = 419,
                    LowGravity = 453,
                    Protection = 420;
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
                    Cyan = 506,
                    DarkGray = 645,
                    Orange = 644;
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
                    Tan = 512,
                    Gray = 646,
                    DarkGray = 648;
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
                    Gray = 538,
                    Blue = 606,
                    Purple = 672,
                    Red = 671,
                    Orange = 533,
                    Yellow = 535,
                    Lime = 536,
                    LightBlue = 537,
                    Tan = 534;
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
                    RedYellowStripe = 545,
                    PurpleStripe = 546,
                    Pink = 547,
                    Checker = 548,
                    Green = 549,
                    Mustard = 558,
                    RedWhiteStripe = 563,
                    DarkBlue = 607;
            }

            public static class Stone
            {
                public const int
                    GrayWhole = 561,
                    GrayHalf = 562,
                    GreenWhole = 688,
                    GreenHalf = 689,
                    BrownWhole = 690,
                    BrownHalf = 691,
                    BlueWhole = 692,
                    BlueHalf = 693;
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
                    Cyan = 519,
                    Orange = 649,
                    DarkGray = 650;
            }

            /// <summary>
            ///     Class Cowboy.
            /// </summary>
            public static class WildWest
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
                    Cyan = 526,
                    Orange = 651,
                    DarkGray = 652;
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
                    Gray = 617,
                    Red = 618,
                    Blue = 619,
                    Yellow = 620,
                    Brightplants = 621,
                    Plants = 622,
                    Darkplants = 623;
            }

            public static class Christmas2012
            {
                public const int
                    Orange = 624,
                    Green = 625,
                    Blue = 626;
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
            ///     Class Medieval.
            /// </summary>
            public static class Medieval
            {
                /// <summary>
                ///     There is only one block, and it's name is planks.
                /// </summary>
                public const int
                    Bricks = 599,
                    Planks = 600,
                    Straw = 590,
                    RedThatch = 591,
                    TealThatch = 592,
                    BrownThatch = 556,
                    LightGray = 593;
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
                    Green = 608,
                    DarkGreen = 609,
                    Red = 663,
                    DarkRed = 664,
                    Purple = 665,
                    DarkPurple = 666;
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
                    BlueShingles = 566,
                    Darkshingles = 567,
                    RedShingles = 667,
                    DarkRedShingles = 668,
                    GreenShingles = 669,
                    DarkGreenShingles = 670;
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
                    Cyan = 616,
                    Orange = 653,
                    DarkGray = 654;
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
                    Yellow = 527,
                    Green = 528,
                    Lime = 529,
                    LightBlue = 530,
                    Blue = 531,
                    Red = 532,
                    Orange = 676,
                    Purple = 677;
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
                    Plank = 554,
                    Lightplank = 555,
                    DarkPlank = 559,
                    Flag = 560;
            }

            /// <summary>
            ///     Class Plate Iron.
            /// </summary>
            public static class Industrial
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
                    RedBars = 551,
                    BlueBars = 552,
                    DarkBars = 553;
            }

            /// <summary>
            ///     Class Rocket.
            /// </summary>
            public static class OuterSpace
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

            public static class Neon
            {
                public const int
                    Blue = 605,
                    Orange = 673,
                    Green = 674,
                    Magenta = 675;
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

            public static class Clay
            {
                public const int 
                    Plain = 594,
                    Brick = 595,
                    Diamond = 596,
                    Cross = 597,
                    Raw = 598;

            }

            public const int
                SciFi = 637;

            /// <summary>
            ///     Class Sparta.
            /// </summary>
            public static class Marble
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

            public static class Cave
            {
                public const int
                    Purple = 655,
                    Teal = 656,
                    Blue = 657,
                    Magenta = 658,
                    Green = 659,
                    Brown = 660,
                    Tan = 661,
                    Red = 662;
            }

            public static class Environment
            {
                public const int
                    RedWood = 678,
                    Grass = 679,
                    Bamboo = 680,
                    Blue = 681,
                    Red = 682;
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
                    Gray = 42,
                    LightBlue = 1019,
                    Orange = 1020,
                    DarkGray = 1021;
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
                    Tan = 21,
                    Gray = 1022,
                    Blue = 1023,
                    DarkGray = 1024;
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
                    Window = 160,
                    Anvil = 162,
                    Barrel = 163;
                
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
                    Cyan = 192,
                    DarkGray = 1026;
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
                    Plateiron = 144,
                    Wires = 145,
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
            public static class Desert
            {
                /// <summary>
                ///     The sand
                /// </summary>
                public const int
                    Pattern1 = 177,
                    Pattern2 = 178,
                    Pattern3 = 179,
                    Rock1 = 180,
                    Rock2 = 181;
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
            public static class Dojo
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
            public static class OuterSpace
            {
                /// <summary>
                ///     The colors of a rocket.
                /// </summary>
                public const int
                    White = 172,
                    Blue = 173,
                    Green = 174,
                    Red = 175,
                    Sand = 176,
                    DentedMetal = 1029;
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
                    LightTan = 139,
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
                    InvisibleUntilTouch = 50,
                    FullyBlackNonSolid = 243,
                    AlwaysInvisible = 136;
            }

            /// <summary>
            ///     Class Sparta.
            /// </summary>
            public static class Marble
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
            public static class Stone
            {
                /// <summary>
                ///     The gray
                /// </summary>
                public const int
                    Gray = 95,
                    Green = 1044,
                    Brown = 1045,
                    Blue = 1046;
            }

            public static class OneWay
            {
                public const int
                    Blue = 1001,
                    Red = 1002,
                    Yellow = 1003,
                    Purple = 1004;
            }

            public static class Environment
            {
                public const int
                    Wood = 1030,
                    Grass = 1031,
                    Bamboo = 1032,
                    Gray = 1033,
                    Red = 1034;
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
                    BrightRoofCornerLeft = 276,
                    BrightRoofCornerRight = 277,
                    BrightWindow = 278,
                    DarkRoofCornerLeft = 279,
                    DarkRoofCornerRight = 280,
                    DarkWindow = 281,
                    Character1 = 282,
                    Character2 = 283,
                    YinYang = 284;
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

            public static class Valentines2015
            {
                public const int
                    Red = 405,
                    Purple = 406,
                    Pink = 407;
            }
        }
    }
}