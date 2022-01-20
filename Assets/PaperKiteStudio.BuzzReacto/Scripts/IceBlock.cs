using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class IceBlock : MonoBehaviour
    {
        private Animator _anim;

        private void Start()
        {
            _anim = GetComponent<Animator>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Torch"))
            {
                _anim.SetTrigger("Melt");
                Destroy(this.gameObject, 3f);
            }
        }
    }
}
