using Models;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Views
{
    public class CheckPointView : LinkableView
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private TMP_Text nameText;
        
        public override void Link(GameObjectModel model)
        {
            var checkPointModel = model as ICheckPointModel;
            SetCheckPoint(checkPointModel);
        }

        private void SetCheckPoint(ICheckPointModel model)
        {
            switch (model)
            {
                case StartCheckPointModel startModel:
                    meshRenderer.material.color = Color.blue;
                    nameText.text = "START";
                    break;
                case FinishCheckPointModel finishModel:
                    meshRenderer.material.color = Color.red;
                    nameText.text = "FINISH";
                    break;
                default:
                    Debug.LogError($"There is no checkPoint type: {model}");
                    break;
            }
        }
    }
}