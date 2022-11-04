using Models;
using UnityEngine;

namespace Views
{
    public interface ILinkable
    {
        Transform Transform { get; }
        void Link(GameObjectModel entity);
        void Destroy();
    }
    
    public abstract class LinkableView : MonoBehaviour, ILinkable
    {
        protected GameObjectModel Model;
        public Transform Transform => transform;

        public virtual void Link(GameObjectModel model)
        {
            Model = model;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}