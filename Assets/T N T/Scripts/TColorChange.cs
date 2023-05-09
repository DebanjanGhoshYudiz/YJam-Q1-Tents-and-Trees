using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace prefabs.cells
{
    public class TColorChange : MonoBehaviour, IPointerDownHandler
    {        
        public Image test;

        private void Start()
        {
            //test = GetComponentInChildren<Image>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(Input.GetMouseButtonDown(0))
            {
                test.color = new Color32(150, 75, 0, 255);
            }
            if(Input.GetMouseButtonDown(1))
            {
                test.color = new Color32(248,123,131,255);
            }
        }
    }
}
