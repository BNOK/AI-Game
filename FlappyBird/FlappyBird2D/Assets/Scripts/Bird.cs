using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class Bird : Agent
{
    private Rigidbody2D rb2D;
    public float jumpForce = 500f;
    private Vector2 jumper;
    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
        jumper = new Vector2(0, jumpForce );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(jumper);
        }
    }

    public override void Initialize()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
        jumper = new Vector2(0, jumpForce);
        startPos = this.transform.position;
    }

    public override void OnEpisodeBegin()
    {
        this.transform.position = startPos;
        rb2D.velocity = Vector2.zero;

    }

    

    public override void OnActionReceived(float[] vectorAction)
    {
        AddReward(0.1f);

        if (vectorAction[0] == 1)
        {
            rb2D.velocity = Vector2.zero;
            rb2D.AddForce(jumper);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddReward(-1.0f);
        EndEpisode();
    }

}
