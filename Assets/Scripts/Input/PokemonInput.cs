using UnityEngine;
using System.Collections;

public class PokemonInput : MonoBehaviour
{
    public struct CurrentInput
    {
        public Vector3 movement;
        public bool walk, jump, swapToTrainer, nextMove, lastMove, attack, target;
    }

    public CurrentInput curInput { get; private set; }

    private float horizontal, vertical;
    private Vector3 forward, right;
    private bool walkInput, jumpInput, nextMoveInput, lastMoveInput, attackInput, attacking = false, swapToInput, targetInput;
    private PokemonComponents components;

    void Awake()
    {
        components = GetComponent<PokemonComponents>();
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
        jumpInput = Input.GetButton("Jump");
        nextMoveInput = Input.GetButtonDown("Next");
        lastMoveInput = Input.GetButtonDown("Last");
        attackInput = Input.GetMouseButton(1);
        swapToInput = Input.GetButtonDown("Swap To Trainer");
        targetInput = Input.GetMouseButtonDown(0);

        curInput = new CurrentInput
        {
            movement = (horizontal * right + vertical * forward),
            walk = walkInput,
            jump = jumpInput,
            swapToTrainer = swapToInput,
            nextMove = nextMoveInput,
            lastMove = lastMoveInput,
            attack = attackInput,
            target = targetInput
        };

        if(!components.pokemon.Trainer.components.controller.TrainerControl)
        {
            if(nextMoveInput)
                components.pokemon.NextMove();

            if(lastMoveInput)
                components.pokemon.LastMove();

            if(attackInput && !attacking)
            {
                components.pokemon.Attack();
                attacking = true;
            }
            else if(!attackInput && attacking)
            {
                components.pokemon.EndAttack();
                attacking = false;
            }

            if(swapToInput)
                components.pokemon.Trainer.components.controller.SwitchControl();

            //if(currentInput.targetInput)
            //{
            //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //    RaycastHit hit;

            //    if(Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
            //    {
            //        if(hit.transform.gameObject.CompareTag("Pokemon") && hit.transform.gameObject != gameObject)
            //        {
            //            if(!hit.transform.gameObject.GetComponent<Pokemon>().isCaptured)
            //            {
            //                components.trainer.hud.DisplayWildPokemonPanel(hit.transform.gameObject);
            //                components.trainer.hud.wildPokemonPanel.transform.position = Input.mousePosition;
            //            }
            //        }
            //    }
            //}
        }
    }
}