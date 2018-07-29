using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float bulletVelocity;
    public GameObject bullet;
    public GameObject bullet1;
    public GameObject Player;
    public int interval;
    public bool shoot;

    // Use this for initialization
    void Start()
    {
        shoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(shoot == true)
        {
            //Start function below after the function runs through
            StartCoroutine(SpawnBullet());
            shoot = false;
        }
    }

    IEnumerator SpawnBullet()
    {
        //Wait for certain amount of seconds before function
        yield return new WaitForSeconds(interval);
        //Find the player's position
        Vector3 PlayerPos = Player.transform.position;
        //Find the direction the player is from this object
        Vector2 direction = (Vector2)((PlayerPos - transform.position));
        direction.Normalize();

        // Creates the bullet locally
        GameObject bullet = (GameObject)Instantiate(
                                bullet1,
                                transform.position + (Vector3)(direction * 0.5f),
                                Quaternion.identity);

        // Adds velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;

        shoot = true;
    }
}

