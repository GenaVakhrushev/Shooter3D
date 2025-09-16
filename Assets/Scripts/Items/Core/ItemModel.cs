using System;
using Shooter.Core;

namespace Shooter.Items.Core
{
    public abstract class ItemModel : IModel
    {
        public string Name;
        
        public abstract object Clone();
        public abstract Type GetControllerType();
    }
}