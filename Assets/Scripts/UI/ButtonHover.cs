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
        //If mouse is over the button, player cannot shoot
        player.GetComponent<shootBullet>().unshootable = true;
    }

    public void mouseExit()
    {
        //If mouse is not over the button, player can shoot
        player.GetComponent<shootBullet>().unshootable = false;
    }
}
