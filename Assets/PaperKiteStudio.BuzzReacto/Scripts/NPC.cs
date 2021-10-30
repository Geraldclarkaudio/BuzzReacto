using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.BuzzReacto
{
    public class NPC : MonoBehaviour
    {
        public bool interactable = false;
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

        private void Update()
        {
            if (interactable == true)
            {
                if (GameManager.Instance.hasCarrot == true)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        //begin cooking carrot section. 
                        SceneManager.LoadScene(7);
                    }
                }
                else if (GameManager.Instance.hasCarrot == false)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        //Dialog pops up that says " I'm so hungry I can hardly stand!"
                        Debug.Log("Need to get the Carrot first.");
                        return;
                    }
                }
            }
        }
    }
}
