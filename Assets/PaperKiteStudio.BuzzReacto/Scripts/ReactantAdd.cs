using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class ReactantAdd : MonoBehaviour
    {
        private AudioManager audioManager;
        [SerializeField]
        private GameObject bubbles;
        [SerializeField]
        private GameObject treePotion;
        [SerializeField]
        private GameObject photosynthesis;

        [SerializeField]
        private GameObject inventoryPanel;

        [SerializeField]
        private GameObject torch;
        [SerializeField]
        private GameObject productText;

        [SerializeField]
        private bool bakingSodaAdded, vinegarAdded, solution1Added, solution2Added, h20Added, co2Added, lavaAdded, woodAdded = false;

        [SerializeField]
        private GameObject dialog3;

   

        private void Start()
        {
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        }

        //Gas Scene
        public void VinegarAdded()
        {
            vinegarAdded = true;
            audioManager.PlayDropSound();
        }

        public void BakingSodaAdded()
        {
            bakingSodaAdded = true;
            audioManager.PlayDropSound();
        }

        //Cave Scene

        public void h2oAdded()
        {
            h20Added = true;
            audioManager.PlayDropSound();
        }

        public void CarbonDioxideAdded()
        {
            co2Added = true;
            audioManager.PlayDropSound();

        }
        public void LavaAdded()
        {
            lavaAdded = true;
            audioManager.PlayDropSound();
        }

        public void WoodAdded()
        {
            woodAdded = true;
            audioManager.PlayDropSound();

        }

        //Final Mixture

        public void Solution1Added()
        {
            solution1Added = true;
            audioManager.PlayDropSound();
        }
        public void Solution2Added()
        {
            solution2Added = true;
            audioManager.PlayDropSound();

        }

        private void Update()
        {

            if (bakingSodaAdded == true && vinegarAdded == true)
            {
                BakingSodaAddVinegar();
                productText.SetActive(false);
                GameManager.Instance.hasFuel = true;
                bakingSodaAdded = false;
                vinegarAdded = false;
            }
            if(h20Added == true && co2Added == true)
            {
                PhotosynthesisCreated();
                productText.SetActive(false);
                GameManager.Instance.hasPhotosynthesis = true;
                h20Added = false;
                co2Added = false;
            }
            if(lavaAdded == true && woodAdded == true)
            {
                torch.SetActive(true);
                inventoryPanel.SetActive(false);
                lavaAdded = false;
                woodAdded = false;

                //make torch appear in hand and close out the inventory panel. 
            }

            if (solution1Added == true && solution2Added == true)
            {
                TreePotion();
                productText.SetActive(false);
                GameManager.Instance.haspreMixedPotion = true;
                solution1Added = false;
                solution2Added = false;
            }
        }


        public void BakingSodaAddVinegar()
        {
            bubbles.SetActive(true);
            dialog3.SetActive(true);
            audioManager.PlayCombinedItemsSound();
        }

        public void PhotosynthesisCreated()
        {
            photosynthesis.SetActive(true);
            audioManager.PlayCombinedItemsSound();
        }

        public void TreePotion()
        {
            treePotion.SetActive(true);
            audioManager.PlayCombinedItemsSound();
        }
    }
}
