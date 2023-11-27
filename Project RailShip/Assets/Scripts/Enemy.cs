using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyExplosionFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int hitPoints;
    [SerializeField] int dmgPoints;

    ScoreBoard scoreBoard;
    GameObject parentGameObject;

    [SerializeField] int enemyValue = 100;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnRuntime");
        AddRigidbody();

    }

    private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (hitPoints < 1)
        {
            DestoryEnemy();
        }
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;

        scoreBoard.incScore(enemyValue);
        hitPoints -= dmgPoints;
    }

    private void DestoryEnemy()
    {
        GameObject fx = Instantiate(enemyExplosionFX, transform.position, Quaternion.identity);
        scoreBoard.incScore(enemyValue);
        fx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }
}
