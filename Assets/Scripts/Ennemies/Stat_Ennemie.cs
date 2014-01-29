using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Transform))]
public class Stat_Ennemie : MonoBehaviour {
	
	public GameManagement gameManager;
	public Vector3 pos;
	public int force, agilite, vitalite, constitution, endurance, niveau, argent,degatAttente;
	public float PV, PVMAX, energie, energieMAX, poids_max, poids_actuel, degats_droite, degats_gauche, resistance_cont, resistance_tranch, balance, vitesse_depl, vitesse_atk, crit;
	public float LongueurBarreEndurance, LongueurBarreSante, LongueurBarreEnduranceMAX, LongueurBarreSanteMAX;
	private static Texture2D _staticRectTexture;
	private static GUIStyle _staticRectStyle;
	
	// Use this for initialization
	void Start () {
		degatAttente = 0;
		LongueurBarreSanteMAX = Screen.width/6;
		PVMAX = 1000;
		PV = 1000;
		gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManagement>();
		AjusterSanteActuelle (0);
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.actualPhase == GameManagement.Phases.arena) {
			if(GameObject.FindWithTag("Player").GetComponent<ActionsScript>().enAttack)
				AjusterSanteActuelle (degatAttente);
		}
	}

	void OnGUI () {
	//	if(Physics.Raycast(new Ray(Camera.main.ViewportPointToRay(transform.position)),out new Ray())){
			pos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x,transform.position.y+0.5F,transform.position.z));
			float d=(float)Mathf.Pow(Mathf.Max((float)transform.position.x-(float)GameObject.FindWithTag("Player").transform.position.x,(float)-((float)transform.position.x-(float)GameObject.FindWithTag("Player").transform.position.x)),2);
			d+=(float)Mathf.Pow(Mathf.Max((float)transform.position.z-(float)GameObject.FindWithTag("Player").transform.position.z,(float)-((float)transform.position.z-(float)GameObject.FindWithTag("Player").transform.position.z)),2);
			d=Mathf.Pow(d,0.5F);
			if(d<10.0F){
				if (gameManager.actualPhase == GameManagement.Phases.arena) {
					GUIDrawRect (new Rect (pos.x-LongueurBarreSante/2+4.0F*d,Screen.height/2-pos.y/2+2.0F*d, LongueurBarreSante-8.0F*d, 15-d), new Color (0.5f, 0.0f, 0.0f, 1.0f));
				}
			}
		//}
	}

	public static void GUIDrawRect( Rect position, Color color ) 
	{
		if( _staticRectTexture == null )
		{
			_staticRectTexture = new Texture2D( 1, 1 );
		}
		if( _staticRectStyle == null )
		{
			_staticRectStyle = new GUIStyle();
		}
		_staticRectTexture.SetPixel( 0, 0, color );
		_staticRectTexture.Apply();
		_staticRectStyle.normal.background = _staticRectTexture;
		GUI.Box( position, GUIContent.none, _staticRectStyle );
	}
	
	public void AjusterSanteActuelle(int adj) { 
		PV += adj; 
		
		if (PV < 0.0F) 
			PV = 0.0F; 
		
		if (PV > PVMAX) 
			PV = PVMAX; 
		
		if (PVMAX < 1.0F) 
			PVMAX = 1.0F; 

		degatAttente = 0;
		LongueurBarreSante = LongueurBarreSanteMAX * (PV / PVMAX); 
	}
}
