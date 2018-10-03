using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TriggerChoosing : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NavMeshAgent>())
        {
            if(other.tag != "Worker")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().choosing = false;
                if (!GameObject.Find("GameManager").GetComponent<GameManager>().AIs.Contains(other.GetComponent<NavMeshAgent>()))
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().AIs.Add(other.GetComponent<NavMeshAgent>());
                }
            }
        }
    }

}
