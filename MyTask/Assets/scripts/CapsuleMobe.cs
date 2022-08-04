using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CapsuleMobe : CollidableEnemy
{
    [SerializeField]
    NavMeshAgent agent;

    Transform target;

    private void Start()
    {
        target = GameObject.Find("Player1").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeStep += Time.deltaTime;

        if (timeStep > timeNextStep)
        {
            agent.SetDestination(target.position);
        }
        
        timeToPrepareFoTheAttack += Time.deltaTime;

        if (minimumTimeBeforeAttack <= timeToPrepareFoTheAttack)
        {
            if (player != null)
            {
                player.gettingDamaged(damage);

                timeToPrepareFoTheAttack = 0;
            }
        }
    }

    //
    private void OnCollisionExit(Collision collision)
    {
        Player playerTemp = collision.gameObject.GetComponent<Player>();
        if (playerTemp != null)
        {
            player = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        player = collision.gameObject.GetComponent<Player>();
    }

}
