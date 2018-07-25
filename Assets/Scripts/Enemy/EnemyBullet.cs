using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public GameObject EnemyExplosion;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Enemy" && other.tag != "Explosion")
        {
            Instantiate(EnemyExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
