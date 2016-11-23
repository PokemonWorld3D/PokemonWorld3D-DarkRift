using UnityEngine;
using System.Collections;

public class ReturnBall : MonoBehaviour
{
    public GameObject target = null;
    public LineRenderer lineRenderer;

    public AudioSource audioS { get; private set; }

	private Vector3 spot;
	
	void Awake()
	{
        audioS = GetComponent<AudioSource>();
		lineRenderer = GetComponentInChildren<LineRenderer>();
	}
	void Update()
	{
		if(target != null)
		{
			spot = target.GetComponentInChildren<SkinnedMeshRenderer>().bounds.center; 
			lineRenderer.SetPosition(0, lineRenderer.gameObject.transform.position);
			lineRenderer.SetPosition(1, spot);
		}
		if(target == null)
		{
			spot = Vector3.Lerp(spot, lineRenderer.gameObject.transform.position, Time.deltaTime * 5.0f);
			lineRenderer.SetPosition(0, lineRenderer.gameObject.transform.position);
			lineRenderer.SetPosition(1, spot);
		}
	}
}