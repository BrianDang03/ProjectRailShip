using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerExplosionFX;
    [SerializeField] float reloadDelay = 2f;

    [Header("Laser Gun Array")]
    [Tooltip("Add All Lasers Here")]
    [SerializeField] GameObject[] lasers;

    GameObject parentGameOject;

    void Start()
    {
        parentGameOject = GameObject.FindWithTag("SpawnRuntime");
    }

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        GetComponent<PlayerController>().enabled = false;
        PlayerExplosion();
        Invoke("ReloadLevel", reloadDelay);
    }

    void PlayerExplosion()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionsModule = laser.GetComponent<ParticleSystem>().emission;
            emissionsModule.enabled = false;
        }

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        GameObject fx = Instantiate(playerExplosionFX, transform.position, Quaternion.identity);
        fx.transform.parent = parentGameOject.transform;
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
