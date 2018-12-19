using UnityEngine;

public class Player : MonoBehaviour
{
	//Note that changing the values here will NOT change the values that have been
	//serialized on an existing instance of the component. These are just defaults
	//to stop the compiler complaining that they're never assigned.
	[SerializeField] private float speed = 4;
	[SerializeField] private float jumpImpulse = 5;
	[SerializeField] private float sensitivity = 200;

	private Vector3 velocity = Vector3.zero;

	private CharacterController controller;
	[SerializeField] private Transform cameraTransform = null;


	private void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		HandleCamera();
		HandleMovement();
	}

	private void HandleCamera()
	{
		var delta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		delta *= sensitivity;
		delta *= Time.deltaTime;

		float verticalLook = cameraTransform.localEulerAngles.x - delta.y;
		verticalLook = verticalLook.ClampAngle(-90, 90);
		cameraTransform.localEulerAngles = new Vector3(verticalLook, 0, 0);

		//Rotate the whole character controller transform for y axis rotation.
		transform.Rotate(Vector3.up, delta.x, Space.World);
	}

	//Stolen from Unity docs. Basic character controller isn't great in general, but it's fine for now.
	private void HandleMovement()
	{
        if(controller.isGrounded)
        {
            velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            velocity = transform.TransformDirection(velocity);
            velocity *= speed;

            if(Input.GetButton("Jump"))
            {
                velocity.y = jumpImpulse;
            }
        }
		
        velocity.y = velocity.y + (Physics.gravity.y * Time.deltaTime);

        controller.Move(velocity * Time.deltaTime);
	}
}