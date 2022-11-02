using UniRx;
using UnityEngine;
using Views;

namespace Models
{
    public abstract class GameModel
    {
        public string Name { get; set; }
        public ILinkable View;
    }
}