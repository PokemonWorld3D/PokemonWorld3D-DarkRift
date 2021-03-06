using UnityEngine;
using System.Collections;

public class DragonRage : Move
{
	public GameObject prefab;
	public Transform mouth;
	public float speed = 1.0f, lifetime = 5.0f;
	public Vector3 scale;

	private Vector3 target;
	
	public DragonRage()
	{
		ResetMoveData("Dragon Rage", "This attack hits the target with a shock wave of pure rage. This attack always inflicts 40 HP damage.", false, false, false, false, false,
			PokemonTypes.DRAGON, MoveCategories.SPECIAL, 0.0f, 0); 
	}
	public void DragonRageStart()
	{
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

		GameObject dragonRage = Instantiate(prefab, mouth.position, mouth.rotation) as GameObject;
		dragonRage.GetComponent<SFXDragonRage>().AssignValues(components.pokemon, scale);

        Rigidbody rBody = dragonRage.GetComponent<Rigidbody>();
		Vector3 dir = target - mouth.position;

        rBody.velocity = dir * speed;
		Destroy(dragonRage, lifetime);
	}

}
