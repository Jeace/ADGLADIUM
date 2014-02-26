using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public int indicecam = 0;
	public bool action = false;
	public GameObject Menu_Option , Main_Menu, Menu_Resolution, Main_cam;

void Start () {
		Menu_Resolution = GameObject.FindWithTag ("Resolution");
		Menu_Option = GameObject.FindWithTag ("Sound");
		Main_cam = GameObject.FindWithTag("MainCamera");
		Main_Menu = GameObject.FindWithTag ("Start Game");		
	}
	

void Update () {
		GameObject [] tab_GO =  new GameObject[] {Menu_Option, Menu_Resolution, Main_Menu};
	
		//Activation de la caméra
				if (action) {
						
						//Mouvement de la caméra
						Vector3 targetPoint = tab_GO [indicecam].transform.position;
						Quaternion targetRotation = Quaternion.LookRotation (targetPoint - transform.position, Vector3.up);
						transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * 2.0f);
				}
		}

	public bool get_option()
	{
		return action;
	}
	public void set_option(bool move)
	{
		action = move;
	}

	public int get_move()
	{
		return indicecam;
	}
	public void set_move(int indice)
	{
		indicecam = indice;
	}
}
