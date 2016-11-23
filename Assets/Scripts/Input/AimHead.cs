using DarkRift;
using UnityEngine;
using System.Collections;

public class AimHead : MonoBehaviour
{
    [SerializeField] private float headXMin, headXMax, headYMin, headYMax;

    private CameraController camCont;
    private bool aimHead;
    private Quaternion desiredRotation;
    private PokemonComponents components;

    void Awake()
    {
        components = transform.root.GetComponent<PokemonComponents>();
    }
    void Start()
    {
        DarkRiftAPI.onDataDetailed += ReceiveData;
        camCont = Camera.main.GetComponent<CameraController>();
    }
    void Update()
    {
        if(DarkRiftAPI.isConnected)
            DarkRiftAPI.Receive();
    }
    void LateUpdate()
    {
        if(!aimHead)
            return;

        if(components.pokemon.networkID == DarkRiftAPI.id)
        {
            desiredRotation = Quaternion.Euler(Camera.main.transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, 0.0f);

            if(transform.rotation != desiredRotation)
                DarkRiftAPI.SendMessageToOthers(TagIndex.PokemonUpdate, TagIndex.PokemonUpdateSubjects.AimHead, desiredRotation);

            transform.rotation = desiredRotation;

            return;
        }
        else
        {
            transform.rotation = desiredRotation;
        }
    }

    public void HeadAim(bool value)
    {
        if(value)
        {
            if(components.pokemon.networkID == DarkRiftAPI.id)
            {
                transform.root.rotation = Quaternion.Euler(0.0f, Camera.main.transform.eulerAngles.y, 0.0f);
                camCont.CameraAim(headXMin, headXMax, headYMin, headYMax);
            }

            aimHead = true;
        }
        else
        {
            aimHead = false;

            if(components.pokemon.networkID == DarkRiftAPI.id)
                camCont.CameraDefault();
        }
    }

    private void ReceiveData(ushort senderID, byte tag, ushort subject, object data)
    {
        if(senderID == components.pokemon.networkID)
            if(tag == TagIndex.PokemonUpdate)
                if(subject == TagIndex.PokemonUpdateSubjects.AimHead)
                    desiredRotation = (Quaternion)data;
    }
}