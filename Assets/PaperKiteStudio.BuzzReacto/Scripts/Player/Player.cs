using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using LoLSDK;

namespace PaperKiteStudios.BuzzReacto
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D rb;
        [SerializeField]
        private float _jumpHeight = 5.0f;

        [SerializeField]
        private float _speed = 5.0f;

        private bool resetJumpNeeded = false;
        [SerializeField]
        private bool isGrounded = false;

        private bool _paused = false;

        private UIManager _uiManager;
        private Animator _anim;
        public Animator _robotAnimRF, _robotAnimLF;
        private SpriteRenderer _sprite;

        [SerializeField]
        private GameObject saniaLF, saniaRF;

        public bool canMove = true;



        // Start is called before the first frame update
        void Start()
        {
            _uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();
            if (_uiManager == null)
            {
                Debug.LogError("UIMAnager is Null!");
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
            InventoryScreen();
            PauseGame();
            Movement();
        }

        public void Movement()
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            isGrounded = Grounded();
            //FLIP =================
            FlipSprite(horizontalInput);
            //JUMP ====================
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, _jumpHeight);
                StartCoroutine(WaitForGrounded());
            }
            //MOVE=======================
            rb.velocity = new Vector2(horizontalInput * _speed, rb.velocity.y);
            _anim.SetFloat("Move", Mathf.Abs(horizontalInput));

            _robotAnimLF.SetFloat("Move", Mathf.Abs(horizontalInput));
            _robotAnimRF.SetFloat("Move", Mathf.Abs(horizontalInput));
        }

        public bool Grounded()
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 4.0f, 1 << 8);

            Debug.DrawRay(transform.position, Vector2.down * 4.0f, Color.green);

            if (hitInfo.collider != null)
            {

                if (resetJumpNeeded == false)
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

        private void PauseGame()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                _paused = true;
                //uimanager stuff for pausing
                //pause
            }
            if (_paused == true && Input.GetKeyDown(KeyCode.P))
            {
                //unpause
            }
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
    }
}
