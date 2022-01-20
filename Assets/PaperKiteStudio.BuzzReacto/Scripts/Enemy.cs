using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private Transform wayPoint1, wayPoint2;

        private bool _switching;

        [SerializeField]
        private float _speed = 5.0f;

        private SpriteRenderer _sprite;
        private Animator _anim;
        private Rigidbody2D playerRB;
        private BoxCollider2D col;

        [SerializeField]
        private GameObject jellyPrefab;
        [SerializeField]
        private GameObject popAnim;

        private AudioManager audioManager;

        private void Start()
        {
            _anim = GetComponent<Animator>();
            _sprite = GetComponent<SpriteRenderer>();
            playerRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();
            col = GetComponent<BoxCollider2D>();
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerHitBox"))
            {
                if(playerRB.velocity.y < 0)
                {
                    playerRB.velocity = Vector2.up * 15f;
                }
                else if(playerRB.velocity.y > 0)
                {
                    playerRB.velocity = Vector2.zero;
                }
              
                audioManager.EnemyDestroyed();
                Instantiate(jellyPrefab, transform.position, Quaternion.identity);
                Instantiate(popAnim, transform.position, Quaternion.identity);
                Destroy(col);
                Destroy(this.gameObject, 0.5f);
               
            }
        }

        // movement

        private void FixedUpdate()
        {
            if (_switching == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, wayPoint2.position, _speed * Time.deltaTime);
                //flip x false 
                _sprite.flipX = true;
                _anim.SetBool("IsMoving", true);

            }
            else if (_switching == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, wayPoint1.position, _speed * Time.deltaTime);
                _sprite.flipX = false;
                _anim.SetBool("IsMoving", true);
            }
            if (transform.position == wayPoint1.position)
            {
                _anim.SetBool("IsMoving", false);
                StartCoroutine(WaitToMove());

               // _switching = false;
            }
            else if (transform.position == wayPoint2.position)
            {
                _anim.SetBool("IsMoving", false);
                StartCoroutine(WaitToMove1());
               // _switching = true;
            }
        }

        IEnumerator WaitToMove()
        {
            yield return new WaitForSeconds(2.0f);
            _switching = false;
        }
        IEnumerator WaitToMove1()
        {
            yield return new WaitForSeconds(2.0f);
            _switching = true;
        }
    }
}

