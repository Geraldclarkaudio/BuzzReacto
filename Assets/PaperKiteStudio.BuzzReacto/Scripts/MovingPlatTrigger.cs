using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto {
    public class MovingPlatTrigger : MonoBehaviour
    {
        private MovingPlatform movingPlatScript;

        private void Start()
        {
            movingPlatScript = GetComponent<MovingPlatform>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                movingPlatScript.enabled = true;
            }
        }
    }
}