using UnityEngine;
using System.Collections;

public class GameManagement : MonoBehaviour {
	
	public XInput inputer;
	private Camera mainCamera;
	private GameObject player;
	private bool inputed = false;
	public enum Phases {ludus, arena};
	public Phases actualPhase;
	private Vector3 behindPlayer = new Vector3(0.0f, 1.5f, -2.0f);
	private Vector3 frontPlayer = new Vector3(0.0f, 1.5f, 0.5f);

	// Use this for initialization
	void Start () {
		actualPhase = Phases.ludus;
		mainCamera = Camera.main;
		inputer = GameObject.FindWithTag("INPUTER").GetComponent<XInput>();
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		CheckBack ();
	}

	void CheckBack(){
		if (inputed == false) {
			if (actualPhase == Phases.ludus && inputer.BACK == true) {
				actualPhase = Phases.arena;
				player.transform.position = new Vector3(0.0f,2.0f,0.0f);
				player.transform.rotation = Quaternion.FromToRotation(Vector3.left, transform.forward);
				mainCamera.transform.localPosition = behindPlayer;
				inputed = true;
			}else{
				if (actualPhase == Phases.arena && inputer.BACK == true) {
					actualPhase = Phases.ludus;
					mainCamera.transform.localPosition = frontPlayer;
					inputed = true;
				}
			}
		} else {
			if(inputer.BACK == false){
				inputed = false;
			}
		}
	}
}
