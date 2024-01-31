using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    public float lookRadius = 20f;
     Transform targetPlayer;
     NavMeshAgent agent;
    public int health = 6;
    public PlayerManager PlayerManager;
    public Animator animator;

    void Start()
	{
        targetPlayer = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
	}


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(targetPlayer.position, transform.position);

		if (distance <= lookRadius)
		{
            agent.SetDestination(targetPlayer.position);
		}

        if(health == 0)
		{
            PlayerManager.Endgame();
		}

        animator.SetInteger("HealthBar", health);
    }

    void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "FirstPersonPlayer")
        {
          
            health = health - 1;
            
        }
    }
}
