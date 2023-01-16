using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        Follow();
    }     

    // Update is called once per frame
    void Follow()
    {
        
    }
}
