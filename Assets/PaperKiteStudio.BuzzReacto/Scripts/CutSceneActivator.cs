using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class CutSceneActivator : MonoBehaviour
    {
        [SerializeField]
        private GameObject cutsceneToActivate;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Player")
            {
                cutsceneToActivate.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }
}
