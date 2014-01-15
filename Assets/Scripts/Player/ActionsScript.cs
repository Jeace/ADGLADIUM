using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MoveScript))]
public class ActionsScript : MonoBehaviour {
	public XInput inputer;
	
	// Use this for initialization
	void Start () {
		inputer = GameObject.FindWithTag ("INPUTER").GetComponent<XInput>();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
