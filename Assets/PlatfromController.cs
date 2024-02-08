using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromController : MonoBehaviour
{
    public Transform StartPOS;
    public Transform EndPOS;
    public float Speed = 3;
    public float time = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(StartPOS.position,EndPOS.position,Mathf.Sin(Time.time * Speed));
        Debug.Log("Start: "+StartPOS.position.z);
        Debug.Log("End: "+EndPOS.position.z);
    }
}
