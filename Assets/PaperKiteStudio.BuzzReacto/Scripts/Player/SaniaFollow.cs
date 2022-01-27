using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class SaniaFollow : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> targetposition;

        [SerializeField]
        private int currentTarget;

        [SerializeField]
        private float _speed = 3f;

        private Player player;
        private SpriteRenderer _renderer;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.Find("Player").GetComponent<Player>();

            _renderer = GetComponentInChildren<SpriteRenderer>();
        }

        // Update is called once per frame
   
        private void FixedUpdate()
        {
            FollowPlayer();
        }
        private void FollowPlayer()
        {
            if (targetposition.Count > 0 && targetposition[currentTarget] != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetposition[currentTarget].position, _speed * Time.deltaTime);
            }

            if (player.saniaRF.activeSelf == true)
            {
                currentTarget = 0;
            }
            if (player.saniaLF.activeSelf == true)
            {
                currentTarget = 1;
            }

            if (player.transform.position.x > transform.position.x)
            {
                _renderer.flipX = false;
            }
            else if (player.transform.position.x < transform.position.x)
            {
                _renderer.flipX = true;
            }
        }
    }
}
