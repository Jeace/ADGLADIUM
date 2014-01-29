using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
	
	public GameManagement gameManager;
	public int force, agilite, vitalite, constitution, endurance, niveau, argent;
	public float PV, PVMAX, energie, energieMAX, poids_max, poids_actuel, degats_droite, degats_gauche, resistance_cont, resistance_tranch, balance, vitesse_depl, vitesse_atk, crit;
	public float LongueurBarreEndurance, LongueurBarreSante, LongueurBarreEnduranceMAX, LongueurBarreSanteMAX;
	private static Texture2D _staticRectTexture;
	private static GUIStyle _staticRectStyle;
	public float regenerationEndurance = 5.0f; 

	// Use this for initialization
	void Start () {
		LongueurBarreEnduranceMAX = Screen.width/3;
		LongueurBarreSanteMAX = Screen.width/3;
		gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManagement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.actualPhase == GameManagement.Phases.arena) {
			AjusterSanteActuelle (0.0f);
			AjusterEnduranceActuelle (regenerationEndurance);
		}
	}

	void OnGUI () { 
		if (gameManager.actualPhase == GameManagement.Phases.arena) {
				LongueurBarreEnduranceMAX = Screen.width / 5 + (1 / ((Screen.width / 2) - energieMAX));
				LongueurBarreSanteMAX = Screen.width / 5 + (1 / ((Screen.width / 2) - PVMAX));
				GUIDrawRect (new Rect (20, 20, LongueurBarreSanteMAX, 30), Color.black); 
				GUIDrawRect (new Rect (20, 60, LongueurBarreEnduranceMAX, 30), Color.black); 
				GUIDrawRect (new Rect (20, 20, LongueurBarreSante, 30), new Color (0.5f, 0.0f, 0.0f, 1.0f)); 
				GUIDrawRect (new Rect (20, 60, LongueurBarreEndurance, 30), new Color (0.0f, 0.5f, 0.0f, 1.0f)); 
		}
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

	public void RecalculateStats(){
		//recalcule les stats secondaires
	}

	public void Hurted(float damages){
		AjusterSanteActuelle (damages);
	}

	public void AjusterSanteActuelle(float adj) { 
		PV += adj; 
		
		if (PV < 0) 
			PV = 0; 
		
		if (PV > PVMAX) 
			PV = PVMAX; 
		
		if (PVMAX < 1) 
			PVMAX = 1; 
		
		LongueurBarreSante = LongueurBarreSanteMAX * (PV / (float)PVMAX); 
	}

	public void AjusterEnduranceActuelle (float adj){
		energie += adj; 

		if (energie < 0) 
			energie = 0; 
		
		if (energie > energieMAX) 
			energie = energieMAX; 
		
		if (energieMAX < 1) 
			energieMAX = 1; 
		
		LongueurBarreEndurance = LongueurBarreEnduranceMAX * (energie / (float)energieMAX); 
	}
}
