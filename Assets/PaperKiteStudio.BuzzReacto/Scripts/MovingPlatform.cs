using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperKiteStudios.BuzzReacto
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 2f;
        [SerializeField]
        private Transform wayPoint1, wayPoint2;

        private bool _switching = false;



        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                other.transform.parent = this.transform;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                other.transform.parent = null;
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (_switching == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, wayPoint2.position, _speed * Time.deltaTime);

            }
            else if (_switching == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, wayPoint1.position, _speed * Time.deltaTime);

            }
            if (transform.position == wayPoint1.position)
            {
                _switching = false;
            }
            else if (transform.position == wayPoint2.position)
            {
                _switching = true;
            }
        }

    }
}
