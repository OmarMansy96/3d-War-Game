using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameManager gM;
    public int enemyHelth = 3;
    public GameObject destroiedEnemy;
    NavMeshAgent agent;
    float attackRedias = 20;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, gM.player.position);
        if(distance < attackRedias)
        {
            agent.SetDestination(gM.player.position);

        }
        if (enemyHelth <= 0)
        {
            var newdestroiedEnemy = Instantiate(destroiedEnemy);
            newdestroiedEnemy.transform.position = gameObject.transform.position;
            Destroy(gameObject);
            gM.enemyCount--;
            gM.score += 5;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullets"))
        {
            enemyHelth--;
        }

    }
}
