using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class Guidance : MonoBehaviour
    {
        [SerializeField]
        private GameObject dialogtrigger;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                dialogtrigger.SetActive(true);
            }
        }

    }
}
