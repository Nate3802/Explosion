using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnUI : MonoBehaviour {
    //This script is for animation purposes
    public bool TurnOn;
    public GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(TurnOn == true)
        {
            obj.SetActive(true);
        }
	}
}
