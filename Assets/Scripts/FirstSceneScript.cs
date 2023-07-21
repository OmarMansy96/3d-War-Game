using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstSceneScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    //public void SubmitValue()
    //{
    //    PlayerPrefs.SetString("playerName", playerNameInput.text.ToString());
    //    PlayerPrefs.SetInt("enemyCount", int.Parse(enemyCountInput.text));

    //    Debug.Log($"{PlayerPrefs.GetString("playerName").ToString()}");
    //    Debug.Log($"{PlayerPrefs.GetInt("enemyCount")}");
    //}

    public void SceneSwitch()
    {
        SceneManager.LoadScene("Game");

    }
    public void EasyLevel()
    {
        PlayerPrefs.SetInt("enemyCount", 10);
        PlayerPrefs.SetInt("bullets", 40);
        SceneManager.LoadScene("Game");
    }
    public void MediumLevel()
    {
        PlayerPrefs.SetInt("enemyCount",20);
        PlayerPrefs.SetInt("bullets", 70);
        SceneManager.LoadScene("Game");
    }
    public void HardLevel()
    {
        PlayerPrefs.SetInt("bullets", 95);
        PlayerPrefs.SetInt("enemyCount",30);
        SceneManager.LoadScene("Game");
    }
}
