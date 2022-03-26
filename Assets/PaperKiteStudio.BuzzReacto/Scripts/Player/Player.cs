using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LoLSDK;

namespace PaperKiteStudios.BuzzReacto
{
    public class Player : MonoBehaviour
    {
        public int level;

        private Rigidbody2D rb;
        [SerializeField]
        private float _jumpHeight = 5.0f;

        [SerializeField]
        private float _speed = 5.0f;

        private BoxCollider2D boxCollider2d;

        public bool resetJumpNeeded = false;
        [SerializeField]
        private bool isGrounded = false;

      //  private bool _paused = false;

        private UIManager _uiManager;
        private Animator _anim;
        //public Animator _robotAnimRF, _robotAnimLF;
        private SpriteRenderer _sprite;

        [SerializeField]
        public GameObject saniaLF, saniaRF;


        [SerializeField]
        private int jellyCount;
        [SerializeField]
        private GameObject jellyUI;

        public bool canMove = true;

        [SerializeField]
        private GameObject dialog;

        private Scene scene;
        private MovingPlatform movingPlatform;

        // Start is called before the first frame update
        void Start()
        {
            scene = SceneManager.GetActiveScene();
            jellyCount = 0;
            boxCollider2d = GetComponent<BoxCollider2D>();

            if(SceneManager.GetActiveScene().name != "Rabbit_Rescued" || SceneManager.GetActiveScene().name != "Stir")
            {
                movingPlatform = GameObject.Find("Moving_Platform").GetComponent<MovingPlatform>();
                if (movingPlatform == null)
                {
                    Debug.LogError("Moving Platform Is Null");
                }


                _uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();
                if (_uiManager == null)
                {
                    Debug.LogError("UIMAnager is Null!");
                }
            }
       

            _anim = GetComponent<Animator>();
            if (_anim == null)
            {
                Debug.LogError("Animator is Null!");
            }

            _sprite = GetComponent<SpriteRenderer>();
            if (_sprite == null)
            {
                Debug.LogError("Sprite Renderer is Null");
            }

            rb = GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                Debug.LogError("Rigidbody is Null");
            }

        }

        // Update is called once per frame
        void Update()
        {
            if(scene.name == "Stir")
            {
                return;
            }
            InventoryScreen();


            if (canMove == false)
            {
                if(scene.name != "MainMenu" || scene.name =="Final_Scene")
                {
                    _anim.SetFloat("Move", 0);
       
                    return;
                }
                else
                {
                    return;
                }
                
            }
            else if(canMove==true)
            {
                Movement();
            }

        }

        public void Movement()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            isGrounded = Grounded();

            //FLIP =================
            FlipSprite(horizontalInput);
            //JUMP ====================
            if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0 || Input.GetKeyDown(KeyCode.Space) && Grounded() == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, _jumpHeight);
                StartCoroutine(WaitForGrounded());
            }

            if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.25f);
            }
            //MOVE=======================
            if(Grounded() == false)//prevents movement while in the air. 
            {
                return;
            }
            else if(Grounded() == true)
            {
                rb.velocity = new Vector2(horizontalInput * _speed, rb.velocity.y);
                _anim.SetFloat("Move", Mathf.Abs(horizontalInput));
            }
        }

        public bool Grounded()
        {
            float extraheighttest = 0.1f;
            RaycastHit2D hitInfo = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraheighttest, 1<<8);
            boxCollider2d.edgeRadius = 0.01f;
            Debug.DrawRay(boxCollider2d.bounds.center + new Vector3(boxCollider2d.bounds.extents.x, 0), Vector2.down * (boxCollider2d.bounds.extents.y + extraheighttest), Color.green);
            Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x, 0), Vector2.down * (boxCollider2d.bounds.extents.y + extraheighttest), Color.green);
            Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x, boxCollider2d.bounds.extents.y), Vector2.right * boxCollider2d.bounds.size.x, Color.green);
           
            if (hitInfo.collider != null)
            {
                if (resetJumpNeeded == false || movingPlatform.onPlatform == true)
                {
                    return true;
                }
            }

            return false;
        }

        IEnumerator WaitForGrounded()
        {
            resetJumpNeeded = true;
            yield return new WaitForSeconds(0.5f);
            resetJumpNeeded = false;
        }

        private void InventoryScreen()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                _uiManager.InventoryActive();
            }
        }

        private void FlipSprite(float move)
        {
            if (move > 0)
            {
                _sprite.flipX = false;
                saniaLF.SetActive(false);
                saniaRF.SetActive(true);

            }
            else if (move < 0)
            {
                _sprite.flipX = true;
                saniaLF.SetActive(true);
                saniaRF.SetActive(false);

            }
        }

        public void ObtainedJelly(int amount)
        {
            jellyCount ++;

            _uiManager.UpdateJellyAmount(jellyCount);

            if(jellyCount == 5)
            {
                //has the green jelly UI
                GameManager.Instance.hasSolution2 = true;
                jellyUI.SetActive(true);

                dialog.SetActive(true);

            }
        }

        public void EndGame()
        {
            LOLSDK.Instance.CompleteGame();
        }



    }

   
}
