using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Prefabs.cells
{
    public class Cell : MonoBehaviour, IPointerDownHandler
    {
        public Image cellImage;
        public Sprite tent;
        public CellStates currentState;        

        private int numberOfCellStates = Enum.GetValues(typeof(CellStates)).Length-1;

        private void Start()
        {           
            currentState = CellStates.Default;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            int currentIndex = (int)currentState;
            currentIndex++;
            if (currentIndex == numberOfCellStates)
            {
                currentIndex = 0;
            }            
            currentState = (CellStates)currentIndex;
            OnChangeCellState(currentState);
        }

        public void OnChangeCellState(CellStates cellStates)
        {            
            switch (cellStates)
            {
                case CellStates.Grass:
                    cellImage.color = new Color32(136, 255, 78, 255);
                    break;

                case CellStates.Tent:
                    cellImage.color = new Color32(255, 255, 255, 255);
                    cellImage.sprite = tent;
                    break;

                case CellStates.Default:
                    cellImage.sprite = null;
                    cellImage.color = new Color32(255, 255, 255, 255);
                    break;
                default:
                    break;
            }
        }
    }    
}