using UniRx;
using UnityEngine;
using Views;

namespace Models
{
    public abstract class ObjectModel
    {
        public string Name { get; set; }
        public Transform StartTransform;
        public ILinkable View;
    }
}