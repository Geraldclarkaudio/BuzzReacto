using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

namespace PaperKiteStudios.BuzzReacto {
    public class SceneChanged : MonoBehaviour
    {
        

        private Initializer init;

        private void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();
            
            init.SceneChanged();          
        }


    }
}
