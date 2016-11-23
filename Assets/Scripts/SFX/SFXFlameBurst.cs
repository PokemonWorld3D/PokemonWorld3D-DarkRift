using UnityEngine;
using System.Collections;

public class SFXFlameBurst : MonoBehaviour
{
	private Pokemon owner;

	void OnTriggerEnter(Collider collider)
	{
		if(collider.transform.root.gameObject == owner.gameObject)
			return;

		if(collider.transform.root.gameObject == owner.enemy.gameObject)
			Hit(collider.GetComponent<Pokemon>());

		//-------------Instantiate the explosion here.---------------------------------//
		Destroy(gameObject);
	}

    public void AssignOwner(Pokemon owner)
    {
        this.owner = owner;
    }

	private void Hit(Pokemon target)
	{
        if(!GameManager.instance.isServer)
            return;

		Calculations.DealDamage(owner, owner.enemy.GetComponent<Pokemon>(), owner.GetComponent<FlameBurst>());
	}
}