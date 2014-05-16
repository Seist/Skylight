using System;
namespace MasterBot.Movement
{
    //import SynchronizedObject.*;
    //import blitter.*;

    public class SynchronizedObject : BlObject
    {
        protected double _speedX = 0;
        protected double _speedY = 0;
        protected double _modifierX = 0;
        protected double _modifierY = 0;
        protected double _baseDragX;
        protected double _baseDragY;
        protected double _no_modifier_dragX;
        protected double _no_modifier_dragY;
        protected double _water_drag;
        protected double _water_buoyancy;
        protected double _mud_drag;
        protected double _mud_buoyancy;
        protected double _boost;
        protected double _gravity;
        public double mox = 0;
        public double moy = 0;
        public double mx = 0;
        public double my = 0;
        public DateTime last;
        protected double offset = 0;
        private double mult;

        public SynchronizedObject()
        {
            this._baseDragX = Config.physics_base_drag;
            this._baseDragY = Config.physics_base_drag;
            this._no_modifier_dragX = Config.physics_no_modifier_drag;
            this._no_modifier_dragY = Config.physics_no_modifier_drag;
            this._water_drag = Config.physics_water_drag;
            this._water_buoyancy = Config.physics_water_buoyancy;
            this._mud_drag = Config.physics_mud_drag;
            this._mud_buoyancy = Config.physics_mud_buoyancy;
            this._boost = Config.physics_boost;
            this._gravity = Config.physics_gravity;
            this.mult = Config.physics_variable_multiplyer;
            this.last = DateTime.Now;
            return;
        }// end function

        protected int blockX
        {
            get
            {
                return (int)Math.Round(((this.x) / 16.0));
            }
        }

        protected int blockY
        {
            get
            {
                return (int)Math.Round((this.y) / 16.0);
            }
        }

        protected double posX
        {
            get
            {
                return (this.x + 8);
            }
        }

        protected double posY
        {
            get
            {
                return (this.y + 8);
            }
        }

        public double speedX
        {
            get
            {
                return this._speedX * this.mult;
            }
            set
            {
                this._speedX = value / this.mult;
            }
        }// end function

        public double speedY
        {
            get
            {
                return this._speedY * this.mult;
            }
            set
            {
                this._speedY = value / this.mult;
            }
        }// end function

        public double modifierX
        {
            get
            {
                return this._modifierX * this.mult;
            }
            set
            {
                this._modifierX = value / this.mult;
            }
        }// end function

        public double modifierY
        {
            get
            {
                return this._modifierY * this.mult;
            }
            set
            {
                this._modifierY = value / this.mult;
            }
        }// end function

    }
}
