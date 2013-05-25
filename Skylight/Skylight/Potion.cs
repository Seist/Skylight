namespace Skylight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Potion
    {
        private int id;
        private bool isActive;

        public int Id
        {
            get
            {
                return this.id;
            }

            internal set
            {
                this.id = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return this.isActive;
            }

            internal set
            {
                this.isActive = value;
            }
        }
    }
}
