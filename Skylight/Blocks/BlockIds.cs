

namespace Skylight
{
    // TODO: should inherit from the Block class or vice-versa
    // turn this class into an enum because the class isn't really doing anything
    // besides storing data.
    public static class BlockIds
    {
        public const int LAYER = 0;

        enum Basic
        {
            GRAY = 9,
            BLUE = 10,
            PURPLE = 11,
            RED = 12,
            YELLOW = 13,
            GREEN = 14,
            CYAN = 15,
            DARKGRAY = 182,
        }

        enum Beta
        {
            PURPLE = 37,
            GREEN = 38,
            BLUE = 39,
            RED = 40,
            GOLD = 41,
            GRAY = 42,
        }

        enum Brick
        {
            ORANGE = 16,
            TEAL = 17,
            PURPLE = 18,
            GREEN = 19,
            RED = 20,
            TAN = 21,
        }

        enum Metal
        {
            SILVER = 29,
            BRONZE = 30,
            GOLD = 31,
        }

        enum Grass
        {
            LEFT = 34,
            MIDDLE = 35,
            RIGHT = 36,
        }

        enum Special
        {
            STRIPED = 22,
            FACE = 32,
            GLOSSYBLACK = 33,
            FULLYBLACK = 44,
        }

        enum Factory
        {
            TANCROSS = 45,
            PLANKS = 46,
            SANDPAPER = 47,
            BROWNCROSS = 48,
            FISHSCALES = 49,
        }

        enum Secrets
        {

            SOLID = 50,
            NONSOLID = 243
        }

        enum Glass
        {

            RED = 51,
            PURPLE = 52,
            INDIGO = 53,
            BLUE = 54,
            CYAN = 55,
            GREEN = 56,
            YELLOW = 57,
            ORANGE = 58,
        }

        enum Minerals
        {

            RED = 70,
            PINK = 71,
            BLUE = 72,
            CYAN = 73,
            GREEN = 74,
            YELLOW = 75,
            ORANGE = 76,
        }

        enum Christmas
        {

            YELLOW = 78,
            WHITE = 79,
            RED = 80,
            BLUE = 81,
            GREEN = 82,
        }

        enum Candy
        {

            PINK = 60,
            CANDYCANE = 65,
            CANDYCORN = 66,
            GINGERBREAD = 67,

            ONEWAY_PINK = 61,
            ONEWAY_RED = 62,
            ONEWAY_CYAN = 63,
            ONEWAY_GREEN = 64,

            TOPPING = 227,
            PINK = 539,
            BLUE = 540,

        }


        enum Halloween
        {

            BLOOD = 68,
            BRICK = 69,
        }

        enum Scifi
        {

            RED = 84,
            BLUE = 85,
            GRAY = 86,
            WHITE = 87,
            BROWN = 88,
            ONEWAY_RED = 89,
            ONEWAY_BLUE = 90,
            ONEWAY_GREEN = 91,

        }


        enum Pirate
        {

            PLANKS = 93,
            CHEST = 94,
        }

        enum Viking
        {

            GRAY = 95,
        }



        enum Plastic
        {

            LIME = 128,
            RED = 129,
            YELLOW = 130,
            CYAN = 131,
            BLUE = 132,
            PINK = 133,
            GREEN = 134,
            ORANGE = 135,
        }



        enum PlateIron
        {

            PLATEIRON = 144,
            WIRES = 145,
        }

        enum Industrial
        {

            CROSSSUPPORT = 147,
            ELEVATOR = 148,
            SUPPORT = 149,
            LEFTCONVEYOR = 150,
            SUPPORTEDMIDDLECONVEYOR = 151,
            MIDDLECONVEYOR = 152,
            RIGHTCONVEYOR = 153,


            PLATFORM = 146,

        }

        enum Timbered
        {
            TIMBERED = 154,

        }



        enum Pipes
        {

            LEFT = 166,
            HORIZONTAL = 167,
            RIGHT = 168,
            UP = 169,
            VERTICAL = 170,
            DOWN = 171,
        }

        enum Mars
        {

            SAND = 176,
            PATTERN1 = 177,
            PATTERN2 = 178,
            PATTERN3 = 179,
            ROCK1 = 180,
            ROCK2 = 181,
        }

        enum Checker
        {

            GRAY = 186,
            BLUE = 187,
            PURPLE = 188,
            RED = 189,
            YELLOW = 190,
            GREEN = 191,
            CYAN = 192,
        }

        enum JungleRuins
        {

            HEAD = 193,
            GRAY = 195,
            RED = 196,
            BLUE = 197,
            YELLOW = 198,
            POT = 199,

            GRAY = 194,

        }

        enum Lava
        {

