using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBullet : MonoBehaviour {
    public GameObject Explosion;
    public bool stuck = false;
    public Rigidbody2D rb;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetMouseButtonDown(1))
        {

         
            Instantiate(Explosion, transform.position, transform.rotation);
            stuck = false;
            Destroy(gameObject);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //If does not collide with player, explosion or ricochet plate...
        if (other.tag != "Player" && other.tag != "Explosion" && other.tag != "Ricochet")
        {
            //Stops bullet 
            rb.velocity = new Vector2(0, 0);
            
            stuck = true;


        }
        //If collides with enemy...
        else if (other.tag == "Enemy")
        {
            //Destroy Enemy
            Destroy(other.gameObject);
        }
        //If collides with other bullet...
        else if (other.tag == "Bullet")
        {
            //Destroy other bullet
            Destroy(gameObject);
        }
    }
}
