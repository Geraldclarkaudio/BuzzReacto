using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.BuzzReacto
{ 
   public class MainMenu : MonoBehaviour
    {
       public void OnClickStart()
        {
            SceneManager.LoadScene("Intro_Cutscene");
        }
    }
}
