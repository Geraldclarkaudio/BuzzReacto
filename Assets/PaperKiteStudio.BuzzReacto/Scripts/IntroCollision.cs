using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class IntroCollision : MonoBehaviour
    {
        private Animator _anim;

        private void Start()
        {
            _anim = GameObject.Find("CM vcam2").GetComponent<Animator>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Balloon")
            {
                _anim.SetTrigger("ScreenShake");
                other.GetComponent<Rigidbody2D>().gravityScale = 2;
            }
        }
    }
}
