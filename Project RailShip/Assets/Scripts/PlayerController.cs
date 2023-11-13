using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How Fast Ship Moves Up and Down")]
    [SerializeField] float movSpeed = 30f;
    [Tooltip("How Far Player Moves Horizontally")]
    [SerializeField] float xRange = 6f;
    [Tooltip("How Far Player Moves Vertically")]
    [SerializeField] float yRange = 8f;

    [Header("Screen Position Based Tuning")]
    [SerializeField] float posPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player Position Based Tuning")]
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float controlRollFactor = -20f;

    [Header("Laser Gun Array")]
    [Tooltip("Add All Lasers Here")]
    [SerializeField] GameObject[] lasers;

    float xThrow;
    float yThrow;
    void Update()
    {
        FireInput();
        UserInput();
        ShipRotation();
    }

    void UserInput()
    {
        //Horizontal Control Axis
        xThrow = Input.GetAxis("Horizontal");

        float xOffset = xThrow * movSpeed * Time.deltaTime;
        float rawZPos = transform.localPosition.x + xOffset;
        float clampeXPos = Mathf.Clamp(rawZPos, -xRange, xRange);

        //Vertical Control Axis
        yThrow = Input.GetAxis("Vertical");

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

    void FireInput()
    {
        if (Input.GetMouseButton(0))
        {
            SetActiveLaser(true);
        }
        else
        {
            SetActiveLaser(false);
        }
    }

    void SetActiveLaser(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emissionsModule = laser.GetComponent<ParticleSystem>().emission;
            emissionsModule.enabled = isActive;
        }
    }
}