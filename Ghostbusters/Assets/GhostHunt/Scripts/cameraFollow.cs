using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    private Vector3 Offset = new Vector3(0f, 0f, -10f);
    private float smoofTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    public Transform target; 

    // Update is called once per frame
    void Update()
    {
        Vector3 targetgPosition = target.position + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetgPosition, ref velocity, smoofTime);
    }
}
