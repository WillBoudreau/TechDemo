using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    float RespawnDelay = 1.0f;
    Renderer CollectMat;
    // Start is called before the first frame update
    void Start()
    {
        CollectMat = GetComponent<Renderer>();
        CollectMat.material.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void Respawn()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {  
            gameObject.SetActive(false);
            Invoke("Respawn", RespawnDelay);
        }
    }
}
