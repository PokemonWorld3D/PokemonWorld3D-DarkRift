using UnityEngine;
using System.Collections;

public class TrainerInput : MonoBehaviour
{
    public bool throwing, returning;

    public struct CurrentInput
    {
        public Vector3 movement;
        public bool walk, jump, swapToPokemon;
    }

    public CurrentInput curInput { get; private set; }

    private float horizontal, vertical;
    private Vector3 forward, right;
    private bool walkInput, jumpInput, nextSlotInput, lastSlotInput, throwPokemonBallInput, swapToInput, returnInput, captureInput, targetInput;
    private TrainerComponents components;

    void Awake()
    {
        components = GetComponent<TrainerComponents>();
    }
    void Start()
    {
        curInput = new CurrentInput();
    }
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        forward = Camera.main.transform.TransformDirection(Vector3.forward);
        right = Camera.main.transform.TransformDirection(Vector3.right);
        walkInput = Input.GetButton("Walk");
        jumpInput = Input.GetButtonDown("Jump");
        nextSlotInput = Input.GetButtonDown("Next");
        lastSlotInput = Input.GetButtonDown("Last");
        throwPokemonBallInput = Input.GetButtonDown("Throw Pokemon Ball");
        swapToInput = Input.GetButtonDown("Swap To Pokemon");
        returnInput = Input.GetButtonDown("Pokemon Return");
        captureInput = Input.GetButtonDown("Capture");
        targetInput = Input.GetMouseButtonDown(0);

        curInput = new CurrentInput
        {
            movement = (horizontal * right + vertical * forward),
            walk = walkInput,
            jump = jumpInput,
            swapToPokemon = swapToInput
        };

        if(components.controller.TrainerControl)
        {
            if(nextSlotInput)
				components.trainer.NextSlot();

			if(lastSlotInput)
				components.trainer.LastSlot();

            if(!throwing && !returning && throwPokemonBallInput && !components.trainer.Pokemon)
            {
                components.controller.canMove = false;
                throwing = true;
                components.anim.ThrowPokemonBall(true);
            }

            if(swapToInput)
                components.controller.SwitchControl();

            if(targetInput)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if(Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
				{
					if(hit.transform.gameObject.CompareTag("Trainer") && hit.transform.gameObject != gameObject)
					{
						components.trainer.hud.DisplayOtherTrainerPanel(hit.transform.gameObject);
						components.trainer.hud.otherTrainerPanel.transform.position = Input.mousePosition;
					}
				}
			}

            if(!throwing && !returning && captureInput)
			{
				Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
				RaycastHit targetHit;

				if(Physics.Raycast(ray, out targetHit, 100.0f))
				{
                    throwing = true;
					components.trainer.Capture(targetHit.point);
					return;
				}
			}
				
			if(!returning && !throwing && returnInput && components.trainer.Pokemon != null)
			{
				components.trainer.RecallPokemon();
				return;
			}
        }
    }

    public void FinishedThrowing()
    {
        throwing = false;
        components.anim.ThrowPokemonBall(false);
        components.anim.ThrowEmptyBall(false);
        components.controller.canMove = true;
    }
    public void FinishedReturning()
    {
        returning = false;
        components.anim.Return(false);
        components.controller.canMove = true;
    }
}
