using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    [SerializeField]
    float moveForce = 1.5f;

    [SerializeField]
    float ForceJump = 11f;

    public Rigidbody2D PlayerBody;

    private float movementX;

    private bool grounded = true;

    private readonly string _ground = "Ground";

    private Animator anim;
    private readonly string WALK_ANIMATION = "Walk";

    private bool facingLeft = false;

    private void Awake()
    {
        PlayerBody.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();
        AnimatePlayer();
    }

    void PlayerMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += moveForce * Time.deltaTime * new Vector3(movementX, 0f, 0f);
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            grounded = false;

            PlayerBody.AddForce(new Vector2(0f, ForceJump), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_ground))
        {
            grounded = true;
        }

    }


    //матерь божья.
    void AnimatePlayer()
    {
        if (movementX > 0) //we're going to the left side
        {
            anim.SetBool(WALK_ANIMATION, true);

            if (facingLeft == true)
            {
                facingLeft = false;
                transform.Rotate(0f, -180f, 0f);
            }
        }
        else if (movementX < 0) //we're going to the right side.
        {
            anim.SetBool(WALK_ANIMATION, true);

            if (facingLeft == false)
            {
                transform.Rotate(0f, 180f, 0f);
                facingLeft = true;
            }
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
}