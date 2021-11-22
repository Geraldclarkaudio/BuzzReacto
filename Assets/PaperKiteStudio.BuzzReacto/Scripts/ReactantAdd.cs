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
        private GameObject productText;

        [SerializeField]
        private bool bakingSodaAdded, vinegarAdded, solution1Added, solution2Added = false;

        [SerializeField]
        private GameObject dialog3;

        private void Start()
        {
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        }

        public void VinegarAdded()
        {
            vinegarAdded = true;
        }

        public void BakingSodaAdded()
        {
            bakingSodaAdded = true;
        }

        public void Solution1Added()
        {
            solution1Added = true;
        }
        public void Solution2Added()
        {
            solution2Added = true;
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

            if (solution1Added == true && solution2Added == true)
            {
                TreePotion();
                productText.SetActive(false);
                GameManager.Instance.haspreMixedPotion = true;
            }
        }


        public void BakingSodaAddVinegar()
        {
            bubbles.SetActive(true);
            dialog3.SetActive(true);
            audioManager.PlayCombinedItemsSound();
        }

        public void TreePotion()
        {
            treePotion.SetActive(true);
            audioManager.PlayCombinedItemsSound();

        }
    }
}
