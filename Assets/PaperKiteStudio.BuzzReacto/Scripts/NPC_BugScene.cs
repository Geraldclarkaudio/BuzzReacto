using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.BuzzReacto
{
    public class NPC_BugScene : MonoBehaviour
    {
        public bool interactable = false;

        [SerializeField]
        private GameObject dialogueBox;
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
                if (GameManager.Instance.haspreMixedPotion == true)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        dialogueBox.SetActive(true);
                    }
                }
                else if (GameManager.Instance.haspreMixedPotion == false)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        return;
                    }
                }
            }
        }
    }
}
