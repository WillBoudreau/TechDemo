using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    float MaxY = 15;
    float time = 5;
    public GameObject door;
    public Transform top;
    public Transform bottom;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        door.transform.position = Vector3.Lerp(bottom.position,top.position,time);
    }
}
