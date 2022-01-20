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

        private void Start()
        {
            reactantAdd = GameObject.Find("Reactant_Zone").GetComponent<ReactantAdd>();
        }
        public void OnDrop(PointerEventData eventData)
        {
            text.SetActive(false);

            if (eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Debug.Log("Dropped" + eventData.pointerDrag.name);

                if (eventData.pointerDrag.tag == "Vinegar")
                {
                    reactantAdd.VinegarAdded();
                }

                if (eventData.pointerDrag.tag == "BakingSoda")
                {
                    reactantAdd.BakingSodaAdded();
                }

                if(eventData.pointerDrag.tag == "h2oUI")
                {
                    reactantAdd.h2oAdded();
                }
                if (eventData.pointerDrag.tag == "co2UI")
                {
                    reactantAdd.CarbonDioxideAdded();
                }

                if (eventData.pointerDrag.tag == "LavaUI")
                {
                    reactantAdd.LavaAdded();
                }
                if (eventData.pointerDrag.tag == "WoodUI")
                {
                    reactantAdd.WoodAdded();
                }

                if (eventData.pointerDrag.tag == "Solution1")
                {
                    reactantAdd.Solution1Added();
                }
                if (eventData.pointerDrag.tag == "Solution2")
                {
                    reactantAdd.Solution2Added();
                }
            }
        }
    }
}
