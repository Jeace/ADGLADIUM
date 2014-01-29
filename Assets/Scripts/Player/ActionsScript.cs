using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MoveScript))]
public class ActionsScript : MonoBehaviour {
	public XInput inputer;
	public GameManagement gameManager;
	public bool enAttack;
	public float temps;
	
	// Use this for initialization
	void Start () {
		enAttack = false;
		inputer = GameObject.FindWithTag ("INPUTER").GetComponent<XInput>();
		gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManagement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.actualPhase == GameManagement.Phases.arena) {
			if(!enAttack){
				if(inputer.X){
					temps = GameObject.FindWithTag("Arme").GetComponent<Stat_A>().vitesse_atk;
					enAttack=true;
				}
			}
			if(temps<=0.0F){
				enAttack=false;
				GameObject.FindWithTag("Arme").GetComponent<Transform>().position= new Vector3(
					GameObject.FindWithTag("Arme").GetComponent<Stat_A>().position.x+GetComponent<Transform>().position.x,
					GameObject.FindWithTag("Arme").GetComponent<Stat_A>().position.y+GetComponent<Transform>().position.y,
					GameObject.FindWithTag("Arme").GetComponent<Stat_A>().position.z+GetComponent<Transform>().position.z);
				GameObject.FindWithTag("Arme").GetComponent<Transform>().rotation = GameObject.FindWithTag("Arme").GetComponent<Stat_A>().rotation;
			}
			else {
				temps =temps-Time.fixedDeltaTime*2*GameObject.FindWithTag("Arme").GetComponent<Stat_A>().vitesse_atk;
				GameObject.FindWithTag("Arme").GetComponent<Stat_A>().attackMovement((temps > GameObject.FindWithTag("Arme").GetComponent<Stat_A>().vitesse_atk/2.0F));
			}
		}
	}
}
