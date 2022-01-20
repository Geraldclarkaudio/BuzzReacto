using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private GameObject laserPrefab;

    private float _fireRate = 0.25f;
    private float canFire = -1f;

    public int o2, water;

    private UIShip uiShip;
    private GameObject dialogBox;

    [SerializeField]
    private GameObject loaderDeLaNextScene;

    // Start is called before the first frame update
    void Start()
    {
        uiShip = GameObject.Find("Canvas").GetComponent<UIShip>();
        dialogBox = GameObject.Find("DialogueBox");

        water = 0;
        o2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeSelf == true)
        {
            return;
        }
        else if(dialogBox.activeSelf == false)
        {
            CalculateMovement();
            Fire();
        }

        if(water >= 10 && o2 >= 10)
        {
            loaderDeLaNextScene.SetActive(true);

            Destroy(this.gameObject);
        }

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -8f, -3f), transform.position.y);

        if (transform.position.y >= 6f)
        {
            transform.position = new Vector2(transform.position.x, -3.8f);
        }

        if (transform.position.y <= -3.9)
        {
            transform.position = new Vector2(transform.position.x, 5.9f);
        }
    }

    void Fire()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            Instantiate(laserPrefab, transform.position, Quaternion.identity);
            canFire = Time.time + _fireRate;
        }
    }

    public void CollectWater(int points)
    {
        water++;
        uiShip.UpdateWaterUI(water);
        
    }
    public void CollectO2(int points)
    {
        o2++;
        uiShip.Updateo2UI(o2);

    }

 
}
