using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    //For Movement
    public float moveSpeed;
    private float moveSpeedStore;
    public float jumpForce;

    //Increases speed over time
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    //Player Rigid Body
    private Rigidbody2D myRigidbody;

    //For Iphone Dedetion
    private Vector2 startPos;
    public int pixalDistToDetect = 20;
    private bool fingerDown;

    //To check if player is grounded 
    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    //Player Collider
    //private Collider2D myCollider;

    private Animator myAnimator;

    public GameManager theGameManager;

    //For Sound
    public AudioSource jumpSound;
    public AudioSource deathSound;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        //myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        speedMilestoneCount = speedIncreaseMilestone;


        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

            moveSpeed = moveSpeed * speedMultiplier;
        }

        //Player is always moving forward!
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        //Jump with space bar!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpSound.Play();
            }
        }

        //Check Mobil Input.
        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startPos = Input.touches[0].position;
            fingerDown = true;
        }

        //Jump with Swipe Up!
        if (fingerDown)
        {
            if (Input.touches[0].position.y >= startPos.y + pixalDistToDetect)
            {
                fingerDown = false;
                Debug.Log("swipe up");
                if (grounded)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                    jumpSound.Play();

                }
            }
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            deathSound.Play();
            Handheld.Vibrate();
        }
    }
}
