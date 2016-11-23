using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour
{
	[SerializeField] private Transform position;
    [SerializeField] private Transform target;

	void Update()
	{
		transform.position = position.position;
		transform.LookAt(target);
	}
}
