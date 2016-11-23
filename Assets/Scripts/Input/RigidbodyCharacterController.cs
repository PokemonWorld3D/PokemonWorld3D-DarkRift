using DarkRift;
using UnityEngine;
using System.Collections;

public class RigidbodyCharacterController : PW3DStateMachine
{
    public bool canMove;
    public Pokemon pokemon;

    public bool TrainerControl { get { return trainerControl; } }

    public enum States { IDLE, WALK, RUN, PRE_JUMP, JUMP, FALL }

    [SerializeField] private PokemonBall pokemonBall;
    [SerializeField] private AudioClip pokeBallGrow;
    [SerializeField] private float maxVelocityChange;

    private bool trainerControl;
    private Trainer trainer;
    private Vector3 targetVelocity, velocityChange, lookDirection;
    private Rigidbody pokemonBallRBody;

    void Awake()
    {
        trainer = GetComponent<Trainer>();
        pokemonBallRBody = pokemonBall.GetComponent<Rigidbody>();
    }
    void Start()
    {
        trainerControl = true;
        canMove = true;
        currentState = States.IDLE;
    }
    void FixedUpdate()
    {
        if(trainerControl)
        {
            if(lookDirection != Vector3.zero)
                trainer.components.rigidbody.rotation = Quaternion.LookRotation(lookDirection);

            velocityChange = targetVelocity - trainer.components.rigidbody.velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0.0f;
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            trainer.components.rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

            if(!PhysicsCalculations.IsGrounded(trainer.components.collider, 0.1f, trainer.colliderRadius))
                trainer.components.rigidbody.AddForce(new Vector3(0.0f, -trainer.gravity * trainer.components.rigidbody.mass, 0.0f));
        }
        else
        {
            if(lookDirection != Vector3.zero)
                pokemon.components.rigidbody.rotation = Quaternion.LookRotation(lookDirection);

            velocityChange = targetVelocity - pokemon.components.rigidbody.velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0.0f;
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            pokemon.components.rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

            if(!PhysicsCalculations.IsGrounded(pokemon.components.collider, 0.1f, pokemon.colliderRadius))
                pokemon.components.rigidbody.AddForce(new Vector3(0.0f, -pokemon.gravity * pokemon.components.rigidbody.mass, 0.0f));
        }
    }

    protected override void EarlyUpdate()
    {
        if(targetVelocity.x != 0.0f || targetVelocity.z != 0.0f)
        {
            lookDirection = targetVelocity;
            lookDirection.y = 0.0f;
        }
        else
            lookDirection = Vector3.zero;
    }

    void IDLEEnterState()
    {
        targetVelocity = Vector3.zero;
    }
    void IDLEUpdate()
    {
        if(trainerControl)
        {
            if(trainer.components.input.curInput.jump)
            {
                currentState = States.PRE_JUMP;
                return;
            }
            if(!PhysicsCalculations.IsGrounded(trainer.components.collider, 0.1f, trainer.colliderRadius))
            {
                currentState = States.FALL;
                return;
            }
            if(trainer.components.input.curInput.movement != Vector3.zero)
            {
                currentState = trainer.components.input.curInput.walk ? States.WALK : States.RUN;
                return;
            }
        }
        else
        {
            if(pokemon.components.input.curInput.jump && canMove)
            {
                currentState = States.PRE_JUMP;
                return;
            }
            if(!PhysicsCalculations.IsGrounded(pokemon.components.collider, 0.1f, pokemon.colliderRadius))
            {
                currentState = States.FALL;
                return;
            }
            if(pokemon.components.input.curInput.movement != Vector3.zero && canMove)
            {
                currentState = pokemon.components.input.curInput.walk ? States.WALK : States.RUN;
                return;
            }
        }
    }

    void WALKEnterState()
    {
        if(trainerControl)
            trainer.components.anim.Walk();
        else
            pokemon.components.anim.Walk();
    }
    void WALKUpdate()
    {
        if(trainerControl)
        {
            if(trainer.components.input.curInput.jump)
            {
                currentState = States.PRE_JUMP;
                return;
            }
            if(!PhysicsCalculations.IsGrounded(trainer.components.collider, 0.1f, trainer.colliderRadius))
            {
                currentState = States.FALL;
                return;
            }
            if(trainer.components.input.curInput.movement != Vector3.zero)
            {
                if(!trainer.components.input.curInput.walk)
                {
                    currentState = States.RUN;
                    return;
                }

                targetVelocity = trainer.components.input.curInput.movement * trainer.walkSpeed;
            }
            else
            {
                currentState = States.IDLE;
                return;
            }
        }
        else
        {
            if(!canMove)
            {
                currentState = States.IDLE;
                return;
            }
            if(pokemon.components.input.curInput.jump)
            {
                currentState = States.PRE_JUMP;
                return;
            }
            if(!PhysicsCalculations.IsGrounded(pokemon.components.collider, 0.1f, pokemon.colliderRadius))
            {
                currentState = States.FALL;
                return;
            }
            if(pokemon.components.input.curInput.movement != Vector3.zero)
            {
                if(!pokemon.components.input.curInput.walk)
                {
                    currentState = States.RUN;
                    return;
                }

                targetVelocity = pokemon.components.input.curInput.movement * pokemon.CurWalkSpeed;
            }
            else
            {
                currentState = States.IDLE;
                return;
            }
        }
    }
    void WALKExitState()
    {
        if(trainerControl)
            trainer.components.anim.Stop();
        else
            pokemon.components.anim.Stop();
    }

