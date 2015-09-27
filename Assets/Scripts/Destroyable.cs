using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public delegate void OnDestroyHandler(IDestroyable obj);

    public class Destroyable : IDestroyable
    {
        private OnDestroyHandler _destroyHandler;
        public OnDestroyHandler OnDestroy
        {
            get { return _destroyHandler; }
            set { _destroyHandler = value; }
        }

        ~Destroyable()
        {
            OnDestroy = null;
        }

        public void Destroy()
        {
            if (this.OnDestroy == null)
                return;

            this.OnDestroy(this);
        }
    }
}
