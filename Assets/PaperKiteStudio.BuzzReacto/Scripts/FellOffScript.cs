using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.BuzzReacto
{
    public class FellOffScript : MonoBehaviour
    {
        [SerializeField]
        private Vector3 playerStartPos;

        private Player player;

        private void Start()
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                Debug.Log("You Fell!");

                player.transform.position = playerStartPos;

            }
        }
    }
}
