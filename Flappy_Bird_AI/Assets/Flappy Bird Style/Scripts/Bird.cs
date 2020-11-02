using UnityEngine;
using System.Collections;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using System;

public class Bird : Agent
{
	public float upForce;					//Upward force of the "flap".
	private bool isDead = false;			//Has the player collided with a wall?

	private Animator anim;					//Reference to the Animator component.
	private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the bird.


    // agents parametres 
    private Vector3 startPos;
    private RaycastHit2D hitRight;
    public GameObject[] indicators;
    private GameControl gc;

   // private void Start()
    //{
        //Get reference to the Animator component attached to this GameObject.
       // anim = GetComponent<Animator>();
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
      //  rb2d = GetComponent<Rigidbody2D>();
   // }


   // void Update()
    //{
        //Don't allow control if the bird has died.
       // if (isDead == false)
        //{
            //Look for input to trigger a "flap".
           // if (Input.GetMouseButtonDown(0))
           // {
                //...tell the animator about it and then...
             //   anim.SetTrigger("Flap");
                //...zero out the birds current y velocity before...
             //   rb2d.velocity = Vector2.zero;
                //	new Vector2(rb2d.velocity.x, 0);
                //..giving the bird some upward force.
             //   rb2d.AddForce(new Vector2(0, upForce));
           // }
       // }
   // }


    public override void Initialize()
    {
        
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        startPos = this.transform.position;
        gc = FindObjectOfType<GameControl>();
    }

    public override void OnEpisodeBegin()
    {
        //player reset 
        rb2d.velocity = Vector3.zero;
        this.transform.position = startPos;
        //
        

    }

   // public override void CollectObservations(VectorSensor sensor)
   // {
      //  sensor.AddObservation(this.transform.position);

       // float upDist = Vector3.Distance(this.transform.position, indicators[0].transform.position);
       // sensor.AddObservation(upDist);

       // float downDist = Vector3.Distance(this.transform.position, indicators[1].transform.position);
       // sensor.AddObservation(downDist);

       // hitRight = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y), Vector2.right, Mathf.Infinity);
      //  sensor.AddObservation(hitRight.distance); 
  //  }

    public override void OnActionReceived(float[] vectorAction)
    {
       
            AddReward(0.1f);

            if (vectorAction[0] == 1)
            {
                anim.SetTrigger("Flap");
                //...zero out the birds current y velocity before...
                rb2d.velocity = Vector2.zero;
                //	new Vector2(rb2d.velocity.x, 0);
                //..giving the bird some upward force.
                rb2d.AddForce(new Vector2(0, upForce));
            }
        
    }

    void OnCollisionEnter2D(Collision2D other)
	{
		// Zero out the bird's velocity
		rb2d.velocity = Vector2.zero;
		// If the bird collides with something set it to dead...
		isDead = true;
		//...tell the Animator about it...
		anim.SetTrigger ("Die");
		//...and tell the game control about it.
		GameControl.instance.BirdDied ();
        // rewards 
        AddReward(-1.0f);
        EndEpisode();
	}


    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Convert.ToSingle( Input.GetKeyDown(KeyCode.Space));
    }

}
