using System;
using Models;
using TMPro;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

namespace Views
{
    public class CheckPointView : LinkableView
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private TMP_Text nameText;
        
        public override void Link(GameModel model)
        {
            var checkPointModel = model as CheckPointModel;
            checkPointModel?.Type.Subscribe(SetCheckPoint).AddTo(this);
        }

        private void SetCheckPoint(CheckPointType type)
        {
            nameText.text = type.ToString();
            
            switch (type)
            {
                case CheckPointType.Start:
                    meshRenderer.material.color = Color.blue;
                    break;
                case CheckPointType.Finish:
                    meshRenderer.material.color = Color.red;
                    break;
                default:
                    Debug.LogError($"There is no checkPoint type: {type}");
                    break;
            }
        }
    }
}