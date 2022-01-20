using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFlash : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private void Start()
    {
        StartCoroutine(TextyFlash());
    }
    private void Update()
    {
        
    }

    private IEnumerator TextyFlash()
    {
        while (true)
        {
            text.text = "!!!";
            yield return new WaitForSeconds(0.35f);
            text.text = "";
            yield return new WaitForSeconds(0.35f);
        }
    }

}
