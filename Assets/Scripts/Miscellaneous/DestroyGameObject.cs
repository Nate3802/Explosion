using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour {
    //This script is for animation purposes
    public bool destroy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(destroy == true)
        {
            Destroy(gameObject);
        }
	}
}