            YELLOW = 202,
            ORANGE = 203,
            DARKORANGE = 204,
        }

        enum Sparta
        {

            BLUE = 208,
            GREEN = 209,
            RED = 210,
            PILLAR = 211,
        }

        enum Farm
        {

            HAY = 212,
        }


        enum Action
        {
            LAYER = 0,
            DIAMONDBLOCK = 241,
        }

        enum SIGN
        {

            TEXTSIGN = 385,
        }

        enum Keys
        {

            RED = 6,
            GREEN = 7,
            BLUE = 8,
        }

        enum Switches
        {

            SWITCH = 113,
        }

        enum Gates
        {

            RED = 26,
            GREEN = 27,
            BLUE = 28,
            COIN = 165,
            TIME = 157,
            SWITCH = 185,
            CLUB = 201,
            ZOMBIE = 206,

        }

        enum Doors
        {

            RED = 23,
            GREEN = 24,
            BLUE = 25,
            COIN = 43,
            TIME = 156,
            SWITCH = 184,
            CLUB = 200,
            ZOMBIE = 207,
        }

        enum Gravity
        {

            DOWN = 0,
            LEFT = 1,
            UP = 2,
            RIGHT = 3,
            ZERO = 4,
        }

        enum Boost
        {

            LEFT = 114,
            RIGHT = 115,
            UP = 116,
            DOWN = 117,
        }

        enum Music
        {

            PIANO = 77,
            PERCUSSION = 83,
        }

        enum Coins
        {

            GOLD = 100,
            BLUE = 101,
        }

        enum Crowns
        {

            GOLD = 5,
        }

        enum Tools
        {

            SPAWN = 255,
            CHECKPOINT = 360,
            TROPHY = 121,
        }

        enum Hazards
        {

            SPIKE = 361,
            FIRE = 368,
        }

        enum Ladders
        {

            CHAIN = 118,
            LADDER = 120,
            VERTICALVINE = 98,
            HORIZONTALVINE = 99,
        }

        enum Liquids
        {

            WATER = 119,
            MUD = 173,
        }

        enum Portals
        {

            INVISIBLE = 381,
            NORMAL = 242,
            WORLD = 374,
        }

        enum Cake
        {

            CAKE = 337,
        }


        enum Christmas2010
        {
            RIGHTCORNERSNOW = 249,
            LEFTCORNERSNOW = 250,
            TREE = 251,
            SNOWYTREE = 252,
            SNOWYFENCE = 253,
            FENCE = 254,
        }

        enum NewYear2010
        {

            PURPLE = 244,
            YELLOW = 245,
            BLUE = 246,
            RED = 247,
            GREEN = 248,
        }

        enum Spring2011
        {

            LEFTGRASS = 233,
            MIDDLEGRASS = 234,
            RIGHTGRASS = 235,
            LEFTBUSH = 236,
            MIDDLEBUSH = 237,
            RIGHTBUSH = 238,
            FLOWER = 239,
            SHRUB = 240,
        }

        enum Easter2012
        {

            BLUEEGG = 256,
            PURPLEEGG = 257,
            YELLOWEGG = 258,
            REDEGG = 259,
            GREENEGG = 260,
        }

        enum Summer2011
        {

            UMBRELLA = 228,
            RIGHTCORNERSAND = 229,
            LEFTCORNERSAND = 230,
            ROCK = 231,
            BUSH = 232,
            SAND = 59,
        }

        enum Halloween2011
        {

            TOMBSTONE = 224,
            LEFTCORNERWEB = 225,
            RIGHTCORNERWEB = 226,
            WALL = 541,
            BRICK = 542,
            LEFTCORNERSTAIR = 543,
            RIGHTCORNERSTAIR = 544,
        }

        enum Christmas2011
        {

            REDORNAMENT = 218,
            GREENORNAMENT = 219,
            BLUEORNAMENT = 220,
            WREATH = 221,
            STAR = 222,
        }

        enum Prison
        {

            BARS = 261,
            BRICK = 550,
            WINDOW = 551,
            BARS_TWO = 552, //conflict!
            BROKENBARS = 553,
            BRICK = 92,
        }

        enum Windows
        {

            CLEAR = 262,
            GREEN = 263,
            TEAL = 264,
            BLUE = 265,
            PURPLE = 266,
            PINK = 267,
            RED = 268,
            ORANGE = 269,
            YELLOW = 270,
        }

        enum Priate
        {

            CANONCOVER = 271,
            SKULL = 272,
        }

        enum Vikings
        {

            REDSHIELD = 273,
            BLUESHIELD = 274,
            AXE = 275,
            FULLBRICK = 561,
            HALFBRICK = 562,
            REDWHITESTRIPES = 563,
        }

