using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public GameObject enemy;
    public int enemyCount;

    public AudioSource shootingSound;
    public GameObject bulletPosition;
    public GameObject bullet;
    public GameObject tankTower, tankTowerPipe;
    float rotaion_Speed = 50f;
    float moveSpeed = 15f;

    void Start()
    {
        for (int e = 0; e < enemyCount; e++)
        {
            var newEnemy = Instantiate(enemy);
            newEnemy.transform.position = new Vector3(Random.Range(-90, 90), 3, Random.Range(-90, 90));
        }
    }

    void Update()
    {
        var axisV = Input.GetAxisRaw("Vertical");
        var axisH = Input.GetAxisRaw("Horizontal");

        transform.Translate( new Vector3(0, 0, axisV * moveSpeed * Time.deltaTime));
        transform.Rotate(new Vector3(0, axisH * rotaion_Speed * Time.deltaTime, 0));
        TankTowerVectors();

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            shootingSound.Play();
            var newBullet = Instantiate(bullet);
            newBullet.transform.position = bulletPosition.transform.position;
            newBullet.GetComponent<Rigidbody>().velocity = bulletPosition.transform.forward*50;
        }

    }

    void TankTowerVectors()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            tankTower.transform.Rotate(new Vector3(0, rotaion_Speed * Time.deltaTime, 0));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            tankTower.transform.Rotate(new Vector3(0, -rotaion_Speed * Time.deltaTime, 0));

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tankTowerPipe.transform.Rotate(new Vector3(-rotaion_Speed * Time.deltaTime, 0, 0));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            tankTowerPipe.transform.Rotate(new Vector3(rotaion_Speed * Time.deltaTime, 0, 0));
        }
    }
}
