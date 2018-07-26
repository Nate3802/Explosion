using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public GameObject player;
    public Rigidbody2D rb;
    public float division;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x / division, player.GetComponent<Rigidbody2D>().velocity.y / division);
	}
}
