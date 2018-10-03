using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour {

    [SerializeField]
    protected float Health = 100;

    [SerializeField]
    protected float Speed;

    [SerializeField]
    protected bool alive = true;

    protected Animator anim;
    [SerializeField]
    protected NavMeshAgent agent;

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Speed;
    }

    public abstract void Attack();

    public abstract void Move(Vector3 position);
   
    internal void BasicMovement(Vector3 target)
    {
        agent.SetDestination(target);
    }

    internal void setDamage(float damage)
    {
        Health -= damage;
        if(damage <= 0)
        {
            alive = false;
            anim.SetBool("Death", true);
            Destroy(gameObject, 5000);
        }
    }
}
