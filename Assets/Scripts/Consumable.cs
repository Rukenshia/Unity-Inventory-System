using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class Consumable : Item
    {
        public delegate bool OnUseHandler(IItem item);
        public OnUseHandler OnUse;
        public delegate void AfterUseHandler(IItem item, bool used);
        public AfterUseHandler AfterUse;

        private bool _used;
        public bool Used
        {
            get { return _used; }
        }


        public Consumable(ItemDescriptor descriptor) : base(descriptor)
        {
            this._used = false;
        }

        public bool Use()
        {
            if (this._used)
                return false;

            // See if anyone used the item
            bool used = false;
            foreach (OnUseHandler handler in OnUse.GetInvocationList())
            {
                if (handler(this))
                    used = true;
            }
            this._used = used;

            if (this.AfterUse != null)
                this.AfterUse(this, used);

            return used;
        }
    }
}
