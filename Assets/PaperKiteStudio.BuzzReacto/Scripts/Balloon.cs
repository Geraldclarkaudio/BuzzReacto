using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PaperKiteStudios.BuzzReacto
{
    public class Balloon : MonoBehaviour
    {
        [SerializeField]
        private GameObject cineCam1;
        [SerializeField]
        private Transform currentTarget;

        [SerializeField]
        private GameObject cameraFade;

        [SerializeField]
        private float _speed = 3f;

        private Rigidbody2D rb;
        

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("DeAct"))
            {
                cineCam1.SetActive(false);
            }

            if (other.CompareTag("Tree"))
            {
                rb.gravityScale = 2;
                cameraFade.SetActive(true);
                StartCoroutine(LoadingScene());
            }
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, _speed * Time.deltaTime);
        }

        IEnumerator LoadingScene()
        {
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("Gas");
            
        }
    }
}
