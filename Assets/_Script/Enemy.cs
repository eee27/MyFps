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

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip attackClip;

    private bool enemyIsDead = false;

    private float enemyCurrentBlood;
    private Animation anim;

    private NavMeshAgent nav;
    private float distance;
    private Vector3 enemyOldPos;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = enemyAnim.GetComponent<Animation>();
        enemyCurrentBlood = 100;
    }

    private void Update()
    {
        if (enemyCurrentBlood <= 0) { enemyDead(); }
        if (enemyIsDead)
        {
            nav.Stop();
        }
        else
        {
            distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= 20)
            {
                nav.destination = player.position;
            }
            if (distance <= 3)
            {
                anim.Play("attack1");
                audioSource.PlayOneShot(attackClip, 0.03f);
            }
            if (enemyOldPos != transform.position && !anim.isPlaying)
            {
                anim.Play("walk1");
            }
            enemyOldPos = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            enemyCurrentBlood -= GlobalData.playerDamage * GlobalData.playerDamageRate;
            anim.Play("hit");
        }
    }

    /*------------------------------------*/

    private void enemyDead()
    {
        anim.Play("idlefloor");
        enemyIsDead = true;
        Invoke("DestroyEnemy", 2);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}