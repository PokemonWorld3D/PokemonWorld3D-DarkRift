using DarkRift;
using UnityEngine;
using System.Collections;

public class DarkRiftReceiver : MonoBehaviour
{
	
	void Update()
    {
		if(DarkRiftAPI.isConnected)
			DarkRiftAPI.Receive();
	}
}
