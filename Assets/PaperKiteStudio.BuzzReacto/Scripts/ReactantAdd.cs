using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class ReactantAdd : MonoBehaviour
    {
        [SerializeField]
        private GameObject bubbles;
        [SerializeField]
        private GameObject treePotion;
        [SerializeField]
        private GameObject productText;

        [SerializeField]
        private bool bakingSodaAdded, vinegarAdded, solution1Added, solution2Added = false;

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
            }

            if (solution1Added == true && solution2Added == true)
            {
                TreePotion();
                productText.SetActive(false);
                GameManager.Instance.hasTreePotion = true;
            }
        }


        public void BakingSodaAddVinegar()
        {
            bubbles.SetActive(true);
        }

        public void TreePotion()
        {
            treePotion.SetActive(true);
        }
    }
}
