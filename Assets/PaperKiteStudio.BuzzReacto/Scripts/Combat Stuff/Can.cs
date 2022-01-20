using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    [SerializeField]
    private float _speed = 7f;
    [SerializeField]
    private GameObject o2;

    [SerializeField]
    private GameObject explosionPrefab;

    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Laser"))
        {

            Instantiate(o2, transform.position, Quaternion.identity);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            _audioManager.EnemyDestroyed();
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(new Vector3(-_speed, 0, 0));

        if (transform.position.x <= -20f)
        {
            Destroy(this.gameObject);
        }
    }

}
