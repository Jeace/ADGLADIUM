using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MoveScript))]
public class ActionsScript : MonoBehaviour {
	public XInput inputer;
	public GameManagement gameManager;
	
	// Use this for initialization
	void Start () {
		inputer = GameObject.FindWithTag ("INPUTER").GetComponent<XInput>();
		gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManagement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.actualPhase == GameManagement.Phases.arena) {
		}
	}
}
