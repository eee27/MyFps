using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform bloodRed;

    [SerializeField]
    private Transform bloodBlack;

    [SerializeField]
    private GameObject enemyAnim;

    private float enemyCurrentBlood;
    public static float wtf;
    private Animation anim;

    private void Start()
    {
        anim = enemyAnim.GetComponent<Animation>();
        enemyCurrentBlood = GlobalData.enemyBlood;
        UpdateBloodBar(enemyCurrentBlood);
    }

    private void Update()
    {
        if (enemyCurrentBlood <= 0) { enemyDead(); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            enemyCurrentBlood -= GlobalData.playerDamage;
            anim.Play("hit");
            UpdateBloodBar(enemyCurrentBlood);
        }
    }

    /*------------------------------------*/

    private void UpdateBloodBar(float enemyBlood)
    {
        if (enemyCurrentBlood >= 0)
        {
            bloodBlack.localScale = new Vector3((100 - enemyBlood) * 0.01f * 2f, bloodBlack.localScale.y, bloodBlack.localScale.z);
            bloodBlack.position = new Vector3((2f - bloodBlack.localScale.x) / 2f, bloodBlack.position.y, bloodBlack.position.z);
        }
    }

    private void enemyDead()
    {
        anim.Play("idlefloor");
        // Destroy(gameObject);
    }
}