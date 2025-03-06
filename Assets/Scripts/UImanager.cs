using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public TextMeshProUGUI medicina;
    public LifeControler[] lifes;
    public GameObject gameOver;
    public Image blod;
    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if(LevelManager.instance.life <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }

        if (LevelManager.instance.medicinas)
            medicina.color = Color.green;
        else
            medicina.color = Color.red;
        int temp = LevelManager.instance.life;
        for(int a = 0; a < lifes.Length; a++)
        {
            if ((temp - 2) >= 0)
            {
                lifes[a].UpdateVisual(2);
                temp -= 2;
            }
            else if ((temp - 1) >= 0)
            {
                lifes[a].UpdateVisual(1);
                temp -= 1;
            }
            else
                lifes[a].UpdateVisual(0);
        }
        float temp2 = 1f / 6f;
        float temp3 = 1f - ((float)LevelManager.instance.life * temp2);
        Debug.Log("temp3 " + temp3 + "temp2 " + temp2 + "temp1 " + temp);
        blod.color = new Color(1, 1, 1, temp3);
    }
    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
