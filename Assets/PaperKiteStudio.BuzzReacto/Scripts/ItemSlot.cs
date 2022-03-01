using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PaperKiteStudios.BuzzReacto
{
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        [SerializeField]
        private GameObject text;

        private ReactantAdd reactantAdd;
        public bool canDrop;

        private void Start()
        {
            reactantAdd = GameObject.Find("Reactant_Zone").GetComponent<ReactantAdd>();
            canDrop = true;
        }
        public void OnDrop(PointerEventData eventData)
        {
            if(canDrop == true)
            {
                text.SetActive(false);
                canDrop = false;
                Cursor.lockState = CursorLockMode.None;
                
                if (eventData.pointerDrag != null)
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    Debug.Log("Dropped" + eventData.pointerDrag.name);

                    if (eventData.pointerDrag.tag == "Vinegar")
                    {
                        reactantAdd.VinegarAdded();
                        eventData.pointerDrag.GetComponent<DragDrop>().enabled = false;
                    }

                    if (eventData.pointerDrag.tag == "BakingSoda")
                    {
                        reactantAdd.BakingSodaAdded();
                        eventData.pointerDrag.GetComponent<DragDrop>().enabled = false;

                    }

                    if (eventData.pointerDrag.tag == "h2oUI")
                    {
                        reactantAdd.h2oAdded();
                        eventData.pointerDrag.GetComponent<DragDrop>().enabled = false;

                    }
                    if (eventData.pointerDrag.tag == "co2UI")
                    {
                        reactantAdd.CarbonDioxideAdded();
                        eventData.pointerDrag.GetComponent<DragDrop>().enabled = false;

                    }

                    if (eventData.pointerDrag.tag == "LavaUI")
                    {
                        reactantAdd.LavaAdded();
                        eventData.pointerDrag.GetComponent<DragDrop>().enabled = false;

                    }
                    if (eventData.pointerDrag.tag == "WoodUI")
                    {
                        reactantAdd.WoodAdded();
                        eventData.pointerDrag.GetComponent<DragDrop>().enabled = false;

                    }

                    if (eventData.pointerDrag.tag == "Solution1")
                    {
                        reactantAdd.Solution1Added();
                        eventData.pointerDrag.GetComponent<DragDrop>().enabled = false;

                    }
                    if (eventData.pointerDrag.tag == "Solution2")
                    {
                        reactantAdd.Solution2Added();
                        eventData.pointerDrag.GetComponent<DragDrop>().enabled = false;

                    }
                }
            }
           
        }
    }
}
