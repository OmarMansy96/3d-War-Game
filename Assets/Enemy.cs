using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
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
