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

        public bool interactable = false;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
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
            if (other.tag == "Player")
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
                dialogBubble.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {

                    StartCoroutine(LoadingScene());
                    

                }
            }
            else if (GameManager.Instance.hasFuel == false && interactable == true)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    //dialogue box that says "I need to find baking soda and vinegar. This will power my balloon."
                    Debug.Log("Need Fuel");
                }

            }
        }

        IEnumerator LoadingScene()
        {
            LOLSDK.Instance.SubmitProgress(0, 0, 0);
            yield return new WaitForSeconds(1.5f);
            //load scene
            SceneManager.LoadScene("FloatUp_Scene");
        }
    }
}
