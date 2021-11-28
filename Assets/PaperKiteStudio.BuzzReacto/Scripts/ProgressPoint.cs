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
            if (other.tag == "Player")
            {
               LOLSDK.Instance.SubmitProgress(0, currentProgress, 8);
                Debug.Log("Submitted some dang ol progress");
                Destroy(this.gameObject);
            }
        }
    }
}
