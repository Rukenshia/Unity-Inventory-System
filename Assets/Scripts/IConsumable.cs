using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public interface IConsumable : IItem
    {
        bool Use();
        bool Used { get; }
    }
}
