using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class GetSolution2 : MonoBehaviour
    {
        [SerializeField]
        private GameObject solution2;

        private bool canGet = false;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                canGet = true;
            }


        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                canGet = false;
            }
        }

        private void Update()
        {
            if (canGet == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    solution2.SetActive(true);
                    GameManager.Instance.hasSolution2 = true;
                }
            }
        }
    }
}
