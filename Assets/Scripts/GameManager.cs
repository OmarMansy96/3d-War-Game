using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Vector3 bulletRescale=Vector3.one;
    public Text endMessage;
    public Text bulletsCount_Text;
    public GameObject enemy;
    public Text enemyCount_Text;
    public int enemyCount;

    public AudioSource shootingSound;
    public GameObject bulletPosition;
    public GameObject bullet;
    public int bulletsCount;
    public int score;

    void Start()
    {
        for (int e = 0; e < enemyCount; e++)
        {
            var newEnemy = Instantiate(enemy);
            newEnemy.transform.position = new Vector3(Random.Range(-90, 90), 3, Random.Range(-90, 90));
            newEnemy.GetComponent<Enemy>().gM = this;
        }
    }

    void Update()
    {
        Shooting();

        enemyCount_Text.text = $"Enemy: {enemyCount.ToString()}";
        bulletsCount_Text.text= $"Bullets: {bulletsCount.ToString()}";

        if (bulletsCount <= 0)
        {
            StartCoroutine(endImage());
        }

    }
   public void Shooting()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl) && bulletsCount > 0)
        {
            shootingSound.Play();
            var newBullet = Instantiate(bullet);
            newBullet.transform.position = bulletPosition.transform.position;
            newBullet.GetComponent<Rigidbody>().velocity = bulletPosition.transform.forward * 50;
            bulletsCount--;

        }
    }
    
    public void Shoot()
    {
        if(bulletsCount > 0)
        {
            shootingSound.Play();
            var newBullet = Instantiate(bullet);
            newBullet.transform.position = bulletPosition.transform.position;
            newBullet.GetComponent<Rigidbody>().velocity = bulletPosition.transform.forward * 50;
           

            bulletsCount--;
        }
        
    }
    IEnumerator endImage()
    {
       yield return  new WaitForSeconds(3);
        endMessage.text = $"Game Over\nTotal Score: {score}";
        Time.timeScale = 0;
    }
   
    
}
