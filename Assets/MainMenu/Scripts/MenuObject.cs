﻿using UnityEngine;
using System.Collections;

public class MenuObject : MonoBehaviour {

	// Use this for initialization
	void OnMouseEnter () {

		renderer.material.color = Color.blue;
	}
	
	// Update is called once per frame
	void OnMouseExit () {

		renderer.material.color = Color.white;
	
	}
}
