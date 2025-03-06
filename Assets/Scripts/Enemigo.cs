using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private Animator animator;
    private int estadoID = 0;
    public float velocidad = 3f;
    private bool ataque = true;
    public float dispersionRadius = 1.0f;
    public int idSpawn;

    private Vector3 targetOffset;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(enfermando());
        GenerarOffsetAleatorio();
    }
    
    IEnumerator enfermando()
    {
        yield return new WaitForSeconds(LevelManager.instance.timeChangeEnemi);
        newEstado();
    }
    private void Update()
    {
        if(estadoID >= 3)
        {
            Vector3 objetivoConOffset = LevelManager.instance.target.transform.position + targetOffset;
            Vector3 direccion = (objetivoConOffset - transform.position).normalized;

            this.transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
        }
        if (LevelManager.instance.target.transform.position.x > this.transform.position.x)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;
    }
    public void newEstado()
    {
        estadoID++;
        animator.SetInteger("estado", estadoID);
        if(estadoID < 3)
            StartCoroutine(enfermando());
    }
    public void newStartEstade(int id)
    {
        estadoID = id;
    }
    public int getEstado()
    {
        return estadoID;
    }
    public bool getAtaque()
    {
        return ataque;
    }
    public void setAtaque(bool _ataque)
    {
        ataque = _ataque;
    }
    public IEnumerator timeToDamage()
    {
        yield return new WaitForSeconds(1f);
        ataque = true;
    }
    void GenerarOffsetAleatorio()
    {
        Vector2 randomPoint = Random.insideUnitCircle * dispersionRadius;
        targetOffset = new Vector3(randomPoint.x, 0, randomPoint.y); 
    }
}
