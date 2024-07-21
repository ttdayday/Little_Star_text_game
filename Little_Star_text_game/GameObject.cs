using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Little_Star_text_game
{
    public class GameObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsInteractable { get; set; }

        public GameObject(string name, string description, bool isInteractable)
        {
            Name = name;
            Description = description;
            IsInteractable = isInteractable;
        }

        public virtual void Interact()
        {
            Console.WriteLine("You can't do anything with this object.");
        }

    }
}