    void RUNEnterState()
    {
        if(trainerControl)
            trainer.components.anim.Run();
        else
            pokemon.components.anim.Run();
    }
    void RUNUpdate()
    {
        if(trainerControl)
        {
            if(trainer.components.input.curInput.walk)
            {
                currentState = States.WALK;
                return;
            }
            if(trainer.components.input.curInput.jump)
            {
                currentState = States.PRE_JUMP;
                return;
            }
            if(!PhysicsCalculations.IsGrounded(trainer.components.collider, 0.1f, trainer.colliderRadius))
            {
                currentState = States.FALL;
                return;
            }
            if(trainer.components.input.curInput.movement != Vector3.zero)
            {
                targetVelocity = trainer.components.input.curInput.movement * trainer.walkSpeed * trainer.runMultiplier;
            }
            else
            {
                currentState = States.IDLE;
                return;
            }
        }
        else
        {
            if(!canMove)
            {
                currentState = States.IDLE;
                return;
            }
            if(pokemon.components.input.curInput.walk)
            {
                currentState = States.WALK;
                return;
            }
            if(pokemon.components.input.curInput.jump)
            {
                currentState = States.PRE_JUMP;
                return;
            }
            if(!PhysicsCalculations.IsGrounded(pokemon.components.collider, 0.1f, pokemon.colliderRadius))
            {
                currentState = States.FALL;
                return;
            }
            if(pokemon.components.input.curInput.movement != Vector3.zero)
            {
                targetVelocity = pokemon.components.input.curInput.movement * pokemon.CurWalkSpeed * pokemon.runMultiplier;
            }
            else
            {
                currentState = States.IDLE;
                return;
            }
        }
    }
    void RUNExitState()
    {
        if(trainerControl)
            trainer.components.anim.Stop();
        else
            pokemon.components.anim.Stop();
    }

    void PRE_JUMPEnterState()
    {
        if(trainerControl)
            trainer.components.anim.Jump(true);
        else
            pokemon.components.anim.Jump(true);
    }
    void JUMPEnterState()
    {
        if(trainerControl)
        {
            trainer.components.rigidbody.velocity = new Vector3(trainer.components.rigidbody.velocity.x, PhysicsCalculations.CalculateJumpSpeed(trainer.jumpHeight, trainer.gravity),
                trainer.components.rigidbody.velocity.z);
        }
        else
        {
            pokemon.components.rigidbody.velocity = new Vector3(pokemon.components.rigidbody.velocity.x, PhysicsCalculations.CalculateJumpSpeed(pokemon.CurJumpHeight, pokemon.gravity),
                pokemon.components.rigidbody.velocity.z);
        }
    }
    void JUMPUpdate()
    {
        if(trainerControl)
        {
            if(PhysicsCalculations.IsGrounded(trainer.components.collider, 0.1f, trainer.colliderRadius))
            {
                trainer.components.anim.Jump(false);
                currentState = States.IDLE;
                return;
            }
        }
        else
        {
            if(PhysicsCalculations.IsGrounded(pokemon.components.collider, 0.1f, pokemon.colliderRadius))
            {
                pokemon.components.anim.Jump(false);
                currentState = States.IDLE;
                return;
            }
        }
    }

    void FALLUpdate()
    {
        if(trainerControl)
        {
            if(PhysicsCalculations.IsGrounded(trainer.components.collider, 0.1f, trainer.colliderRadius))
            {
                currentState = States.IDLE;
                return;
            }
        }
        else
        {
            if(PhysicsCalculations.IsGrounded(pokemon.components.collider, 0.1f, pokemon.colliderRadius))
            {
                pokemon.components.anim.Land();
                currentState = States.IDLE;
                return;
            }
        }
    }

    public void JumpTransition()
    {
        currentState = States.JUMP;
    }
    public void CreatePokemonBall()
    {
        trainer.components.audioS.PlayOneShot(pokeBallGrow);
        pokemonBall.gameObject.SetActive(true);
    }
    public void ReleasePokemonBall()
    {
        Vector3 targetPos = transform.position + (transform.forward * 5.0f);
        Vector3 throwSpeed = PhysicsCalculations.CalculateBestThrowSpeed(pokemonBall.transform.position, targetPos, 1.0f);

        pokemonBall.transform.parent = null;
        pokemonBallRBody.AddForce(throwSpeed, ForceMode.Impulse);
        pokemonBallRBody.useGravity = true;
    }
    public void SwitchControl()
    {
        if(trainer.Pokemon == null)
            return;

        if(trainerControl)
        {
            currentState = States.IDLE;
            trainerControl = false;
            Camera.main.SendMessage("SetTarget", pokemon.components.cameraFocus);
            pokemon.components.audioL.enabled = true;
            trainer.components.audioL.enabled = false;
        }
        else if(!trainerControl && canMove)
        {
            currentState = States.IDLE;
            trainerControl = true;
            Camera.main.SendMessage("SetTarget", trainer.components.cameraFocus);
            trainer.components.audioL.enabled = true;
            pokemon.components.audioL.enabled = false;
        }
    }
}