        enum Ninja
        {

            LEFTBRIGHTROOFTOP = 276,
            RIGHTBRIGHTROOFTOP = 277,
            BRIGHTWINDOW = 278,
            LEFTDARKROOFTOP = 279,
            RIGHTDARKROOFTOP = 280,
            DARKWINDOW = 281,
            LADDER = 282,
            ANTENNAE = 283,
            YINYANG = 284,
            WHITE = 564,
            GRAY = 565,
            LIGHTSHINGLES = 566,
            DARKSHINGLES = 567,

            WHITESHINGLES = 96,
            GRAYSHINGLES = 97,
        }

        enum Cowboy
        {

            WHITEBAR = 285,
            GRAYBAR = 286,
            LEFTBROWNDOOR = 287,
            RIGHTBROWNDOOR = 288,
            LEFTREDDOOR = 289,
            RIGHTREDDOOR = 290,
            LEFTBLUEDOOR = 291,
            RIGHTBLUEDOOR = 292,
            CURTAINS = 293,
            LIGHTBROWNRAIL = 294,
            DARKBROWNRAIL = 295,
            LIGHTREDRAIL = 296,
            DARKREDRAIL = 297,
            CYANRAIL = 298,
            DARKBLUERAIL = 299,

            BROWNPLANK = 568,
            DARKBROWNPLANK = 569,
            REDPLANK = 570,
            DARKREDPLANK = 571,
            BLUEPLANK = 572,
            DARKBLUEPLANK = 573,

            TAN = 125,
            RED = 126,
            BLUE = 127,

            ONEWAY_TAN = 122,
            ONEWAY_RED = 123,
            ONEWAY_BLUE = 124,
        }


        enum Sand
        {

            WHITE = 301,
            GRAY = 302,
            LIGHTTAN = 303,
            ORANGE = 304,
            TAN = 305,
            BROWN = 306,
            // conflictz
            WHITE_TWO = 579,
            GRAY_TWO = 580,
            YELLOW_TWO = 581,
            ORANGE_TWO = 582,
            TAN_TWO = 583,
            BROWN_TWO = 584,
            /* too much sand
            WHITE = 137,
            GRAY = 138,
            LIGHTTAN = 139,
            ORANGE = 140,
            TAN = 141,
            BROWN = 142,*/
        }

        enum Summer2012
        {

            BALL = 307,
            BUCKET = 308,
            SHOVEL = 309,
            MARTINI = 310,
        }

        enum Cloud
        {

            BOTTOM = 311,
            TOP = 312,
            RIGHT = 313,
            LEFT = 314,
            BOTTOMLEFTCORNER = 315,
            BOTTOMRIGHTCORNER = 316,
            TOPRIGHTCORNER = 317,
            TOPLEFTCORNER = 318,
            WHITE = 143,
        }

        enum Signs
        {

            FLAME = 319,
            SKULL = 320,
            BOLT = 321,
            CROSS = 322,
            HORIZONTALBAR = 323,
            VERTICALBAR = 324,
        }

        enum Castle
        {

            ROOFSUPPORT = 325,
            MERLON = 326,
            BRICKS = 599,
            BRICK = 159,
            WINDOW = 160,

            ONEWAY_GRAY = 158,
        }

        enum Medieval
        {

            BLUEFLAG = 327,
            REDFLAG = 328,
            SWORD = 329,
            SHIELD = 330,
            ROCKS = 331,
            PLANKS = 600,
            ANVIL = 162,
            BARREL = 163,
        }

        enum Rocket
        {

            COMPUTERSCREEN = 332,
            REDLIGHT = 333,
            BLUELIGHT = 334,
            CONTROLPANEL = 335,
            GRAY = 601,
            BLUE = 602,
            GREEN = 603,
            RED = 604,

            WHITE = 172,
            BLUE = 173,
            GREEN = 174,
            RED = 175,
        }


        enum Monster
        {

            BIGTOOTHBOTTOM = 338,
            SMALLTEETHBOTTOM = 339,
            SMALLTEETHTOP = 340,
            ORANGEEYE = 341,
            BLUEEYE = 342,
            LIGHTFUR = 608,
            DARKFUR = 609,


        }

        enum Fog
        {

            FULL = 343,
            BOTTOM = 344,
            TOP = 345,
            RIGHT = 346,
            LEFT = 347,
            BOTTOMLEFTCORNER = 348,
            BOTTOMRIGHTCORNER = 349,
            TOPRIGHTCORNER = 350,
            TOPLEFTCORNER = 351,
        }

        enum Halloween2012
        {

