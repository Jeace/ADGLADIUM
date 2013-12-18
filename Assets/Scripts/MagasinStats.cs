using UnityEngine;
using System.Collections;

public class MagasinStats : MonoBehaviour {
	
	public int bonus_force, bonus_agilite, bonus_vitalite, bonus_constitution, bonus_endurance, bonus_niveau, bonus_argent;
	private Stats player;
	public GameObject[] list_menu;
	public int selected = 0;
	public XInput inputer;
	private bool inputed = false;


	// Use this for initialization
	void Start () {
		inputer = GameObject.FindWithTag ("INPUTER").GetComponent<XInput>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
		Initialize_shop ();
	}
	
	// Update is called once per frame
	void Update () {
		while(list_menu [selected].GetComponent<MenuElement> ().selectionnable == false) {
			selected++;
		}
		list_menu[selected].GetComponent<TextMesh> ().color = new Color(0.5f, 0.5f, 0.5f);
		checkInput ();
		changeText ();
	}

	void changeText(){
		for (int p = 0; p<list_menu.Length; p++) {
			GameObject toUpdate = list_menu[p];
			switch(toUpdate.name){
			case "argentAchatStats":
				toUpdate.GetComponent<TextMesh>().text = "Argent disponible : "+player.argent+" ("+bonus_argent+")";
				break;
			case "niveauAchatStats":
				toUpdate.GetComponent<TextMesh>().text = "Niveau : "+player.niveau+" (+"+bonus_niveau+")";
				break;
			case "agiliteAchatStats":
				toUpdate.GetComponent<TextMesh>().text = "Agilite : "+player.agilite+" (+"+bonus_agilite+")";
				break;
			case "forceAchatStats":
				toUpdate.GetComponent<TextMesh>().text = "Force : "+player.force+" (+"+bonus_force+")";
				break;
			case "constitutionAchatStats":
				toUpdate.GetComponent<TextMesh>().text = "Constitution : "+player.constitution+" (+"+bonus_constitution+")";
				break;
			case "enduranceAchatStats":
				toUpdate.GetComponent<TextMesh>().text = "Endurance : "+player.endurance+" (+"+bonus_endurance+")";
				break;
			case "vitaliteAchatStats":
				toUpdate.GetComponent<TextMesh>().text = "Vitalite : "+player.vitalite+" (+"+bonus_vitalite+")";
				break;
			}
		}
	}
	
	void checkInput(){
		if (inputed == false) {
			if (inputer.UPPAD) {
				inputed = true;
				DownGradeSelected();
			} else if (inputer.DOWNPAD) {
				inputed = true;
				UpGradeSelected();
			} else if (inputer.LEFTPAD) {
				inputed = true;
				switch(list_menu [selected].name){
				case "agiliteAchatStats":
					downStat(ref bonus_agilite);
					break;
				case "forceAchatStats":
					downStat(ref bonus_force);
					break;
				case "constitutionAchatStats":
					downStat(ref bonus_constitution);
					break;
				case "enduranceAchatStats":
					downStat(ref bonus_endurance);
					break;
				case "vitaliteAchatStats":
					downStat(ref bonus_vitalite);
					break;
				}
			} else if (inputer.RIGHTPAD) {
				inputed = true;
				switch(list_menu [selected].name){
				case "agiliteAchatStats":
					higherStat(ref bonus_agilite);
					break;
				case "forceAchatStats":
					higherStat(ref bonus_force);
					break;
				case "constitutionAchatStats":
					higherStat(ref bonus_constitution);
					break;
				case "enduranceAchatStats":
					higherStat(ref bonus_endurance);
					break;
				case "vitaliteAchatStats":
					higherStat(ref bonus_vitalite);
					break;
				}
			}
		}else{
			if (inputer.UPPAD == false && inputer.DOWNPAD == false && inputer.LEFTPAD == false && inputer.RIGHTPAD == false){
				inputed = false;
			}
		}
	}

	void FreeInput(){
		inputed = false;
	}

	void DownGradeSelected(){
		if (selected >= 0) {
			list_menu[selected].GetComponent<TextMesh> ().color = new Color(1.0f, 1.0f, 1.0f);
			selected --;
			if(selected < 0){
				selected = list_menu.Length-1;
			}
			while (list_menu [selected].GetComponent<MenuElement> ().selectionnable == false) {
				selected--;
				if(selected < 0){
					selected = list_menu.Length-1;
				}
			}
			list_menu[selected].GetComponent<TextMesh> ().color = new Color(0.5f, 0.5f, 0.5f);
		}else{
			if(selected < 0){
				selected = list_menu.Length-1;
			}
		}
	}
	
	void UpGradeSelected(){
		if (selected < list_menu.Length) {
			list_menu[selected].GetComponent<TextMesh> ().color = new Color(1.0f, 1.0f, 1.0f);
			selected ++;
			if(selected >= list_menu.Length){
				selected = 0;
			}
			while (list_menu [selected].GetComponent<MenuElement> ().selectionnable == false) {
				selected++;
				if(selected >= list_menu.Length){
					selected = 0;
				}
			}
			list_menu[selected].GetComponent<TextMesh> ().color = new Color(0.5f, 0.5f, 0.5f);
		}else{
			if(selected >= list_menu.Length){
				selected = 0;
			}
		}
	}

	void Initialize_shop(){
		bonus_force = 0;
		bonus_agilite = 0;
		bonus_vitalite = 0;
		bonus_constitution = 0;
		bonus_endurance = 0;
		bonus_niveau = 0;
		bonus_argent = 0;

		float posY = 4.5f;
		for (int i=0; i<list_menu.Length; i++) {
			list_menu[i].transform.position = new Vector3(0, posY, 0);
			posY -= 1.5f;
		}
	}

	void higherStat(ref int stat){
		if (player.argent + bonus_argent >= (player.niveau + bonus_niveau) * 10) {
			stat ++;
			bonus_niveau ++;
			bonus_argent -= (player.niveau + bonus_niveau) * 10;
		}
	}
	
	void downStat(ref int stat){
		if (stat > 0) {
			bonus_argent += (player.niveau + bonus_niveau) * 10;
			bonus_niveau --;
			stat--;
		}
	}

	void validateStats(){
		player.force += bonus_force;
		player.agilite += bonus_agilite;
		player.vitalite += bonus_vitalite;
		player.constitution += bonus_constitution;
		player.endurance += bonus_endurance;
		player.niveau += bonus_niveau;
		player.argent += bonus_argent;
		player.RecalculateStats ();
	}
}
