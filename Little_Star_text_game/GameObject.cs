namespace Little_Star_text_game
{
    public abstract class GameObject
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsInteractable { get; private set; }

        protected GameObject(string name, string description, bool isInteractable)
        {
            Name = name;
            Description = description;
            IsInteractable = isInteractable;
        }

        public abstract void Interact(Game game);
    }
}
