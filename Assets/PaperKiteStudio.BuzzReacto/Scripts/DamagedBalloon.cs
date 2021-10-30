using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.BuzzReacto
{
    public class DamagedBalloon : MonoBehaviour
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
            if (GameManager.Instance.hasFuel == true && interactable == true)
            {
                //set dialogue box active that says "Press E to use the product!" 
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //celebratory text
                    //load scene after a few seconds.
                    //SceneManager.LoadScene(float up to icy cave scene);
                    StartCoroutine(LoadingScene());
                    Debug.Log("Loading New Scene");

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
            SceneManager.LoadScene(4);
        }
    }
}
