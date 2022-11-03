using Models;
using UnityEngine;

namespace Views
{
    public interface ILinkable
    {
        Transform Transform { get; }
        void Link(ObjectModel entity);
    }
    
    public abstract class LinkableView : MonoBehaviour, ILinkable
    {
        protected ObjectModel Model;
        public Transform Transform => transform;

        public virtual void Link(ObjectModel model)
        {
            Model = model;
        }
    }
}