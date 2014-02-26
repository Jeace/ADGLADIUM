using UnityEngine;
using System.Collections;

public class Menu_Personnage : MonoBehaviour {
	
	public bool control;
	public XInput inputer;
	public GameObject fond;
	public bool appuie = false;
	public Texture Stat;
	public Texture curseur;
	public GameObject Ctr;

	public int selGridEQ = 0;
	public int selGridAR = 0;
	public int selGridCO = 0;

	public string[] Equipement = new string[] {"Casque", "Plastron", "Bras","Jambe", "Pied",};
	public string[] Arme = new string[] {"Arme 1", "Arme 2", "Arme D",};
	public string[] Conso = new string[] {"Conso 1", "Conso 2",};

	// Use this for initialization
	void Start ()
	{
		Ctr = GameObject.Find ("Ludus_Control");
		inputer = GameObject.FindWithTag ("INPUTER").GetComponent<XInput>();
		fond = GameObject.FindWithTag ("Fond - Entraineur");
		
		control = false;
	}
	
	// Update is called once per frame
	void Update ()
	{	
		if (control == true)
		{
			if (inputer.B == true && appuie == false)
			{
				Fin ();
				appuie = true;
			}
			else
				appuie = false;
		}
	}
	
	public void Control()
	{
		control = true;
	}
	
	void Fin()
	{
		Controle_MC inp = Ctr.GetComponent<Controle_MC> ();
		inp.control = true;
		control = false;
	}

	public float a,b,c,d;

	void OnGUI()
	{
		Stats stats = GameObject.FindWithTag ("Player").GetComponent<Stats>();

		float width_ecran = Screen.width*0.98f;
		float height_ecran = Screen.height*0.98f;

		if (control == true) {
			GUI.BeginGroup (new Rect (10, 10, width_ecran, height_ecran),Stat);
			selGridEQ = GUI.SelectionGrid(new Rect(width_ecran*0.215f, height_ecran*0.105f, width_ecran*0.443f, height_ecran*0.16f), selGridEQ, Equipement, 5);
			selGridAR = GUI.SelectionGrid(new Rect(width_ecran*0.215f, height_ecran*0.299f, width_ecran*0.265f, height_ecran*0.16f), selGridAR, Arme, 3);
			selGridCO = GUI.SelectionGrid(new Rect(width_ecran*0.505f, height_ecran*0.3f, width_ecran*0.153f, height_ecran*0.16f), selGridCO, Conso, 2);

			GUI.Label(new Rect(Screen.width*0.28f, Screen.height*0.68f, Screen.width, Screen.height),stats.PVMAX.ToString());
			GUI.Label(new Rect(Screen.width*0.55f, Screen.height*0.68f, Screen.width, Screen.height),stats.energieMAX.ToString());

			GUI.Label(new Rect(Screen.width*0.25f, Screen.height*0.55f, Screen.width, Screen.height),stats.force.ToString());
			GUI.Label(new Rect(Screen.width*0.335f, Screen.height*0.55f, Screen.width, Screen.height),stats.agilite.ToString());
			GUI.Label(new Rect(Screen.width*0.423f, Screen.height*0.55f, Screen.width, Screen.height),stats.vitalite.ToString());
			GUI.Label(new Rect(Screen.width*0.51f, Screen.height*0.55f, Screen.width, Screen.height),stats.constitution.ToString());
			GUI.Label(new Rect(Screen.width*0.6f, Screen.height*0.55f, Screen.width, Screen.height),stats.endurance.ToString());

			GUI.Label(new Rect(Screen.width*0.37f, Screen.height*0.78f, Screen.width, Screen.height),stats.degats_droite.ToString());
			GUI.Label(new Rect(Screen.width*0.37f, Screen.height*0.803f, Screen.width, Screen.height),stats.degats_gauche.ToString());
			GUI.Label(new Rect(Screen.width*0.37f, Screen.height*0.83f, Screen.width, Screen.height),stats.crit.ToString());
			GUI.Label(new Rect(Screen.width*0.37f, Screen.height*0.895f, Screen.width, Screen.height),stats.vitesse_droite.ToString());
			GUI.Label(new Rect(Screen.width*0.37f, Screen.height*0.92f, Screen.width, Screen.height),stats.vitesse_gauche.ToString());

			GUI.Label(new Rect(Screen.width*0.59f, Screen.height*0.782f, Screen.width, Screen.height),stats.resistance_tranch.ToString());
			GUI.Label(new Rect(Screen.width*0.59f, Screen.height*0.803f, Screen.width, Screen.height),stats.resistance_cont.ToString());
			GUI.Label(new Rect(Screen.width*0.59f, Screen.height*0.928f, Screen.width, Screen.height),stats.vitesse_depl.ToString());

		//	GUI.Label(new Rect(Screen.width*0.445f+(stats.poids_actuel*0.155f), Screen.height*0.857f, Screen.width, Screen.height),curseur);
		//	GUI.Label(new Rect(Screen.width*0.055f+(stats.poids_actuel*0.075f), Screen.height*0.895f, Screen.width, Screen.height),curseur);

			GUI.Label(new Rect(Screen.width*0.09f, Screen.height*0.73f, Screen.width, Screen.height),stats.gloire.ToString());


			GUI.EndGroup();
		}
	}
}