using UnityEngine;
using System.Collections;

public class FlameBurst : Move
{
	public GameObject prefab;
	public Transform mouth;
	public float speed = 5.0f, lifetime = 5.0f;

	private Vector3 target;

	public FlameBurst()
	{
		ResetMoveData("Flame Burst", "The user attacks the target with a bursting flame. The bursting flame damages Pokémon near the target as well.", false, false, false, false,
			false, PokemonTypes.FIRE, MoveCategories.SPECIAL, 0.0f, 70);
	}
	public void FlameBurstStart()
	{
        ResetMoveValues();

		Ray ray = new Ray(mouth.position, mouth.forward);
		RaycastHit[] Hits;

		Hits = Physics.RaycastAll(ray, Mathf.Infinity);
		for(int i = 0; i < Hits.Length; i++)
		{
			if(Hits[i].transform.gameObject != gameObject)
			{
				target = Hits[i].point;
				break;
			}
		}

		GameObject flameBurst = Instantiate(prefab, mouth.position, mouth.rotation) as GameObject;

        flameBurst.GetComponent<SFXFlameBurst>().AssignOwner(components.pokemon);

        Rigidbody rBody = flameBurst.GetComponent<Rigidbody>();
		Vector3 dir = target - mouth.position;

        rBody.velocity = dir * speed;
		Destroy(flameBurst, lifetime);
	}
}