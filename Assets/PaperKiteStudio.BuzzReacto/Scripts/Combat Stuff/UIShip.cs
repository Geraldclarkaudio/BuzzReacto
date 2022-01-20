using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIShip : MonoBehaviour
{
    public TextMeshProUGUI waterText;
    public TextMeshProUGUI o2Text;

    private UIShip uiship;
    private Ship ship;

    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.Find("Ship").GetComponent<Ship>();
        uiship = GameObject.Find("Canvas").GetComponent<UIShip>();
    }

    public void UpdateWaterUI(int waterAmount)
    {
        waterText.text = "" + waterAmount;
    }
    public void Updateo2UI(int o2Amount)
    {
        o2Text.text = "" + o2Amount;
    }
}
