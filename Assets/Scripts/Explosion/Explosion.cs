using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float Power;
    public float Radius;
    //Set enemy variable to true for enemy explosions, and to false for player explosions
    public bool enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        //If collides with Player...
        if (collision.tag == "Player")
        {
            //Calls 'AddExplosionForce' function and establishes variables for the function
            AddExplosionForce(collision.GetComponent<Rigidbody2D>(), Power * 100, gameObject.transform.position, Radius);
        }
        //If collides with Enemy...
        else if (collision.tag == "Enemy" && enemy == false)
        {
            //Destroy Enemy
            Destroy(collision.gameObject);
        }
    }


    public static void AddExplosionForce(Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
    {
        //Find direction of player relative to this object
        var dir = (body.transform.position - expPosition);
        //calculate force based on variables from above
        float calc = 1 - (dir.magnitude / expRadius);
        if (calc <= 0)
        {
            calc = 0;
        }
        //Add force to objects
        body.AddForce(dir.normalized * expForce * calc);
    }
}
