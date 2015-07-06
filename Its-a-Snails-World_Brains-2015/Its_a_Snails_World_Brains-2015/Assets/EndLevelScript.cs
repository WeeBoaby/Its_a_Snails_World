using UnityEngine;
using System.Collections;

public class EndLevelScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("hit the trigger");
		if (other.gameObject.tag == "Player")
		{
			Debug.Log("load a level");
			Application.LoadLevel(3);
		}
	}
}
