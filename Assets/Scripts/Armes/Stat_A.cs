using UnityEngine;
using System.Collections;

public class Stat_A : MonoBehaviour {
	public int force, agilite, vitalite, constitution, endurance, degat_min,degat_max;
	public string nom;
	public Vector3 position;
	public Quaternion rotation;
	public float PV, energie,poids_max,allonge, resistance_cont, resistance_tranch, balance, vitesse_depl, vitesse_atk, crit;

	// Use this for initialization
	void Start () {
		degat_min = 50;
		degat_max = 60;
		allonge = 2.0F;
		vitesse_atk = 2.0F;
		rotation =GetComponent<Transform>().rotation;
		position = new Vector3(
			GetComponent<Transform>().position.x-GameObject.FindWithTag("Player").transform.position.x,
			GetComponent<Transform>().position.y-GameObject.FindWithTag("Player").transform.position.y,
			GetComponent<Transform>().position.z-GameObject.FindWithTag("Player").transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public int degats(){
		return (int)Mathf.Round(Random.Range (degat_min, degat_max));
	}

	public void attackMovement(bool retour){
		if(!retour)
			GetComponent<Transform>().RotateAround(GameObject.FindWithTag("Player").transform.position,Vector3.up,-75*Time.deltaTime*vitesse_atk*2);
		else
			GetComponent<Transform>().RotateAround(GameObject.FindWithTag("Player").transform.position,Vector3.up,+75*Time.deltaTime*vitesse_atk*2);
	}
	
	void OnTriggerEnter(Collider collision){
		if(collision.gameObject.CompareTag("ennemie") & GameObject.FindWithTag("Player").GetComponent<ActionsScript>().enAttack){
			if(collision.GetComponent<Stat_Ennemie>().degatAttente==0){
				collision.GetComponent<Stat_Ennemie>().degatAttente=50;
			}
			//collision.GetComponent<Stat_Ennemie>().AjusterSanteActuelle(-50);
		}
	}
}
