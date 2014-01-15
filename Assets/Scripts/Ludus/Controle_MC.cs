using UnityEngine;
using System.Collections;

public class Controle_MC : MonoBehaviour {
	
	public GameManagement gameManager;
	public GameObject Main_cam;

	public GameObject Competence;
	public GameObject Entraineur;
	public GameObject Forge;
	public GameObject Personnage;

	public GameObject m_Competence;
	public GameObject m_Entraineur;
	public GameObject m_Forge;
	public GameObject m_Personnage;

	public string etat = "null";
	public XInput inputer;
	public int index = 0;

	public bool control = true;
	bool appuie = false;

	string caps_visee;
	
	// Use this for initialization
	void Start ()
	{
		gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManagement>();
		// Commande 360
		inputer = GameObject.FindWithTag ("INPUTER").GetComponent<XInput>();
		//Recuperation objet 
		//Cam
		//Main_cam = GameObject.FindWithTag ("MainCamera");
		Main_cam = GameObject.FindWithTag ("Player");

		//Capsule
		Competence = GameObject.FindWithTag ("Caps - Competence");
		Forge = GameObject.FindWithTag ("Caps - Forge");
		Entraineur = GameObject.FindWithTag ("Caps - Entraineur");
		Personnage = GameObject.FindWithTag ("Caps - Personnage");

		//Menu
		m_Competence = GameObject.FindWithTag ("Menu - Competence");
		m_Forge = GameObject.FindWithTag ("Menu - Forge");
		m_Entraineur = GameObject.FindWithTag ("Menu - Entraineur");
		m_Personnage = GameObject.FindWithTag ("Menu - Personnage");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (gameManager.actualPhase == GameManagement.Phases.ludus) {
			GameObject[] cap = new GameObject[] {Competence,Forge,Entraineur,Personnage};
			RaycastHit hit;

			if(inputer.LT == false && inputer.RT == false)
				appuie=false;

			if (control == true) 
			{
				// Test touche gachette
				if (inputer.LT == true && appuie==false ) { //Gauche
					index -= 1;

					if (index < 0)
							index = 3;

					appuie = true;
				}

				if (inputer.RT == true && appuie==false) { //Droite
					index += 1;

					if (index > 3)
							index = 0;

					appuie = true;
				}

				//Selection d'un menu
				if (inputer.A == true) 
				{
					if (caps_visee == "Caps - Personnage") 
					{
						m_Personnage.transform.Translate (0f, 0f, -8f);

						Menu_Personnage m_p = m_Personnage.GetComponent<Menu_Personnage>();
						m_p.Control();
						
						control = false;
					}

					if (caps_visee == "Caps - Competence") 
					{
						m_Competence.transform.Translate (0f, 0f, -8f);

						Menu_Competence m_c = m_Competence.GetComponent<Menu_Competence>();
						m_c.Control();

						control = false;
					}

					if (caps_visee == "Caps - Forge") {
						m_Forge.transform.Translate (0f, 0f, -8f);
						
						Menu_Forge m_f = m_Forge.GetComponent<Menu_Forge>();
						m_f.Control();
						
						control = false;
					}

					if (caps_visee == "Caps - Entraineur") {
						m_Entraineur.transform.Translate (0f, 0f, 8f);
						
						Menu_Entraineur m_e = m_Entraineur.GetComponent<Menu_Entraineur>();
						m_e.Control();
						
						control = false;
					}
				}
			}
			// Rotation
			Vector3 targetPoint = cap [index].transform.position;
			Quaternion targetRotation = Quaternion.LookRotation (targetPoint - transform.position, Vector3.up);
			Main_cam.transform.position = transform.position;
			Main_cam.transform.rotation = Quaternion.Slerp (Main_cam.transform.rotation, targetRotation, Time.deltaTime * 1.0f);
			
			// Camera Laser de la mort qui tue ...
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
			if (Physics.Raycast (ray, out hit))
				if (hit.collider != null) 
			{
				caps_visee=hit.collider.gameObject.tag;
			}
		}
	}
}