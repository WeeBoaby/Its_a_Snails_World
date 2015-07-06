using UnityEngine;
using System.Collections;

public class CoordScript : MonoBehaviour {

	public Vector2 v2Coord;
	public Vector3 v3Coord;
	public float timepersqr = 1.0f;

	// Use this for initialization
	void Start () 
	{
		v3Coord = this.gameObject.transform.position;
	}

	public void MoveLilyPad(Vector2[] inArray)
	{
		if(inArray[0].x == v2Coord.x && inArray[0].y == v2Coord.y)
		{
			Debug.Log("entered the movement if statement");
			Debug.Log("first lily hit: " + inArray[0]);
			Debug.Log("target coord: " + inArray[1]);
			Debug.Log ("my coord is: " + v2Coord);

			StartCoroutine(moveToCoroutine(GetPosition(inArray[1])));

			v2Coord.x = inArray[1].x;
			v2Coord.y = inArray[1].y;
		}
	}

	public IEnumerator moveToCoroutine(Vector3 target)
	{
		Debug.Log ("entered the move coroutine");
		Vector3 startposition = this.gameObject.transform.position;

		float totalTime = (target - startposition).magnitude * timepersqr;

		float currentTime = 0;
		while (currentTime < totalTime)
			
		{
			currentTime += Time.deltaTime;
			this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, target, currentTime/totalTime);

			yield return 0;
			
		}
		
		this.gameObject.transform.position = target;
	}


	Vector3 GetPosition(Vector2 vecIn)
	{
		Vector3 returnVec = new Vector3(0, 0, 0);
		
		if (vecIn == new Vector2(1,1))
		{
			//input the positions in these
			returnVec = new Vector3(1, 0, -4);
		}
		else if (vecIn == new Vector2(1, 2))
		{
			//input the positions in these
			returnVec = new Vector3(1, 0, -3);
		}
		else if (vecIn == new Vector2(1, 3))
		{
			//input the positions in these
			returnVec = new Vector3(1, 0, -2);
		}
		else if (vecIn == new Vector2(1, 4))
		{
			//input the positions in these
			returnVec = new Vector3(1, 0, -1);
		}
		else if (vecIn == new Vector2(1, 5))
		{
			//input the positions in these
			returnVec = new Vector3(1, 0, 0);
		}
		else if (vecIn == new Vector2(2, 1))
		{
			//input the positions in these
			returnVec = new Vector3(2, 0, -4);
		}
		else if (vecIn == new Vector2(2, 2))
		{
			//input the positions in these
			returnVec = new Vector3(2, 0, -3);
		}
		else if (vecIn == new Vector2(2, 3))
		{
			//input the positions in these
			returnVec = new Vector3(2, 0, -2);
		}
		else if (vecIn == new Vector2(2, 4))
		{
			//input the positions in these
			returnVec = new Vector3(2, 0, -1);
		}
		else if (vecIn == new Vector2(2, 5))
		{
			//input the positions in these
			returnVec = new Vector3(2, 0, -0);
		}
		else if (vecIn == new Vector2(3, 1))
		{
			//input the positions in these
			returnVec = new Vector3(3, 0, -4);
		}
		else if (vecIn == new Vector2(3, 2))
		{
			//input the positions in these
			returnVec = new Vector3(3, 0, -3);
		}
		else if (vecIn == new Vector2(3, 3))
		{
			//input the positions in these
			returnVec = new Vector3(3, 0, -2);
		}
		else if (vecIn == new Vector2(3, 4))
		{
			//input the positions in these
			returnVec = new Vector3(3, 0, -1);
		}
		else if (vecIn == new Vector2(3, 5))
		{
			//input the positions in these
			returnVec = new Vector3(3, 0, 0);
		}
		else if (vecIn == new Vector2(4, 1))
		{
			//input the positions in these
			returnVec = new Vector3(4, 0, -4);
		}
		else if (vecIn == new Vector2(4, 2))
		{
			//input the positions in these
			returnVec = new Vector3(4, 0, -3);
		}
		else if (vecIn == new Vector2(4, 3))
		{
			//input the positions in these
			returnVec = new Vector3(4, 0, -2);
		}
		else if (vecIn == new Vector2(4, 4))
		{
			//input the positions in these
			returnVec = new Vector3(4, 0, -1);
		}
		else if (vecIn == new Vector2(4, 5))
		{
			//input the positions in these
			returnVec = new Vector3(4, 0, 0);
		}
		else if (vecIn == new Vector2(5, 1))
		{
			//input the positions in these
			returnVec = new Vector3(5, 0, -4);
		}
		else if (vecIn == new Vector2(5, 2))
		{
			//input the positions in these
			returnVec = new Vector3(5, 0, -3);
		}
		else if (vecIn == new Vector2(5, 3))
		{
			//input the positions in these
			returnVec = new Vector3(5, 0, -2);
		}
		else if (vecIn == new Vector2(5, 4))
		{
			//input the positions in these
			returnVec = new Vector3(5, 0, -1);
		}
		else if (vecIn == new Vector2(5, 5))
		{
			//input the positions in these
			returnVec = new Vector3(5, 0, 0);
		}
		
		return returnVec;
	}
}
