using UnityEngine;
using System.Collections;

public class Resolution_menu : MonoBehaviour {

	public GameObject Main_cam;
	string [] tab_but =  new string[] {"Resolution", "Resolution -", "Resolution +", "Qualite", "Qualite -", "Qualite +", "Qualite Medium"};
	public GameObject startButt;
	public bool optionSelected = false;
	public int indicecam = 0, quality_lvl=0;
	public bool action;
	public XInput inputer;
	Resolution[] resolutions;
	


void Start () {
	
		startButt = GameObject.FindWithTag (tab_but[0]);
		startButt.renderer.material.color = Color.blue;
		resolutions = Screen.resolutions;
		inputer = GameObject.FindWithTag ("INPUTER").GetComponent<XInput>();
	}
	

void Update () {

		Main_cam = GameObject.FindWithTag("MainCamera");
	
//Activation du menu
	if (optionSelected) {

			Option_menu cameraScript = Main_cam.GetComponent<Option_menu> ();
			cameraScript.set_option(false);

//Navigation dans le menu résolution

			if ((inputer.UPPAD)&&((startButt == GameObject.FindWithTag (tab_but [1])) || (startButt == GameObject.FindWithTag (tab_but [2])) || (startButt == GameObject.FindWithTag (tab_but [3])))) {
				
				System.Threading.Thread.Sleep (100);
				startButt.renderer.material.color = Color.white;        
				startButt = GameObject.FindWithTag (tab_but [0]);
				startButt.renderer.material.color = Color.blue;
				
			}
			

			
			if ((inputer.UPPAD)&&((startButt == GameObject.FindWithTag (tab_but [4])) || (startButt == GameObject.FindWithTag (tab_but [5])) || (startButt == GameObject.FindWithTag (tab_but [6])))) {

				System.Threading.Thread.Sleep (100);
				startButt.renderer.material.color = Color.white;        
				startButt = GameObject.FindWithTag (tab_but [0]);
				startButt.renderer.material.color = Color.blue;
				
				
			}
			//Left
			if ((inputer.LEFTPAD)&&((startButt == GameObject.FindWithTag (tab_but [0])))) {
				
				System.Threading.Thread.Sleep (100);					
				startButt.renderer.material.color = Color.white;        
				startButt = GameObject.FindWithTag (tab_but [1]);
				startButt.renderer.material.color = Color.blue;
				
			}			
			
			if ((inputer.LEFTPAD)&&((startButt == GameObject.FindWithTag (tab_but [3])))) {
				
				System.Threading.Thread.Sleep (100);
				startButt.renderer.material.color = Color.white;        
				startButt = GameObject.FindWithTag (tab_but [4]);
				startButt.renderer.material.color = Color.blue;
				
			}
			
			
			if ((inputer.LEFTPAD)&&((startButt == GameObject.FindWithTag (tab_but [6])))){
				
				System.Threading.Thread.Sleep (100);
				startButt.renderer.material.color = Color.white;        
				startButt = GameObject.FindWithTag (tab_but [4]);
				startButt.renderer.material.color = Color.blue;
				
			}
			
			
			//Right
			if ((inputer.RIGHTPAD)&&((startButt == GameObject.FindWithTag (tab_but [0])))) {
				
				System.Threading.Thread.Sleep (100);
				startButt.renderer.material.color = Color.white;        
				startButt = GameObject.FindWithTag (tab_but [2]);
				startButt.renderer.material.color = Color.blue;
				
			}
			
			if ((inputer.RIGHTPAD)&&((startButt == GameObject.FindWithTag (tab_but [3])))) {
				
				System.Threading.Thread.Sleep (100);
				startButt.renderer.material.color = Color.white;        
				startButt = GameObject.FindWithTag (tab_but [5]);
				startButt.renderer.material.color = Color.blue;
				
			}
			
			
			if ((inputer.RIGHTPAD)&&((startButt == GameObject.FindWithTag (tab_but [4])))){
				
				System.Threading.Thread.Sleep (100);
				startButt.renderer.material.color = Color.white;        
				startButt = GameObject.FindWithTag (tab_but [6]);
				startButt.renderer.material.color = Color.blue;
				
			}
			
			
			if ((inputer.RIGHTPAD)&&((startButt == GameObject.FindWithTag (tab_but [6])))){
				
				System.Threading.Thread.Sleep (100);
				startButt.renderer.material.color = Color.white;        
				startButt = GameObject.FindWithTag (tab_but [5]);
				startButt.renderer.material.color = Color.blue;
				
				
			}

			//Down 

			if ((inputer.DOWNPAD)&&((startButt == GameObject.FindWithTag (tab_but [0])) || (startButt == GameObject.FindWithTag (tab_but [1])) || (startButt == GameObject.FindWithTag (tab_but [2])))){
							
						
						System.Threading.Thread.Sleep (100);
						startButt.renderer.material.color = Color.white;        
						startButt = GameObject.FindWithTag (tab_but [3]);
						startButt.renderer.material.color = Color.blue;
						
				
			}

								System.Threading.Thread.Sleep (100);
			
			
			if ((inputer.DOWNPAD)&&((startButt == GameObject.FindWithTag (tab_but [3]))) ){

						startButt.renderer.material.color = Color.white;        
						startButt = GameObject.FindWithTag (tab_but [6]);
						startButt.renderer.material.color = Color.blue;
				
			}
			
//Variation Résolution
			if ((inputer.A)&&((startButt == GameObject.FindWithTag (tab_but [2])))) {

				for (int i= 0; i<resolutions.Length; i++) {
					if (resolutions [i].width == Screen.currentResolution.width && resolutions [i].height == Screen.currentResolution.height) {
							if (Screen.fullScreen) {
									Screen.SetResolution (resolutions [i + 1].width, resolutions [i + 1].height, true);
							} else {
									Screen.SetResolution (resolutions [i + 1].width, resolutions [i + 1].height, false);
							}
					}
												

				}

					Debug.Log ("Augmente la resolution");	
			}

			if ((inputer.A)&&((startButt == GameObject.FindWithTag (tab_but [1])))){
				for (int i= 0; i<resolutions.Length; i++) {
					if (resolutions [i].width == Screen.currentResolution.width && resolutions [i].height == Screen.currentResolution.height) {
						if (Screen.fullScreen) {
									Screen.SetResolution (resolutions [i - 1].width, resolutions [i - 1].height, true);
							} else {
									Screen.SetResolution (resolutions [i - 1].width, resolutions [i - 1].height, false);
								}
						}
					}
					Debug.Log ("Diminue la resolution");
				}
			
						

//Variation Qualité

			if ((inputer.A)&&((startButt == GameObject.FindWithTag (tab_but [4]))) ) {
						
							QualitySettings.SetQualityLevel(1); //==> l'index 3 correspond à la qualité FAST (min)
							Debug.Log ("Qualité Basse"); 
					}


			if ((inputer.A)&&((startButt == GameObject.FindWithTag (tab_but [6])))) {

							QualitySettings.SetQualityLevel(3); //==> l'index 3 correspond à la qualité GOOD
							Debug.Log ("Qualité Medium");
				
				}
		
			if ((inputer.A)&&((startButt == GameObject.FindWithTag (tab_but [5])))) {								
							
							QualitySettings.SetQualityLevel(5); //==> l'index 5 correspond à la qualité FANTASTIC (max)
							Debug.Log ("Qualité Haute");

					}
						



				

//Retour au menu principal
			if (inputer.B){	

								MainMenu cam = Main_cam.GetComponent<MainMenu> ();
								cam.set_option(true);
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
