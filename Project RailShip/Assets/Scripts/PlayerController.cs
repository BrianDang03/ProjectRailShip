using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movSpeed;
    void Update()
    {
        //Horizontal Control Axis
        float zThrow = Input.GetAxis("Horizontal");
        Debug.Log(zThrow);

        float zOffset = zThrow * movSpeed * Time.deltaTime;

        float newZPos = transform.localPosition.z + zOffset;

        //Vertical Contorl Axis
        float yThrow = Input.GetAxis("Vertical");
        Debug.Log(yThrow);

        float yOffset = yThrow * movSpeed * Time.deltaTime;

        float newYPos = transform.localPosition.y + yOffset;

        //Change the Position
        transform.localPosition = new UnityEngine.Vector3(transform.localPosition.x, newYPos, newZPos);

    }
}