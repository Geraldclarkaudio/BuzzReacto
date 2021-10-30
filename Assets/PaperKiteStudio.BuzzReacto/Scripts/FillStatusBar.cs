using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PaperKiteStudios.BuzzReacto
{
    public class FillStatusBar : MonoBehaviour
    {
        private Slider slider;
        private float currentFill;
        private float maxFill = 1f;

        [SerializeField]
        private Image fillImage;

        [SerializeField]
        private GameObject button;

        // Start is called before the first frame update
        void Start()
        {
            slider = GetComponent<Slider>();
        }

        // Update is called once per frame
        void Update()
        {
            if (slider.value == 1)
            {
                //Make animation happen for the old carrot to disappear along with arrow. 
            }
            else if (slider.value < 1)
            {
                SliderUpdate();
            }
        }

        private void SliderUpdate()
        {
            currentFill = currentFill - 0.20f * Time.deltaTime;

            if (slider.value <= slider.minValue)
            {
                fillImage.enabled = false;
            }
            if (slider.value > 0 && fillImage.enabled == false)
            {
                fillImage.enabled = true;
            }

            float fillValue = currentFill / maxFill;
            slider.value = fillValue;

            if (slider.value == 1)
            {
                button.SetActive(false);
                slider.value = 1;
            }
        }

        public void ButtonClick()
        {
            currentFill = currentFill + 0.1f;

        }
    }
}
