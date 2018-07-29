using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject Explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //If does not collide with player, explosion or ricochet plate...
        if (other.tag != "Player" && other.tag != "Explosion" && other.tag != "Ricochet")
        {
            //Spawn explosion at position and rotation of this object
            Instantiate(Explosion, transform.position, transform.rotation);
            //Destroy this object
            Destroy(gameObject);
        }
        //If collides with enemy...
        else if(other.tag == "Enemy")
        {
            //Destroy Enemy
            Destroy(other.gameObject);
        }
        //If collides with other bullet...
        else if(other.tag == "Bullet")
        {
            //Destroy other bullet
            Destroy(gameObject);
        }
    }
}
