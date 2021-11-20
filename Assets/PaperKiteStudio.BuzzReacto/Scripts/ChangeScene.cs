using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.BuzzReacto
{
    public class ChangeScene : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("Gas");
            }
        }
    }
}
