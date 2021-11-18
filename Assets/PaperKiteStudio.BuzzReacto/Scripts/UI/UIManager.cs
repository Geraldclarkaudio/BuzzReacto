using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace PaperKiteStudios.BuzzReacto
{
    public class UIManager : MonoBehaviour
    {


        [SerializeField]
        private GameObject _inventoryPanel;
        private bool inventoryActive = false;

        [SerializeField]
        private GameObject pointerArrows;

        public TextMeshProUGUI jellyCount;

        [SerializeField]
        private GameObject bakingSodaUI, vinegarUI, waterBottleUI, woodPlankUI;

        // [SerializeField]
        // private GameObject gameOverButton;

        public void InventoryActive()
        {
            if (inventoryActive == false)
            {
                inventoryActive = true;
                _inventoryPanel.SetActive(true);
                StartCoroutine(ArrowPointerRoutine());
            }
            else if (inventoryActive == true)
            {
                inventoryActive = false;
                _inventoryPanel.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.hasBakingSoda == true)
            {
                bakingSodaUI.SetActive(true);
            }

            if (GameManager.Instance.hasVinegar == true)
            {
                vinegarUI.SetActive(true);
            }

            if (GameManager.Instance.hasWaterBottle == true)//solution 1
            {
                waterBottleUI.SetActive(true);
            }

            if (GameManager.Instance.hasFuel == true)
            {
                bakingSodaUI.SetActive(false);
                vinegarUI.SetActive(false);
            }

        }

        IEnumerator ArrowPointerRoutine() // Animation for arrows when UI opens
        {
            pointerArrows.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            pointerArrows.SetActive(false);
        }

        public void UpdateJellyAmount(int count)
        {
            jellyCount.text = "" + count;
        }


    }
}
