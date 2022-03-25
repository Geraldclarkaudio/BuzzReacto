using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelEnabled : MonoBehaviour
{
    public GameObject goHereArrow;
    // Start is called before the first frame update
    void Start()
    {
        goHereArrow.SetActive(true);
    }

}
