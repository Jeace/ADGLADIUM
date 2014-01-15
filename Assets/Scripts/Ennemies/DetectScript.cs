using UnityEngine;
using System.Text.RegularExpressions;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class DetectScript : MonoBehaviour {
	private GameObject cible;
	private GameObject joueur;
	private int rand=51;
	private CharacterController controller;
	private Vector3 vectEnnemie = Vector3.zero;
	private float speed = 6.0F;
	private float gravity = 20.0F;
	private bool isAttak = false;
	private int iteration=0;
	private SphereCollider tailleCol;
	private bool isAlea=true;

	void Start(){
		joueur=GameObject.FindGameObjectWithTag("Player");
		rand = (int)(Mathf.Round(Random.value*40)+10);
		controller = GetComponent<CharacterController>();
		tailleCol = GetComponent<SphereCollider> ();
		vectEnnemie = changeA ();
		vectEnnemie = transform.TransformDirection(vectEnnemie);
		vectEnnemie *= (0.3F*speed);
		vectEnnemie.y -= gravity * Time.deltaTime;
		controller.Move(vectEnnemie * Time.deltaTime);
	}
	
	void Update() {
		if(cible!=null){
			rand=51;
			vectEnnemie = change ();
			if(!isAlea){
				vectEnnemie = transform.TransformDirection(vectEnnemie);
				vectEnnemie *= speed;
				vectEnnemie.y -= gravity * Time.deltaTime;
				//controller.Move(vectEnnemie * Time.deltaTime);
			}
			isAlea=false;
		}
		else{
			Alea ();
		}
		if(rand>15){
			vectEnnemie.y -= gravity * Time.deltaTime;
			controller.Move(vectEnnemie * Time.deltaTime);
		}
		if(rand!=51){
			if(Mathf.Round(Random.value*50)>45)
				tailleCol.radius = tailleCol.radius+Mathf.Round(Random.value);
			float d;
			float x = joueur.transform.position.x - transform.position.x;
			float z = joueur.transform.position.z - transform.position.z;
			if(x<0.0F)
				d=-x;
			else
				d=x;
			if(z<0.0F)
				d=d-z;
			else
				d=d+z;
			if(tailleCol.radius>d){
				cible = joueur;
			}
		}
	}

	void OnTriggerEnter(Collider collision){
		if(collision.gameObject.Equals(GameObject.FindGameObjectWithTag("Player")))
			cible = collision.gameObject;
	}
/*
	void OnTriggerStay(Collider collision){
		if(collision.gameObject.Equals(cible)){
			cible = collision.gameObject;
			vectEnnemie = change ();
			vectEnnemie = transform.TransformDirection(vectEnnemie);
			vectEnnemie *= speed;
			vectEnnemie.y -= gravity * Time.deltaTime;
			controller.Move(vectEnnemie * Time.deltaTime);
		}
	}
*/
	Vector3 change(){
		int i=0,a=0;
		float d;
		float x = cible.transform.position.x - transform.position.x;
		float z = cible.transform.position.z - transform.position.z;
		if(x<0.0F)
			d=-x;
		else
			d=x;
		if(z<0.0F)
			d=d-z;
		else
			d=d+z;
		if(d<15.0F && d>=1.0F && !isAttak){
			GameObject[] list;
			list = GameObject.FindGameObjectsWithTag("ennemie");
			while(i<list.Length && a<2){
				if(list[i].GetComponent<DetectScript>().isAttaking())
					a++;
				i++;
			}
			if(a<2)
				isAttak = true;
			else{
				Alea ();
				isAlea = true;
				return changeA();
			}
		}
		if(!(d<1.0F && d>-1.0F) && ((d<15.0F && isAttak)||d>=15.0F))
			return new Vector3(x/d,0.0F,z/d);
		else
			return Vector3.zero;
	}

	Vector3 changeA(){
		float d;
		float x = Mathf.Round ((Random.value - 0.5F) * 2.0F);
		float z = Mathf.Round ((Random.value - 0.5F) * 2.0F);
		if(x<0.0F)
			d=-x-1;
		else
			d=x+1;
		if(z<0.0F)
			d=d-z-1;
		else
			d=d+z+1;
		if(d!=0)
			return new Vector3(x/d,0.0F,z/d);
		else
			return Vector3.zero;
	}

	void Alea(){
		iteration++;
		if(iteration==rand){
			iteration =0;
			rand = (int)(Mathf.Round(Random.value*40)+10);
			vectEnnemie = changeA ();
			vectEnnemie = transform.TransformDirection(vectEnnemie);
			vectEnnemie *= (0.3F*speed);
			vectEnnemie.y -= gravity * Time.deltaTime;
			//controller.Move(vectEnnemie * Time.deltaTime);
		}
	}
	
	bool isAttaking(){
		return isAttak;
	}
}