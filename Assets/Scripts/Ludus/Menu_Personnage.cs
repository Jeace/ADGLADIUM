using UnityEngine;
using System.Collections;

public class Menu_Personnage : MonoBehaviour {
	
	public bool control;
	public XInput inputer;
	public bool appuie = false;
	
	public GameObject Ctr;
	
	// Use this for initialization
	void Start ()
	{
		Ctr = GameObject.Find ("Ludus_Control");
		inputer = GameObject.FindWithTag ("INPUTER").GetComponent<XInput>();
		
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
		transform.Translate (0f, 0f, 8f);
		Controle_MC inp = Ctr.GetComponent<Controle_MC> ();
		inp.control = true;
		control = false;
	}
}