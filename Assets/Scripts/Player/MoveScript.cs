using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(ActionsScript))]
public class MoveScript : MonoBehaviour {
	
	public GameManagement gameManager;
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float rollingHeight = 8.0F;
	public float rollingSpeed = 8.0F;
	public float gravity = 20.0F;
	public float rotateSpeed = 3.0F;
	public float rollingCost = 500.0f;
	public float jumpingCost = 600.0f;
	public XInput inputer;
	public Stats statsManager;
	private Vector3 moveDirection = Vector3.zero;
	private Camera mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		inputer = GameObject.FindWithTag ("INPUTER").GetComponent<XInput>();
		gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManagement>();
		statsManager = gameObject.GetComponent<Stats> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.actualPhase == GameManagement.Phases.arena) {
			CharacterController controller = GetComponent<CharacterController> ();
			transform.Rotate (0, inputer.RJOYX * rotateSpeed, 0);
			mainCamera.transform.Rotate (-inputer.RJOYY * rotateSpeed, 0, 0);
			if (controller.isGrounded) {
					moveDirection = new Vector3 (inputer.LJOYX, 0, inputer.LJOYY);
					moveDirection = transform.TransformDirection (moveDirection);
					moveDirection *= speed;
					if (inputer.A) {
						if(statsManager.energie-jumpingCost >= 0){
							statsManager.AjusterEnduranceActuelle(-jumpingCost);
							moveDirection.y = jumpSpeed;
						}
					} else if (inputer.B) {
						if(statsManager.energie-rollingCost >= 0){
							statsManager.AjusterEnduranceActuelle(-rollingCost);
							moveDirection /= speed;
							moveDirection *= rollingSpeed;
							moveDirection.y = rollingHeight;
						}
					}
			}
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection * Time.deltaTime);
		}
	}
}