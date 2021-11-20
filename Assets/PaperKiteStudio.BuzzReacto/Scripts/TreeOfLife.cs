using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class TreeOfLife : MonoBehaviour
    {
        [SerializeField]
        private bool interactable = false;
        [SerializeField]
        private GameObject sceneLoader;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                interactable = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                interactable = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (interactable == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (GameManager.Instance.hasTreePotion == true)
                    {
                        //Begin Cutscene for giving the potion and floating away
                        //sceneLoader.SetActive(true);
                    }

                    else if (GameManager.Instance.hasTreePotion == false)
                    {
                        
                    }

                }
            }
        }
    }
}
