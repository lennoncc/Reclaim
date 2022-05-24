using UnityEngine;

namespace Hero.Command
{
    public interface IHeroCommand
    {
        void Execute(GameObject gameObject);
    }
}
