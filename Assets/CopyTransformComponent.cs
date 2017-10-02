using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyTransformComponent : MonoBehaviour
{
	public GameObject from;
	public GameObject to;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		to.transform.position = -from.transform.position;
	}
}
