namespace Item
{
    public class HealingPotion : ConsumableItem
    {
        public int healingValue = 30;
        public HealingPotion()
        {
            itemName = "HealingPotion";
            spritePath = "Sprite/Item/HealingPotion";
            description = "HealingPotion HP+30";
        }
        
        public override void CollectItem()
        {
    
        }
    
        public override void DropItem()
        {
    
        }
    
        public override void Use()
        {
            PlayerInterface.Instance.ChangeCurrentHealth(healingValue);
        }
    }
    
}


