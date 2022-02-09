using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.BuzzReacto
{
    public class DamagedBalloon : MonoBehaviour
    {
        [SerializeField]
        private GameObject dialogBubble;
        [SerializeField]
        private GameObject needFuelBubble;
        public int currentProgress;
        public GameObject inventoryPanel;

        public bool interactable = false;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                interactable = true;
                if(GameManager.Instance.hasFuel == true)
                {
                    dialogBubble.SetActive(true);
                }
                else if(GameManager.Instance.hasFuel == false)
                {
                    needFuelBubble.SetActive(true);
                }
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                interactable = false;
                dialogBubble.SetActive(false);
                needFuelBubble.SetActive(false);
            }
        }

        private void Update()
        {
            if (GameManager.Instance.hasFuel == true && interactable == true)
            {
                if(inventoryPanel.activeSelf == false)
                {
                    dialogBubble.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        StartCoroutine(LoadingScene());
                    }
                }
                else if(inventoryPanel.activeSelf == true)
                {
                    dialogBubble.SetActive(false);
                }
                
            }
            else if (GameManager.Instance.hasFuel == false && interactable == true)
            {
                if (inventoryPanel.activeSelf == false)
                {
                    needFuelBubble.SetActive(true);

                }
                else if(inventoryPanel.activeSelf == true)
                {
                    needFuelBubble.SetActive(false);
                }
          

            }
        }

        IEnumerator LoadingScene()
        {
            LOLSDK.Instance.SubmitProgress(0, currentProgress, 8);
            yield return new WaitForSeconds(1.5f);
            //load scene
            SceneManager.LoadScene("FloatUp_Scene");
        }
    }
}
