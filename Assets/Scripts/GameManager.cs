using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player, playerHead;

    public Text endMessage, bulletsCount_Text, enemyCount_Text;

    public GameObject enemy, bulletPosition, bullet;
    public int enemyCount, bulletsCount, score;
    public GameObject panel;
    public AudioSource shootingSound;

    void Start()
    {
        bulletsCount = PlayerPrefs.GetInt("bullets");
        Time.timeScale = 1;
        EnemyCountValidation();
       
        panel.SetActive(false);
        Debug.Log($"{enemyCount}");
    }

    void Update()
    {
        Debug.Log($"{enemyCount}");

        Shooting();
        enemyCount_Text.text = $"Enemy: {enemyCount.ToString()}";
        bulletsCount_Text.text= $"Bullets: {bulletsCount.ToString()}";

        if (bulletsCount <= 0)
        {
            StartCoroutine(endImage());
        }
    }

    void EnemyCountValidation()
    {
        enemyCount = PlayerPrefs.GetInt("enemyCount");
        Time.timeScale = 1;
        for (int e = 0; e < enemyCount; e++)
        {
            GameObject newEnemy = Instantiate(enemy);
            newEnemy.transform.position = new Vector3(UnityEngine.Random.Range(-90, 90), 3, UnityEngine.Random.Range(-90, 90));
            newEnemy.GetComponent<Enemy>().gM = this;
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

    private IEnumerator endImage()
    {
       yield return  new WaitForSeconds(3);
        panel.gameObject.SetActive(true);
        endMessage.text = $"Game Over\nTotal Score: {score}";
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
   
    public void SceneSwitch()
    {
        SceneManager.LoadScene("Start");
    }
}