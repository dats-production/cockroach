using Models;
using UnityEngine;

namespace Views
{
    public interface ILinkable
    {
        Transform Transform { get; }
        void Link(GameModel entity);
    }
    
    public abstract class LinkableView : MonoBehaviour, ILinkable
    {
        protected GameModel Model;
        public Transform Transform => transform;

        public virtual void Link(GameModel model)
        {
            Model = model;
        }
    }
}