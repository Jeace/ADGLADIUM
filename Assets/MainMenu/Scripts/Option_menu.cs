using UnityEngine;
using System.Collections;

public class Option_menu : MonoBehaviour {

	public GameObject option_butt;
	public XInput inputer;
	public string volume_str;
	public GameObject Main_cam, nombreObject;
	public float hSliderValue = 0.0F;
	private float volume;
	public bool optionSelected = false;
	public bool action;
	string [] tab_opt =  new string[] {"Sound +", "Sound", "Sound -", "ResolutionEcran"};

	int indicecam ;

	// Use this for initialization
	void Start () {

		option_butt = GameObject.FindWithTag (tab_opt[1]);
		nombreObject = GameObject.FindWithTag ("Volume");
		option_butt.renderer.material.color = Color.blue;

		inputer = GameObject.FindWithTag ("INPUTER").GetComponent<XInput>();
	}


	
	// Update is called once per frame
	void Update () {


		Main_cam = GameObject.FindWithTag("MainCamera");
		if(optionSelected){


			MainMenu cam = Main_cam.GetComponent<MainMenu> ();
			cam.set_option(false);

	// Navigation dans le menu

			if ((inputer.DOWNPAD)&& ((option_butt == GameObject.Find (tab_opt [0])) || (option_butt == GameObject.Find (tab_opt [1])) || (option_butt ==GameObject.Find (tab_opt[2]))))
			{

					option_butt.renderer.material.color = Color.white;        
					option_butt = GameObject.FindWithTag (tab_opt [3]);
					option_butt.renderer.material.color = Color.blue;
						

			}

			if (inputer.LEFTPAD)
			{
				if (option_butt == GameObject.FindWithTag (tab_opt [1]))
				    {
				    option_butt.renderer.material.color = Color.white;   
					option_butt = GameObject.FindWithTag (tab_opt [2]);
					option_butt.renderer.material.color = Color.blue;
					}

			}

			if (inputer.RIGHTPAD)
			{

				if (option_butt == GameObject.FindWithTag (tab_opt [1]))
				{
					option_butt.renderer.material.color = Color.white;   
					option_butt = GameObject.FindWithTag (tab_opt [0]);
					option_butt.renderer.material.color = Color.blue;
				}

			}

			if (inputer.UPPAD) {
				
				if ((option_butt == GameObject.Find (tab_opt [0]))|| (option_butt == GameObject.Find (tab_opt [2])) || (option_butt == GameObject.Find (tab_opt [3]))) { 
					
					option_butt.renderer.material.color = Color.white;        
					option_butt = GameObject.FindWithTag (tab_opt [1]);
					option_butt.renderer.material.color = Color.blue;
					
				}
				System.Threading.Thread.Sleep(100);

						
			}

// Variation du volume

			if ((inputer.A) && (option_butt == GameObject.FindWithTag (tab_opt [0])))
			{
				System.Threading.Thread.Sleep(100);
					if(volume <= 100)
					{

						volume_str = volume.ToString();
						TextMesh t = (TextMesh)nombreObject.GetComponent(typeof(TextMesh));
						t.text = volume_str;
						volume ++; 
					}

							}
			if ((inputer.A) && (option_butt == GameObject.FindWithTag (tab_opt [2])) )
			{

					System.Threading.Thread.Sleep(100);

					if(volume >= 0)
					{
						volume_str = volume.ToString();
						TextMesh t = (TextMesh)nombreObject.GetComponent(typeof(TextMesh));
						t.text = volume_str;
						volume --;
					}

			}
//Redirection vers le menu de résolution

			if ((inputer.A)&&((option_butt == GameObject.FindWithTag (tab_opt [3]))))
			{


					action = true;
					Resolution_menu cameraScript = Main_cam.GetComponent<Resolution_menu> ();
					cameraScript.set_option(action);
					CameraScript camerascript = Main_cam.GetComponent<CameraScript> ();
					camerascript.set_move(1);			
					



			}

//Retour au menu principale

			if (inputer.B){	
				

				MainMenu camera = Main_cam.GetComponent<MainMenu> ();
				camera.set_option(true);
				CameraScript camerascript = Main_cam.GetComponent<CameraScript> ();
				camerascript.set_move(2);		
				optionSelected = false;
				
			}	
			
			
			
			
		}

	}


	public bool get_option()
	{
		return optionSelected;
	}
	public void set_option(bool option)
	{
		optionSelected = option;
	}
	
}
