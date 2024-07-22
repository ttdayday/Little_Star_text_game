namespace Little_Star_text_game
{
    public class FlowerPot : GameObject
    {
        private bool _isZoomed;
        private bool _bottomMoved;
        private bool _flowerBlossomed;

        public FlowerPot()
            : base("flower pot", "A flower pot with a flower bud.", true)
        {
            _isZoomed = false;
            _bottomMoved = false;
            _flowerBlossomed = false;
        }

        public override void Interact(Game game)
        {
            if (!_isZoomed)
            {
                _isZoomed = true;
                Console.WriteLine("You zoomed in on the flower pot.It looks like the bottom can be moved. Also there is a big flower bud about to blossom.");
            }
            else if (!_bottomMoved)
            {
                _bottomMoved = true;
                Console.WriteLine("The bottom of the flower pot moved. Hidden underneath are two clock arms.");
                game.AddGameObject(new InventoryItem("clock arms", "Two clock arms."));
            }
            else if (!_flowerBlossomed)
            {
                _flowerBlossomed = true;
                Console.WriteLine("You clicked the flower bud. It blossomed, revealing a clock without arms in the middle.");
                game.AddGameObject(new InventoryItem("clock", "A clock without arms."));
            }
            else
            {
                Console.WriteLine("The flower pot is already interacted with.");
            }
        }

        public bool FlowerBlossomed => _flowerBlossomed;
    }
}
