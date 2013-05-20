// <author>TakoMan02</author>
// <summary>A description of a singular block in a world.</summary>
namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BlockData;

    public class Block
    {
        public static readonly int
            RIGHT = 0,
            DOWN = 1,
            LEFT = 2,
            UP = 3;

        // Fields
        private int id, direction;
        private Player placer;
        private World w;
        private Coords coords;

        // Properties
        public Coords Coords
        {
            get
            {
                return this.coords;
            }

            set
            {
                if (this.W.Bot.HasAccess)
                {
                    this.W.Push.Build(
                        new Block() 
                        { 
                            Coords = new Coords() 
                            { 
                                X = this.coords.X, 
                                Y = this.coords.Y 
                            }, 

                            id = BlockIds.Action.Gravity.DOWN
                        });

                    this.W.Push.Build(
                        new Block()
                        {
                            Coords = new Coords() 
                            {
                                X = this.coords.X,
                                Y = this.coords.Y
                            },

                            id = this.Id
                        });

                    this.coords = value;
                }
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (

                    // If you have access to change this value
                    this.W.Bot.HasAccess &&

                    // and if it's a proper piano block...
                    ((this is PianoBlock &&
                    value == BlockIds.Action.Music.PIANO) ||

                    // ...or it's a proper percussion block...
                    (this is PercussionBlock &&
                    value == BlockIds.Action.Music.PERCUSSION) ||

                    // ...or it's a proper portal/invisible portal...
                    (this is Portal &&
                    (value == BlockIds.Action.Portals.NORMAL ||
                    value == BlockIds.Action.Portals.INVISIBLE)) ||

                    // ...or it's a proper world portal...
                    (this is WorldPortal &&
                    value == BlockIds.Action.Portals.WORLD) ||

                    // ...or it's JUST a block.
                    (!(this is PianoBlock) &&
                    !(this is PercussionBlock) &&
                    !(this is Portal) &&
                    !(this is WorldPortal))))
                {
                    this.W.Push.Build(this);
                    this.id = value;
                }
            }
        }

        public int Layer
        {
            get
            {
                if (this.Id >= 500)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                // If it's a valid direction and you have the rights to change it
                if (value <= 4 && this.W.Bot.HasAccess)
                {
                    this.direction = value;
                }
            }
        }

        public Player Placer
        {
            get
            {
                return this.placer;
            }

            internal set
            {
                this.placer = value;
            }
        }

        public World W
        {
            get
            {
                return this.w;
            }

            internal set
            {
                this.w = value;
            }
        }
    }
}