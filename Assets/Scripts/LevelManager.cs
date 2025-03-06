using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float timeChangeEnemi;
    public GameObject target;
    public bool medicinas = false;
    public int life = 6;
    public UImanager UIM;
    public GameObject enemigo;
    public Transform[] points;
    public bool[] spawnEmpty = new bool[4];
    private int enemigos = 0 ;
    public Light luz;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        for(int a = 0; a < spawnEmpty.Length; a++)
        {
            spawnEmpty[a] = false;
        }
        InvokeRepeating("newEnemigo", 1, 5);
        if(GameManager.Instance.dificultad == GameManager.Dificultad.dificil)
            luz.color = Color.red;
        setDificultad();
    }
    public void newEnemigo()
    {
        
        int temp = -1;
        for(int a = 0; a < spawnEmpty.Length; a++)
        {
            if (spawnEmpty[a] == false)
            {
                temp = a;
            }
        }
        Debug.Log("New Enemigo: " + temp);
        if (temp >= 0)
        {
           GameObject temp2 = Instantiate(enemigo, points[temp].position, Quaternion.identity);
           temp2.GetComponent<Enemigo>().idSpawn = temp;
           spawnEmpty[temp] = true;
        }
    }
    public void setDificultad()
    {
        switch (GameManager.Instance.dificultad)
        {
            case GameManager.Dificultad.facil:
                timeChangeEnemi = 6;
                break;
            case GameManager.Dificultad.normal:
                timeChangeEnemi = 5;
                break;
            case GameManager.Dificultad.dificil:
                timeChangeEnemi = 3;
                break;
        }
    }

}
