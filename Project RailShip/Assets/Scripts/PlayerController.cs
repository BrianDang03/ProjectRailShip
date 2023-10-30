using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movSpeed = 30f;
    [SerializeField] float xRange = 6f;
    [SerializeField] float yRange = 8f;

    [SerializeField] float posPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow;
    float yThrow;
    void Update()
    {
        UserInput();
        ShipRotation();
    }

    void UserInput()
    {
        //Horizontal Control Axis
        xThrow = Input.GetAxis("Horizontal");
        Debug.Log(xThrow);

        float xOffset = xThrow * movSpeed * Time.deltaTime;
        float rawZPos = transform.localPosition.x + xOffset;
        float clampeXPos = Mathf.Clamp(rawZPos, -xRange, xRange);

        //Vertical Contorl Axis
        yThrow = Input.GetAxis("Vertical");
        Debug.Log(yThrow);

        float yOffset = yThrow * movSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, 0, yRange);

        //Change the Position
        transform.localPosition = new UnityEngine.Vector3(clampeXPos, clampedYPos, transform.localPosition.z);
    }

    void ShipRotation()
    {
        float pitchPos = transform.localPosition.y * posPitchFactor;
        float pitchControl = yThrow * controlPitchFactor;

        float pitch = pitchPos + pitchControl;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}