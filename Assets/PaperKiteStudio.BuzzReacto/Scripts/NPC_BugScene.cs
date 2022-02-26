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

        [SerializeField]
        private GameObject dialogBubble;

        [SerializeField]
        private GameObject inventoryPanel;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                interactable = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                interactable = false;
                dialogBubble.SetActive(false);
            }
        }

        private void Update()
        {
            if (interactable == true)
            {
                if (GameManager.Instance.haspreMixedPotion == true)
                {
                    dialogBubble.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        dialogueBox.SetActive(true);
                    }
                }
                else if (GameManager.Instance.haspreMixedPotion == false)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        dialogBubble.SetActive(false);
                        return;
                    }
                }
            }

            if (interactable == true && inventoryPanel.activeSelf == true && GameManager.Instance.haspreMixedPotion == true)
            {
                dialogBubble.SetActive(false);
            }
            else if (interactable == true && inventoryPanel.activeSelf == false && GameManager.Instance.haspreMixedPotion == true)
            {
                dialogBubble.SetActive(true);
            }
        }
    }
}
