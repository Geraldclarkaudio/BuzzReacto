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

        [SerializeField]
        private GameObject cookedCarrot;
        [SerializeField]
        private GameObject watterBottle;
        [SerializeField]
        private GameObject carrot2CarrotImg;
        [SerializeField]
        private GameObject text;
        [SerializeField]
        private GameObject arrowdown;
        [SerializeField]
        private GameObject dialogBox;

        private Animator anim;

        

        // Start is called before the first frame update
        void Start()
        {
            anim = GameObject.Find("Main Camera").GetComponent<Animator>();
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
                cookedCarrot.SetActive(true);
                watterBottle.SetActive(true);
                arrowdown.SetActive(false);
                StartCoroutine(TurnOffCarrot());
                carrot2CarrotImg.SetActive(false);
                text.SetActive(false);
                slider.value = 1;

                //activate dialog two for scene
                dialogBox.SetActive(true);

            }
        }

        public void ButtonClick()
        {
            currentFill = currentFill + 0.1f;
            anim.SetTrigger("CamShake");
        }

        IEnumerator TurnOffCarrot()
        {
            yield return new WaitForSeconds(5.0f);
            cookedCarrot.SetActive(false);
            watterBottle.SetActive(false);
            Destroy(this.gameObject);
        }
      
    }
}
