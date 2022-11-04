using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Models
{
    public abstract class GameObjectModel
    {
        public string Name { get; set; }
        public Transform StartTransform { get; set; }
        public List<ILinkable> Views { get; } = new ();
    }
}