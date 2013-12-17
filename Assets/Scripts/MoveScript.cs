using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(ActionsScript))]
public class MoveScript : MonoBehaviour {
	
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float rollingHeight = 3.0F;
	public float rollingSpeed = 8.0F;
	public float gravity = 20.0F;
	public float rotateSpeed = 3.0F;
	public XInput inputer;
	private Vector3 moveDirection = Vector3.zero;
	private Camera mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		inputer = GameObject.FindWithTag ("INPUTER").GetComponent<XInput>();
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		transform.Rotate(0, inputer.RJOYX * rotateSpeed, 0);
		mainCamera.transform.Rotate(-inputer.RJOYY * rotateSpeed, 0, 0);
		if (controller.isGrounded) {
			moveDirection = new Vector3 (inputer.LJOYX, 0, inputer.LJOYY);
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if (inputer.A) {
					moveDirection.y = jumpSpeed;
			}else if(inputer.B){
				moveDirection /= speed;
				moveDirection *= rollingSpeed;
				moveDirection.y = rollingHeight;
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}