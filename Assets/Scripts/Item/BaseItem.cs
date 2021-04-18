using UnityEngine;

namespace Item
{
    public abstract class BaseItem
    {
        public int ID { get; set; }
        public string itemName { get; set; }
        public string description { get; set; }
        public string spritePath { get; set; }
        
        public abstract void CollectItem();
        public abstract void DropItem();
    }
}


