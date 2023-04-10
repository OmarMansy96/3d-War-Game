using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameManager gM;
   

    public int enemyHelth = 3;
    public GameObject destroiedEnemy;

    void Start()
    {

    }

    void Update()
    {

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
