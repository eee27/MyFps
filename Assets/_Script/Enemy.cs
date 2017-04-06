using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyAnim;

    [SerializeField]
    private Transform player;

    private bool enemyIsDead = false;

    private float enemyCurrentBlood;
    private Animation anim;
    public static bool isSetUp = false;

    private NavMeshAgent nav;
    private float distance;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = enemyAnim.GetComponent<Animation>();
        enemyCurrentBlood = 100;
    }

    private void Update()
    {
        if (enemyCurrentBlood <= 0) { enemyDead(); }

        if (isSetUp)
        {
            distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= 20 && !enemyIsDead)
            {
                nav.destination = player.position;
            }
            if (enemyIsDead)
            {
                nav.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            enemyCurrentBlood -= GlobalData.playerDamage;
            anim.Play("hit");
        }
    }

    /*------------------------------------*/

    private void enemyDead()
    {
        anim.Play("idlefloor");
        enemyIsDead = true;
        // Destroy(gameObject);
    }
}