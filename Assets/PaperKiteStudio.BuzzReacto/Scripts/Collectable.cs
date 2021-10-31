﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField]
        private GameObject dialogueBox;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                Destroy(this.gameObject);

                ///GAS SCENE::::::::::::::::::::::::::::::::::::::::::
                if (gameObject.name == "Vinegar")
                {
                    GameManager.Instance.hasVinegar = true;             
                }

                if (gameObject.name == "Baking_Soda")
                {
                    GameManager.Instance.hasBakingSoda = true;
                    dialogueBox.SetActive(true);

                }
                //CAVE SCENE::::::::::::::::::::::::::::::::::::::
                if (gameObject.name == "Wood_Plank")
                {
                    GameManager.Instance.hasWoodPlank = true;
                    dialogueBox.SetActive(true);
                }
                if(gameObject.name == "Carrot")
                {
                    GameManager.Instance.hasCarrot = true;
                    dialogueBox.SetActive(true);

                }

                if (gameObject.name == "Water_Bottle")
                {
                    GameManager.Instance.hasWaterBottle = true;
                }
            }

        }
    }
}
