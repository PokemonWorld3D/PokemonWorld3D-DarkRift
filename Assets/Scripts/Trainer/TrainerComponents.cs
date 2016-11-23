using UnityEngine;
using System.Collections;

public class TrainerComponents : MonoBehaviour
{
    public Trainer trainer { get; private set; }
    public TrainerInput input { get; private set; }
    public TrainerAnimatorController anim { get; private set; }
    public AudioSource audioS { get; private set; }
    public Transform cameraFocus { get; private set; }
    public AudioListener audioL { get; private set; }
    public new Rigidbody rigidbody { get; private set; }
    public new Collider collider { get; private set; }
    public RigidbodyCharacterController controller { get; private set; }
    public Animator animator { get; private set; }

    void Awake()
    {
        trainer = GetComponent<Trainer>();
        input = GetComponent<TrainerInput>();
        controller = GetComponent<RigidbodyCharacterController>();
        anim = GetComponent<TrainerAnimatorController>();
        audioS = GetComponent<AudioSource>();
        cameraFocus = transform.FindChild("Camera Focus");
        audioL = GetComponent<AudioListener>();
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
    }
}
