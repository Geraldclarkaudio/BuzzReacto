using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water02 : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    private Ship ship;

    private AudioManager audioManager;
   

    private void Start()
    {
        ship = GameObject.Find("Ship").GetComponent<Ship>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ship"))
        {
            if(this.gameObject.tag == "Water")
            {
                ship.CollectWater(1);
            }
            if(this.gameObject.tag == "o2")
            {
                ship.CollectO2(1);
            }

            audioManager.PlayCollectedSound();
            
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-_speed, 0, 0);

        if(transform.position.x <= -20f)
        {
            Destroy(this.gameObject);
        }
    }
}
