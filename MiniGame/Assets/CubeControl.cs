using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{

    Transform tR;
    Rigidbody rB;

    float fallSpeed = 0.02f;
    bool contact = false;

    void Start()
    {
        tR = GetComponent<Transform>();
        rB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        if (contact == false)
        {

            Vector3 finalVector = new Vector3(horiz, 0f, vert);
            finalVector.Normalize();
            finalVector = finalVector * 0.05f;

            tR.position = tR.position + finalVector;

            tR.position = tR.position + new Vector3(0, -fallSpeed, 0);
        }
        else
        {
            rB.useGravity = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        contact = true;
    }
}
