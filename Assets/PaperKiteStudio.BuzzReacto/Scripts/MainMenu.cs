using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.BuzzReacto
{ 
   public class MainMenu : MonoBehaviour
    {
        private Animator anim;

        public void Start()
        {
            anim = GameObject.Find("MainMenuBGM").GetComponent<Animator>();
        }
        public void OnClickStart()
        {
            StartCoroutine(StartGameRoutine());
            anim.enabled = true;
        }

        IEnumerator StartGameRoutine()
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Intro_Cutscene");

        }
    }
}
