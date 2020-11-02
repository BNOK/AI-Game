using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using System;

public class BirdLogic : Agent
{
    //reference
    private Spawner spawner;
    private PipeMover piper;
    private Rigidbody2D rb2D;

    //parameters
    private float jumpHeight;
    private Vector2 startPos;
    
    // Start is called before the first frame update

    public override void Initialize()
    {
        spawner = FindObjectOfType<Spawner>();
        piper = FindObjectOfType<PipeMover>();
        startPos = transform.position;
        rb2D = this.GetComponent<Rigidbody2D>();
    }

    public override void OnEpisodeBegin()
    {
        spawner.currentIndex = 0;
        Array.Clear(spawner.pipeList,0,spawner.pipeList.Length);
        spawner.timer = 0;
        this.transform.position = startPos;
        rb2D.velocity = Vector3.zero;


    }

    public override void CollectObservations(VectorSensor sensor)
    {
        
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        AddReward(0.1f);
        if (vectorAction[0] == 0.5)
        {
            rb2D.AddForce(Vector2.up * jumpHeight);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddReward(-1.0f);
        EndEpisode();
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Convert.ToSingle(Input.GetKeyDown(KeyCode.Space)) ;
    }

}
