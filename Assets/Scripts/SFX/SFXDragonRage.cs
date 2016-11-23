using UnityEngine;
using System.Collections;

public class SFXDragonRage : MonoBehaviour
{
    [SerializeField] private float scaleSpeed = 0.5f;

    private Pokemon owner;
    private Vector3 scale;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.root.gameObject == owner.gameObject)
            return;

        if(collider.gameObject == owner.enemy.gameObject)
            Hit(collider.GetComponent<Pokemon>());

        //-------------Instantiate the explosion here.---------------------------------//
        Destroy(gameObject);
    }
	void Update()
	{
		if(scale != Vector3.zero)
		{
			float current = transform.localScale.sqrMagnitude;
			float target = scale.sqrMagnitude;
			
			if(current < target)
				transform.localScale = Vector3.Lerp(transform.localScale, scale, Time.deltaTime * scaleSpeed);
		}
	}

	public void AssignValues(Pokemon owner, Vector3 scale)
	{
		this.owner = owner;
		this.scale = scale;
	}

	private void Hit(Pokemon target)
	{
        if(!GameManager.instance.isServer)
            return;

		target.components.hpPP.AdjCurHP(-40, false);

        Networking.DamageMessage(owner, target, owner.GetComponent<DragonRage>(), 40, false);
	}
}
