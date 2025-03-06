using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeControler : MonoBehaviour
{
    public int life = 2;

    public Sprite[] sprites;



    public void UpdateVisual(int _life)
    {
        life = _life;
        GetComponent<Image>().sprite = sprites[life];
    }
}
