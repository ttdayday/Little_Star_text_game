namespace Little_Star_text_game
{
    public class InventoryItem : GameObject
    {
        public InventoryItem(string name, string description)
            : base(name, description, true) { }

        public override void Interact(Game game)
        {
            game.Inventory.Add(this);
            game.RemoveGameObject(this);
            Console.WriteLine($"You picked up {Name}.");
        }
    }
}