            TESLACAP = 352,
            TESLACOIL = 353,
            VERTICALWIRES = 354,
            HORIZONTALWIRES = 355,
            ELECTRICITY = 356,
        }



        enum Christmas2012
        {

            BLUEVERTICALRIBBON = 362,
            BLUEHORIZONTALRIBBON = 363,
            BLUECROSSEDRIBBON = 364,
            REDVERTICALRIBBON = 365,
            REDHORIZONTALRIBBON = 366,
            REDCROSSEDRIBBON = 367,
            YELLOWPATTERN = 624,
            GREENPATTERN = 625,
            BLUEPATTERN = 626,


        }

        enum Swamp
        {

            MUDBUBBLES = 370,
            GRASS = 371,
            LOG = 372,
            SIGN = 373,
            UNDERBRUSH = 630,
        }

        enum SciFi2013
        {

            BLUEBEND = 375,
            BLUESTRAIGHT = 376,
            ORANGEBEND = 377,
            ORANGESTRAIGHT = 378,
            GREENBEND = 379,
            GREENSTRAIGHT = 380,
            TILE = 637,
        }

        enum Farm
        {

            HAY = 386,
            CORN = 387,
            LEFTFENCE = 388,
            RIGHTFENCE = 389,
        }


        enum Background
        {
            LAYER = 1,

            GRAY = 500,
            BLUE = 501,
            PURPLE = 502,
            RED = 503,
            YELLOW = 504,
            GREEN = 505,
            CYAN = 506,
        }

        enum Brick
        {

            ORANGE = 507,
            TEAL = 508,
            PURPLE = 509,
            GREEN = 510,
            RED = 511,
            TAN = 512,
        }

        enum Checker
        {

            GRAY = 513,
            BLUE = 514,
            PURPLE = 515,
            RED = 516,
            YELLOW = 517,
            GREEN = 518,
            CYAN = 519,
        }

        enum Dark
        {

            GRAY = 520,
            BLUE = 521,
            PURPLE = 522,
            RED = 523,
            YELLOW = 524,
            GREEN = 525,
            CYAN = 526,
        }

        enum Normal
        {

            GRAY = 610,
            BLUE = 611,
            PURPLE = 612,
            RED = 613,
            YELLOW = 614,
            GREEN = 615,
            CYAN = 616,
        }

        enum Pastel
        {

            ORANGE = 527,
            GREEN = 528,
            YELLOW = 529,
            CYAN = 530,
            BLUE = 531,
            RED = 532,
        }

        enum Canvas
        {

            RED = 533,
            TAN = 534,
            GOLD = 535,
            LIME = 536,
            BLUE = 537,
            GRAY = 538,
        }

        enum Carnival
        {

            REDSTRIPE = 545,
            BLUESTRIPE = 546,
            PINK = 547,
            CHECKER = 548,
            GREEN = 549,
        }



        enum Pirate
        {

            DARKPLANK = 554,
            LIGHTPLANK = 555,
            PEGGEDPLANK = 556,
            LIFESAVER = 557,
            WINDOW = 558,
            CANNON = 559,
            FLAG = 560,
        }




        enum Water
        {

            PLAIN = 574,
            SQUID = 575,
            FISH = 576,
            SEAHORSE = 577,
            SEAWEED = 578,
            WAVES = 300,
        }


        enum PlateIron
        {

            PLAIN = 585,
            GRAYPLATE = 586,
            BLUEPLATE = 587,
            GREENPLATE = 588,
            ORANGEPLATE = 589,
        }

        enum Timbered
        {

            THATCHROOF = 590,
            REDSHINGLES = 591,
            TEALSHINGLES = 592,
            VSUPPORT = 593,
            LEFTDIAGONALSUPPORT = 594,
            RIGHTDIAGONALSUPPORT = 595,
            HORIZONTALSUPPORT = 596,
            TSUPPORT = 597,
            CLOSEDWINDOW = 598,
        }


        enum Mars
        {

            BLUE = 605,
            LITTLESTAR = 606,
            BIGSTAR = 607,
            ROCK = 336,
        }


        enum JungleRuins
        {

            GRAY = 617,
            RED = 618,
            BLUE = 619,
            YELLOW = 620,
        }

        enum Jungle
        {

            BRIGHTPLANTS = 621,
            PLANTS = 622,
            DARKPLANTS = 623,
            UNDERGROWTH = 357,
            LOG = 358,
            IDOL = 359,
        }


        enum Lava
        {

            YELLOW = 627,
            ORANGE = 628,
            RED = 629,
        }


        enum Sparta
        {

            BLUEBRICK = 638,
            GREENBRICK = 639,
            REDBRICK = 640,
            CAPITAL = 382,
            SHAFT = 383,
            BASE = 384,
        }
    }
}