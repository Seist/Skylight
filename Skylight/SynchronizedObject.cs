using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skylight
{
    public class SynchronizedObject
    {
        public double x, y, width, height;
        protected double speedX = 0;
        protected double speedY = 0;
        protected double modifierX = 0;
        protected double modifierY = 0;
        protected double baseDragX;
        protected double baseDragY;
        protected double no_modifier_dragX;
        protected double no_modifier_dragY;
        protected double water_drag;
        protected double water_buoyancy;
        protected double boost;
        protected double gravity;
        public double mox = 0;
        public double moy = 0;
        public double mx = 0;
        public double my = 0;
        public DateTime last;
        protected double offset = 0;
        public double mult;

        public SynchronizedObject()
        {
            this.baseDragX = Config.physics_base_drag;
            this.baseDragY = Config.physics_base_drag;
            this.no_modifier_dragX = Config.physics_no_modifier_drag;
            this.no_modifier_dragY = Config.physics_no_modifier_drag;
            this.water_drag = Config.physics_water_drag;
            this.water_buoyancy = Config.physics_water_buoyancy;
            this.boost = Config.physics_boost;
            this.gravity = Config.physics_gravity;
            this.mult = Config.physics_variable_multiplyer;
            this.last = DateTime.Now;
            return;
        }

        public int BlockX
        {
            get
            {
                return (int)((this.x + 8) / 16);
            }
        }

        public int BlockY
        {
            get
            {
                return (int)((this.y + 8) / 16);
            }
        }

        public double PosX
        {
            get
            {
                return (this.x + 8);
            }
        }

        public double PosY
        {
            get
            {
                return (this.y + 8);
            }
        }

        public double SpeedX
        {
            get
            {
                return this.speedX * this.mult;
            }
            set
            {
                this.speedX = value / this.mult;
            }
        }

        public double SpeedY
        {
            get
            {
                return this.speedY * this.mult;
            }
            set
            {
                this.speedY = value / this.mult;
            }
        }

        public double ModifierX
        {
            get
            {
                return this.modifierX * this.mult;
            }
            set
            {
                this.modifierX = value / this.mult;
            }
        }

        public double ModifierY
        {
            get
            {
                return this.modifierY * this.mult;
            }
            set
            {
                this.modifierY = value / this.mult;
            }
        }

    }
}
