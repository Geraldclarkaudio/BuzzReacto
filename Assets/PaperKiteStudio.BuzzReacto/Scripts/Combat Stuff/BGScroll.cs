using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.02f;

    [SerializeField]
    private GameObject funAnim;

    [SerializeField]
    private GameObject ship;

    void Update()
    {
        
        if(transform.position.x<= -129f)
        {
            transform.Translate(new Vector3(0, 0, 0));
            ship.SetActive(false);

            funAnim.SetActive(true);

        }
        else if(transform.position.x >= -129f)
        {
            transform.Translate(new Vector3(-speed, 0, 0));
        }
    }
}
