using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LoLSDK;

namespace PaperKiteStudios.BuzzReacto
{
    public class ProgressPoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                LOLSDK.Instance.SubmitProgress(0, 0, 0);
                Destroy(this.gameObject);
            }
        }
    }
}
