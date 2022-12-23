using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour

{
    [SerializeField]
     private float jumpforce=4;
    [SerializeField]
    private int moveforce;
    private Transform t;
    float movementX;
    Rigidbody2D mybody;
    Animator anim;
    string walkAnimation = "walk";
    SpriteRenderer sr;
    bool isGround=true;
    string groundtag = "Ground";
    [SerializeField]
    float min=-51;
    [SerializeField]
    float max=45;

    // Start is called before the first frame update

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        player1Move();
        animateplayer1();
        player1jump();

    }
    public void player1Move()
    {
        //player cant move out of boundaries
        if (transform.position.x > max)
        {
            transform.position = new Vector3(max, transform.position.y, 0f);
        }if (transform.position.x < min)
        {
            transform.position = new Vector3(min, transform.position.y, 0f) ;
        }
       
            movementX = Input.GetAxisRaw("Horizontal");
            transform.position += new Vector3(movementX, 0f, 0f) * moveforce * Time.deltaTime;
        
    }
    void animateplayer1()
    {
       
            if (movementX > 0)
            {
                anim.SetBool(walkAnimation, true);
                sr.flipX = false;
            }
            else if (movementX < 0)
            {
                anim.SetBool(walkAnimation, true);
                sr.flipX = true;

            }
            else
            {
                anim.SetBool(walkAnimation, false);

            }
        
    }
    void player1jump()
    {
        if (Input.GetButtonDown("Jump")&& isGround)
        {
            isGround = false;
            mybody.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag (groundtag))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
            GameObject.Destroy(gameObject);
    }
}
