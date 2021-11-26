using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

namespace PaperKiteStudios.BuzzReacto
{
    
    public class ProgressPoint : MonoBehaviour
    {
        public int currentProgress;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                LOLSDK.Instance.SubmitProgress(0, currentProgress, 10);
                Destroy(this.gameObject);
            }
        }
    }
}
