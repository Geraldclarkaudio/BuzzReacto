using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.BuzzReacto
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        private string sceneToLoad;
        // Start is called before the first frame update
        void Start()
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
