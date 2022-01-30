using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

namespace PaperKiteStudios.BuzzReacto
{
    
    public class ProgressPoint : MonoBehaviour
    {
        public int currentProgress;
        private Initializer init;

        private void Start()
        {
            init = GameObject.Find("App").GetComponent<Initializer>();        
                }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
               LOLSDK.Instance.SubmitProgress(0, currentProgress, 8);
                init.Save();
               
                Destroy(this.gameObject);
            }
        }
    }
}
