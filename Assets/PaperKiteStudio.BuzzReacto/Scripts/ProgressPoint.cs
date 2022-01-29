using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

namespace PaperKiteStudios.BuzzReacto
{
    
    public class ProgressPoint : MonoBehaviour
    {
        public int currentProgress;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
               LOLSDK.Instance.SubmitProgress(0, currentProgress, 9);
               
                Destroy(this.gameObject);
            }
        }
    }
}
