using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using System.Collections;

public class BallAgentLogic : Agent
{
    Rigidbody rBody;

    public GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    public Transform target;

    public override void OnEpisodeBegin()
    {
        //floor reset 
        floor.GetComponent<MeshRenderer>().material.color = Color.gray;

        //agent initialization
        this.rBody.angularVelocity = Vector3.zero;
        this.rBody.velocity = Vector3.zero;
        this.transform.localPosition = new Vector3(-9, 0.5f, 0);

        //target random spawner 
        target.localPosition = new Vector3(12 + Random.value * 8, Random.value * 3, Random.value * 10 -5);
    }


    public override void CollectObservations(VectorSensor sensor)
    {
        // necessary input is agent position and velocity , target position
        sensor.AddObservation(target.transform.localPosition);
        sensor.AddObservation(this.transform.localPosition);
        sensor.AddObservation(rBody.velocity);
    }

    public float speed = 20;

    public override void OnActionReceived(float[] vectorAction)
    {
        //force to control agent 
        Vector3 controlSignal = Vector3.zero;

        controlSignal.x = vectorAction[0];

        if (vectorAction[1] == 2)
        {
            controlSignal.z = 1;
        }
        else
        {
            controlSignal.z = -vectorAction[1];
        }

        if (this.transform.localPosition.x < 8.5)
        {
            rBody.AddForce(controlSignal * speed);
        }

        //reward system
        float distance = Vector3.Distance(this.transform.localPosition, target.localPosition);

        if(distance < 1.42f)
        {
            floor.GetComponent<MeshRenderer>().material.color = Color.green;
            SetReward(1.0f);
            EndEpisode();
        }


        if(this.transform.localPosition.y < 0)
        {
            floor.GetComponent<MeshRenderer>().material.color = Color.red;
            EndEpisode();
        }

    }


    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxis("Vertical");
        actionsOut[1] = Input.GetAxis("Horizontal");
    }

    

   


}
