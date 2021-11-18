using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

namespace PaperKiteStudios.BuzzReacto
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject pauseMenu;

        private Initializer init;

        private bool gameIsPaused = false;


        private void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        public void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }

        void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }

        public void Save()
        {
            init.Save();
        }

        //QUIT APPLICATION BUTTOn
    }
}