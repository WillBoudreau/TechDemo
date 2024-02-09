using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{
    Renderer myMaterial;
    // Start is called before the first frame update
    void Start()
    {
        myMaterial= GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            myMaterial.material.color = Color.red;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            myMaterial.material.color = Color.green;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            myMaterial.material.color = Color.white;
        }
    }
}
