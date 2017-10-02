using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Sousaiman : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Quaternion q = InputTracking.GetLocalRotation (VRNode.CenterEye);
		transform.localRotation = Quaternion.Inverse (q);
	}
}
