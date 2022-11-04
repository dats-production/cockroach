using System;
using UniRx;
using UnityEngine;
using Zenject;
using IInitializable = Unity.VisualScripting.IInitializable;

namespace Models
{
    public interface ICheckPointModel
    {
        IReactiveProperty<CheckPointType> Type { get; set; }
    }
    
    public class StartCheckPointModel : GameObjectModel, ICheckPointModel
    {
        public IReactiveProperty<CheckPointType> Type { get; set; } = 
            new ReactiveProperty<CheckPointType>();
    }
    
    public class FinishCheckPointModel : GameObjectModel, ICheckPointModel
    {
        public IReactiveProperty<CheckPointType> Type { get; set; } = 
            new ReactiveProperty<CheckPointType>();
    }

    public enum CheckPointType
    {
        Start,
        Finish
    }
}