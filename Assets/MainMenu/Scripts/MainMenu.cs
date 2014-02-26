using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public GameObject Main_cam;
	public XInput inputer;
	bool action ;
	bool optionSelected = true;
	public GameObject startButt;
	private int selected ;

	string [] tab_but =  new string[] {"New Game", "Start Game", "Option", "Quit Game"};
	

void Start () {
		
		startButt = GameObject.FindWithTag (tab_but[0]);
		startButt.renderer.material.color = Color.blue;
		selected = 0;
		Main_cam = GameObject.FindWithTag("MainCamera");
		inputer = GameObject.FindWithTag ("INPUTER").GetComponent<XInput>();
		
	}
	

void Update () {



//Activation du Menu
		if (optionSelected) {

//Navugation dans le menu option

			if (((inputer.DOWNPAD) && selected < 3) && (startButt == GameObject.FindWithTag (tab_but [selected]))) {
			
					System.Threading.Thread.Sleep (100);							
					startButt.renderer.material.color = Color.white;        
					startButt = GameObject.FindWithTag (tab_but [selected + 1]);
					startButt.renderer.material.color = Color.blue;
										
				
				selected++;
			}
		
		
			if (((inputer.UPPAD) && selected > 0) && (startButt == GameObject.FindWithTag (tab_but [selected]))) {
				
					System.Threading.Thread.Sleep (100);										
					startButt.renderer.material.color = Color.white;        
					startButt = GameObject.FindWithTag (tab_but [selected - 1]);
					startButt.renderer.material.color = Color.blue;				
					selected--;
			}

//Redirection vers le menu option
			if ((inputer.A)&&(startButt == GameObject.FindWithTag (tab_but [2]))) {
					
					System.Threading.Thread.Sleep (100);
					action = true;
					Option_menu camera_option = Main_cam.GetComponent<Option_menu> ();
					camera_option.set_option(action);
					CameraScript camerascript = Main_cam.GetComponent<CameraScript> ();
					camerascript.set_option(action);
					camerascript.set_move(0);
							
			}
//Lancement du jeu

			if ((inputer.A)&&(startButt == GameObject.FindWithTag (tab_but [1]))) {
					
				Application.LoadLevel(1); // le nom de la scene = 1
					
			}
//Chargement d'une partie

			if ((inputer.A)&&(startButt == GameObject.FindWithTag (tab_but [1]))) {
				

				
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
