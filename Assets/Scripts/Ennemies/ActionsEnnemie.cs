using UnityEngine;
using System.Collections;

public class ActionsEnnemie : MonoBehaviour {
	public GameObject arme1;
	public GameObject arme2;
	public int arme;
	public GameManagement gameManager;
	public float allonge;
	private DetectScript dd;
	private static Texture2D _staticRectTexture;
	private static GUIStyle _staticRectStyle;
	float temps;
	float temps2;
	bool drawdmg;
	int[] dmg;//file d'attente des dommage
	Vector3[] h;//file d'attente de la hauteur des dommages correspondant
	
	// Use this for initialization
	void Start () {
		h=new Vector3[0];
		dmg=new int[0];
		drawdmg = false;
		//arme1 = GameObject.FindWithTag("Arme");
		//arme2 = GameObject.FindWithTag("Arme");
		allonge = 1.0F;
		arme = 0;
		temps = 0.0F;
		temps2 = 0.0F;
		dd=GetComponent<DetectScript>();
		gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManagement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.actualPhase == GameManagement.Phases.arena) {
			if(dd.isAttak){

				//calcule des dommages et préparation de leur affichage
				if(arme.Equals(0)){
					if(dd.distanceCible()<1.5F ){
						if((temps+=Time.deltaTime)>1.0F){
							int[] values=dmg;
							dmg=new int[values.Length+1];
							for(int i=0;i<values.Length;i++)
								dmg[i]=values[i];
							dmg[values.Length]=100;
							Vector3[] valeur=h;
							h=new Vector3[valeur.Length+1];
							for(int i=0;i<valeur.Length;i++)
								h[i]=valeur[i];
							h[valeur.Length]=new Vector3(0,Screen.height/2,Random.Range(-0.5F,0.5F));
							drawdmg=true;
							temps = 0.0F;
							GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>().AjusterSanteActuelle(-(int)Mathf.Round (Random.Range(80,100)));
						}
					}
				}
				else{
					if(arme.Equals(1)){
						if(dd.distanceCible()<arme1.GetComponent<Stat_A>().allonge){
							if((temps+=Time.deltaTime)>1.0F/arme1.GetComponent<Stat_A>().vitesse_atk){
								temps = 0.0F;
								int[] values=dmg;
								dmg=new int[values.Length+1];
								for(int i=0;i<values.Length;i++)
									dmg[i]=values[i];
								dmg[values.Length]=arme1.GetComponent<Stat_A>().degats();
								Vector3[] valeur=h;
								h=new Vector3[valeur.Length+1];
								for(int i=0;i<valeur.Length;i++)
									h[i]=valeur[i];
								h[valeur.Length]=new Vector3(0,Screen.height/2,Random.Range(-0.5F,0.5F));
								drawdmg=true;
								GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>().AjusterSanteActuelle(-dmg[values.Length]);
							}
						}
					}
					if(arme.Equals(2)){
						if(dd.distanceCible()<arme2.GetComponent<Stat_A>().allonge){
							if((temps2+=Time.deltaTime)>1.0F/arme2.GetComponent<Stat_A>().vitesse_atk){
								temps2 = 0.0F;
								int[] values=dmg;
								dmg=new int[values.Length+1];
								for(int i=0;i<values.Length;i++)
									dmg[i]=values[i];
								dmg[values.Length]=arme2.GetComponent<Stat_A>().degats();
								Vector3[] valeur=h;
								h=new Vector3[valeur.Length+1];
								for(int i=0;i<valeur.Length;i++)
									h[i]=valeur[i];
								h[valeur.Length]=new Vector3(0,Screen.height/2,Random.Range(-0.5F,0.5F));
								drawdmg=true;
								GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>().AjusterSanteActuelle(-dmg[values.Length]);
								
							}
						}
					}
				}
			}
		}
	}

	void OnGUI(){

		//affichage des dommages
		Vector3[] valeur;
		int[] values;
		if(drawdmg){
			drawdmg=false;
		}
		for(int i=0;i<h.Length;i++){
			if(h[i].x>-50 && h[i].x<50 ){
				//fonction pour faire sauter les dmgs
				h[i].y=50.0F+((float)((float)Mathf.Pow(-1.0F,Mathf.Ceil(-h[i].z))*h[i].z+0.5F)*0.5F*(float)((h[i].x-(float)Mathf.Pow(-1.0F,Mathf.Ceil(-h[i].z))*30.0F)*(h[i].x-(float)Mathf.Pow(-1.0F,Mathf.Ceil(-h[i].z))*30.0F))-50.0F)/3.0F;
				if(h[i].y>Screen.height/2+50)
					h[i].y=2*Screen.height/2-h[i].y;
				h[i].x=Mathf.Pow(-1,Mathf.Ceil(-h[i].z))+h[i].x;
				GUI.Label(new Rect(
					Screen.width/2+h[i].x,
					h[i].y,
					200,20
					),dmg[i].ToString());
			}else{
				valeur=h;
				h=new Vector3[valeur.Length-1];
				for(int a=0;a<valeur.Length;a++){
					if(a<i)
						h[a]=valeur[a];
					if(a>i)
						h[a-1]=valeur[a];
				}
				values=dmg;
				dmg=new int[values.Length-1];
				for(int a=0;a<values.Length;a++){
					if(a<i)
						dmg[a]=values[a];
					if(a>i)
						dmg[a-1]=values[a];
				}
				i--;
			}
		}
	}
}