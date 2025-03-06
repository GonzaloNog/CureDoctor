using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum Dificultad
    {
        facil,
        normal,
        dificil
    }

    public Dificultad dificultad = Dificultad.facil;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void setDificultad(int _dificultad)
    {
        switch (_dificultad)
        {
            case 0:
                dificultad = Dificultad.facil;
                break;
            case 1:
                dificultad = Dificultad.normal;
                break;
            case 2:
                dificultad = Dificultad.dificil;
                break;
        }
    }
}
