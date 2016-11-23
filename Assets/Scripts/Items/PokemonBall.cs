using DarkRift;
using UnityEngine;
using System.Collections;

public class PokemonBall : MonoBehaviour
{
    [SerializeField] private AudioClip pokemonOut;

    private bool spawning;
    private Trainer trainer;
    private Transform grip;
    private Animator anim;
    private Rigidbody rigidBody;
    private AudioSource audioS;
    private Collider col;

    void Awake()
    {
        trainer = transform.root.GetComponent<Trainer>();
        grip = transform.parent;
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        audioS = GetComponent<AudioSource>();
        col = GetComponent<Collider>();
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Terrain") && !spawning)
        {
            rigidBody.useGravity = false;
            rigidBody.velocity = Vector3.zero;
            rigidBody.Sleep();
            col.enabled = false;
            StartCoroutine(PokemonGo());
            spawning = true;
        }
    }

    
    private void ResetPokemonBall()
    {
        gameObject.SetActive(false);
        rigidBody.WakeUp();
        col.enabled = true;
        spawning = false;
        transform.SetParent(grip);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    private IEnumerator PokemonGo()
    {
        transform.LookAt(transform.forward);
        anim.SetBool("Open Top", true);
        audioS.PlayOneShot(pokemonOut);

        yield return new WaitForSeconds(1.0f);

        //SFX for Pokemon coming out of ball go here.

        if(trainer.networkID == DarkRiftAPI.id)
            Networking.SerialisePokemonData(trainer.PokemonRoster[trainer.SelectedRosterSlot], trainer.TrainersName, transform.position);

        anim.SetBool("Open Top", false);

        while (audioS.isPlaying)
            yield return null;

        ResetPokemonBall();
    }
}
