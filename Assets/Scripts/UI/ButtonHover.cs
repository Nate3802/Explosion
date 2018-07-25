using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void mouseOver()
    {
        player.GetComponent<shootBullet>().unshootable = true;
    }

    public void mouseExit()
    {
        player.GetComponent<shootBullet>().unshootable = false;
    }
}
