using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// лучник (сфера)
public class ArcherMob : Enemy 
{
    [SerializeField]
    NavMeshAgent agent;

    Transform target;

    [SerializeField]
    float distanceAttack;

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
            attack();
        }
    }

    void attack()
    {
        RaycastHit hit;
        if (Physics.Linecast(transform.position, transform.forward * distanceAttack + transform.position, out hit))
        {
            player = hit.collider.GetComponent<Player>();
            if (player != null)
                player.gettingDamaged(damage);
        }

        timeToPrepareFoTheAttack = 0;
    }
}
