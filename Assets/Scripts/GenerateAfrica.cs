using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;


public class GenerateAfrica : MonoBehaviour
{
	public GameObject prefabObject;
	// Distance in Meters
	public int distanceFromCamera = 1;
	private HashSet<string> m_Clones;


	private float m_TimeUntilRemove = 5.0f;

	void  Awake ()
	{
		UnityARSessionNativeInterface.ARUserAnchorAddedEvent += ExampleAddAnchor;
		UnityARSessionNativeInterface.ARUserAnchorRemovedEvent += AnchorRemoved;
		m_Clones = new HashSet<string> ();
	}

	public void ExampleAddAnchor (ARUserAnchor anchor)
	{
		if (m_Clones.Contains (anchor.identifier)) {
			Debug.Log ("Our anchor was added!");
		}
	}

	public void AnchorRemoved (ARUserAnchor anchor)
	{
		if (m_Clones.Contains (anchor.identifier)) {
			m_Clones.Remove (anchor.identifier);
			Debug.Log ("AnchorRemovedExample: " + anchor.identifier);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			GameObject clone = Instantiate (prefabObject, Camera.main.transform.position + (this.distanceFromCamera * Camera.main.transform.forward), Quaternion.identity);
			UnityARUserAnchorComponent component = clone.GetComponent<UnityARUserAnchorComponent> ();
			m_Clones.Add (component.AnchorId);
			m_TimeUntilRemove = 4.0f;
		}

		// just remove anchors afte a certain amount of time for example's sake.
		m_TimeUntilRemove -= Time.deltaTime;
		if (m_TimeUntilRemove <= 0.0f) {
			foreach (string id in m_Clones) {
				Debug.Log ("Removing anchor with id: " + id);
				UnityARSessionNativeInterface.GetARSessionNativeInterface ().RemoveUserAnchor (id);
				break;
			}
			m_TimeUntilRemove = 4.0f;
		}
	}
}
