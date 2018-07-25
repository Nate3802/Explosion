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
        if (other.tag != "Player" && other.tag != "Explosion" && other.tag != "Ricochet")
        {
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        else if(other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
