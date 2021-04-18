namespace Item
{
    public class HealingPotionSmall : ConsumableItem
    {
        public int healingValue = 10;
        public HealingPotionSmall()
        {
            itemName = "HealingPotionSmall";
            spritePath = "Sprite/Item/HealingPotionSmall";
            description = "Small HealingPotion HP+10";
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
