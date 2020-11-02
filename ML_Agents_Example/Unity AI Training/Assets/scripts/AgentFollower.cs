using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentFollower : MonoBehaviour
{

    public GameObject agent;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
       

        Vector3 agentPos = agent.transform.position;

        offset = new Vector3(3, -1, 0);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 agentPos = agent.transform.position;
        this.transform.position = agentPos - offset;
    }
}
