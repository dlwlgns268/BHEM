using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const float Speed = 1330;
    private const float JumpPower = 17.3f;
    private float _horizontal;
    private Rigidbody2D _rigid;
    private SpriteRenderer _spriteRenderer;
    public Animator _anim;
    private bool _isJumping;
    public bool _goingLeft;
    private GameObject _scene;
    [SerializeField]private GameObject Player;

    private void Awake()
    {
        _rigid = gameObject.GetComponent<Rigidbody2D>();
        _rigid.freezeRotation = true;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _isJumping = false;
        _scene = GameObject.Find("SceneManager");
        
        _anim.SetBool("LeftMove",false);
        _anim.SetBool("RightMove",false);
        _anim.SetBool("LeftIdle",false);
        _anim.SetBool("RightIdle",false);
        _goingLeft = false;
    }

    private void Update()
    {
        if (_rigid.velocity.normalized.x == 0)
        {
            _anim.SetBool("LeftMove",false);
            _anim.SetBool("RightMove",false);
            _anim.SetBool(_goingLeft ? "LeftIdle" : "RightIdle",true);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _goingLeft = true;
            _anim.SetBool("LeftIdle", false);
            _anim.SetBool("RightIdle",false);
            _anim.SetBool("LeftMove", true);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _goingLeft = false;
            _anim.SetBool("LeftIdle", false);
            _anim.SetBool("RightIdle",false);
            _anim.SetBool("RightMove", true);
        }
        if (_rigid.velocity.y < -0.1)
        {
            if(Input.GetKey(KeyCode.LeftShift))
                _rigid.gravityScale = 0.12f;
            else
                _rigid.gravityScale = 2f;
        }
        else
        {
            _rigid.gravityScale = 2f;
        }

       /* if (Input.GetKeyDown(KeyCode.Z))
        {
            Player.GetComponent<PlayerAttack>().Fire();
        }*/
        if(_rigid.velocity.y != 0)return;
        if (Input.GetKey(KeyCode.Space))
        {
            _rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            _isJumping = true;
        }
        
        /*if (Input.GetButtonDown("Horizontal"))
        {
            _spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }*/
    }

    private void FixedUpdate()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movePos = new Vector2(_horizontal * (Speed * Time.fixedDeltaTime), _rigid.velocity.y);
        _rigid.velocity = movePos;
        
        if (!(_rigid.velocity.y < 0)) return;
        Debug.DrawRay(_rigid.position, Vector3.down, new Color(0, 1, 0));
        var rayHit = Physics2D.Raycast(_rigid.position, Vector3.down, 1, LayerMask.GetMask($"Platform"));
        if (!rayHit.collider) return;
        if (rayHit.distance < 0.5f) _anim.SetBool("isjumping", false);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            _scene.GetComponent<SceneManager>().StageEnd();
        }
    }
}
