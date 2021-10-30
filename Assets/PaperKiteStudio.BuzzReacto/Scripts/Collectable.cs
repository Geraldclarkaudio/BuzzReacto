using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField]
        private GameObject dialogueBox2;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                Destroy(this.gameObject);

                if (gameObject.name == "Vinegar")
                {
                    GameManager.Instance.hasVinegar = true;
                    
                }

                if (gameObject.name == "Baking_Soda")
                {
                    GameManager.Instance.hasBakingSoda = true;
                    dialogueBox2.SetActive(true);

                }

                //PART 2 ========================================
                if (gameObject.name == "Wood_Plank")
                {
                    GameManager.Instance.hasWoodPlank = true;
                }

                if (gameObject.name == "Water_Bottle")
                {
                    GameManager.Instance.hasWaterBottle = true;
                }
            }

        }
    }
}
