using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transportadora : MonoBehaviour
{
    public GameObject prefad;
    public Transform spawn;
    public Transform target;
    public float moveSpeed = 5f;
    public float spawnTime;
    private bool interactuable = false;

    private GameObject spawnedObject;

    private void Start()
    {
        StartCoroutine(newCase());
    }
    public void Update()
    {
        if(spawnedObject != null)
        {
            spawnedObject.transform.position = Vector3.MoveTowards(spawnedObject.transform.position, target.position, moveSpeed *Time.deltaTime);
        }
    }
    public bool eAccion()
    {
        Debug.Log("PeticionDeAccionDetectada");
        if(spawnedObject != null && !LevelManager.instance.medicinas)
        {
            Destroy(spawnedObject.gameObject);
            spawnedObject = null;
            LevelManager.instance.medicinas = true;
            LevelManager.instance.UIM.UpdateUI();
            StartCoroutine(newCase());
            return true;
        }
        else
            return false;
    }
    IEnumerator newCase()
    {
        yield return new WaitForSeconds(spawnTime);
        spawnedObject = Instantiate(prefad, spawn.position, Quaternion.identity);
    }
}
