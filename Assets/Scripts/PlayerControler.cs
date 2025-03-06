using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControler : MonoBehaviour
{
    public float speed = 5f;
    public float characterHeight = 1f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private CharacterController characterController;
    private GameObject interaccion;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool newDamage = true;
    void Start()
    {
        targetPosition = transform.position;

        characterController = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //Debug.Log("Mouse");
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "Caminable")
                {
                    targetPosition = new Vector3(hit.point.x, hit.point.y + characterHeight, hit.point.z);
                    isMoving = true;
                    //Debug.Log("newRayo");
                }

            }
        }
        if(interaccion != null && Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("nueva interaccion");
            switch (interaccion.tag)
            {
                case "Cinta":
                    if (interaccion.GetComponent<Transportadora>().eAccion())
                    {
                        animator.SetBool("curar", true);
                        StartCoroutine(resetAnim());
                    }
                    break;
            }
        }
        if (isMoving)
        {
            animator.SetBool("walk", true);
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0;

            characterController.Move(direction.normalized * speed * Time.deltaTime);

            Vector3 pivote = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
           
            if(pivote.x < targetPosition.x)
                spriteRenderer.flipX = true;
            else
                spriteRenderer.flipX = false;

            if(Vector3.Distance(pivote,targetPosition) < 0.8f)
            {
                characterController.Move(Vector3.zero *Time.deltaTime);
                //Debug.Log("quieto");
                isMoving = false;
            }
        }
        else
            animator.SetBool("walk", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Interactuable")
        {
            Debug.Log("Nueva interracion detectada");
            interaccion = other.GetComponent<Interaccion>().interaccion;
        }
        if (other.tag == "Enemigo")
        {
            Debug.Log("ENEMIGO");
            if (other.GetComponent<Enemigo>().getEstado() < 3 && LevelManager.instance.medicinas)
            {
                LevelManager.instance.spawnEmpty[other.GetComponent<Enemigo>().idSpawn] = false;
                Destroy(other.gameObject);
                LevelManager.instance.medicinas = false;
                LevelManager.instance.UIM.UpdateUI();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactuable")
        {
            interaccion = null;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Enemigo")
        {
            if (collision.gameObject.GetComponent<Enemigo>().getAtaque())
            {
                collision.gameObject.GetComponent<Enemigo>().setAtaque(false);
                newDamage = false;
                StartCoroutine(collision.gameObject.GetComponent<Enemigo>().timeToDamage());
                LevelManager.instance.life -= 1;
                LevelManager.instance.UIM.UpdateUI();
            }
        }
    }
    IEnumerator resetAnim()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("curar", false);
    }
}
