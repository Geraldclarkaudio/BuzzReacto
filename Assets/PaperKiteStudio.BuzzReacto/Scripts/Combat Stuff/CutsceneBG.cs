using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneBG : MonoBehaviour
{
    [SerializeField]
    private float _speed = 0.02f;

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private Vector3 originalPos;

    [SerializeField]
    private bool hasSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        hasSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-_speed, 0, 0));

        if(transform.position.x <= -127f && hasSpawned == false)
        {
            Instantiate(background, originalPos, Quaternion.identity);
            hasSpawned = true;
        }

        if(transform.position.x <= -150f)
        {
            Destroy(this.gameObject);
        }
    }
}
