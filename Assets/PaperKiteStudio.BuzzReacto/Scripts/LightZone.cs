using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class LightZone : MonoBehaviour
    {
        [SerializeField]
        private GameObject torch;

        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (GameManager.Instance.hasWoodPlank == true)
                {
                    //Set it on fire
                    torch.SetActive(true);
                }
                else if (GameManager.Instance.hasWoodPlank == false)
                {
                    Debug.Log("Need wood plank to set on fire here.");
                }
            }
        }
    }
}

