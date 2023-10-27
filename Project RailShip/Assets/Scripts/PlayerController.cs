using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movSpeed = 30f;
    [SerializeField] float zRange = 6f;
    [SerializeField] float yRange = 8f;

    [SerializeField] float posPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;

    float zThrow;
    float yThrow;
    void Update()
    {
        UserInput();
        ShipRotation();
    }

    void UserInput()
    {
        //Horizontal Control Axis
        zThrow = Input.GetAxis("Horizontal");
        Debug.Log(zThrow);

        float zOffset = zThrow * movSpeed * Time.deltaTime;
        float rawZPos = transform.localPosition.z + zOffset;
        float clampedZPos = Mathf.Clamp(rawZPos, -zRange, zRange);

        //Vertical Contorl Axis
        yThrow = Input.GetAxis("Vertical");
        Debug.Log(yThrow);

        float yOffset = yThrow * movSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, 0, yRange);

        //Change the Position
        transform.localPosition = new UnityEngine.Vector3(transform.localPosition.x, clampedYPos, clampedZPos);
    }

    void ShipRotation()
    {
        float pitchPos = transform.localPosition.y * posPitchFactor;
        float pitchControl = yThrow * controlPitchFactor;

        float pitch = pitchPos + pitchControl;
        float yaw = transform.localPosition.z * positionYawFactor - 90;
        float roll = zThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}