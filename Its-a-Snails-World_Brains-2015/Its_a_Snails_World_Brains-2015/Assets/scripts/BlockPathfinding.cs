using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockPathfinding : MonoBehaviour 
{
	public static int[,] numbers = new int[7,7]; // row and col 0 and 6 are for the gates! (gate 0 means closed 1 means open) others are tileIDs
	public Vector2 movingLily, targetCoord;
	public int lilysHit = 0;
	public ConnectionMatrix snailPathfinder;

	// Use this for initialization
	void Start () 
	{
		initialisation2 ();
		PrintGrid ();
		Debug.Log ("initialisation2");
	}

	public static void initialisation2()
	{
		// this is the initial layout (where a path exists already and player just has to check path)
		
		numbers[0, 0] = 0; //bottom left corner
		numbers[0, 1] = 0; //gate
		numbers[0, 2] = 0; //gate
		numbers[0, 3] = 0; //gate
		numbers[0, 4] = 0; //gate
		numbers[0, 5] = 0; //gate
		numbers[0, 6] = 0; //top left corner
		
		numbers[1, 0] = 0; //gate
		numbers[1, 1] = 0; //lilypad
		numbers[1, 2] = 1; //water
		numbers[1, 3] = 0; //water
		numbers[1, 4] = 1; //water
		numbers[1, 5] = 0; //water
		numbers[1, 6] = 0; //gate
		
		numbers[2, 0] = 0; //gate
		numbers[2, 1] = 0; //lilypad
		numbers[2, 2] = 0; //water
		numbers[2, 3] = 1; //water
		numbers[2, 4] = 0; //water
		numbers[2, 5] = 1; //water
		numbers[2, 6] = 0; //gate
		
		numbers[3, 0] = 0; //gate
		numbers[3, 1] = 1; //lilypad
		numbers[3, 2] = 1; //water
		numbers[3, 3] = 0; //water
		numbers[3, 4] = 0; //water
		numbers[3, 5] = 1; //water
		numbers[3, 6] = 0; //gate
		
		numbers[4, 0] = 0; //gate
		numbers[4, 1] = 0; //lilypad
		numbers[4, 2] = 0; //water
		numbers[4, 3] = 0; //water
		numbers[4, 4] = 1; //water
		numbers[4, 5] = 0; //water
		numbers[4, 6] = 0; //gate
		
		numbers[5, 0] = 0; //gate
		numbers[5, 1] = 0; //lilypad
		numbers[5, 2] = 1; //lilypad
		numbers[5, 3] = 0; //lilypad
		numbers[5, 4] = 0; //lilypad
		numbers[5, 5] = 0; //lilypad
		numbers[5, 6] = 0; //gate
		
		numbers[6, 0] = 0; //bottom right corner
		numbers[6, 1] = 0; //gate
		numbers[6, 2] = 0; //gate
		numbers[6, 3] = 0; //gate
		numbers[6, 4] = 0; //gate
		numbers[6, 5] = 0; //gate
		numbers[6, 6] = 0; //top right corner
	}

	public static void initialisation()
	{
		// this is the initial layout (where a path exists already and player just has to check path)
		
		numbers[0, 0] = 0; //bottom left corner
		numbers[0, 1] = 0; //gate
		numbers[0, 2] = 0; //gate
		numbers[0, 3] = 0; //gate
		numbers[0, 4] = 0; //gate
		numbers[0, 5] = 0; //gate
		numbers[0, 6] = 0; //top left corner
		
		numbers[1, 0] = 0; //gate
		numbers[1, 1] = 1; //lilypad
		numbers[1, 2] = 0; //water
		numbers[1, 3] = 0; //water
		numbers[1, 4] = 0; //water
		numbers[1, 5] = 0; //water
		numbers[1, 6] = 0; //gate
		
		numbers[2, 0] = 0; //gate
		numbers[2, 1] = 1; //lilypad
		numbers[2, 2] = 0; //water
		numbers[2, 3] = 0; //water
		numbers[2, 4] = 0; //water
		numbers[2, 5] = 0; //water
		numbers[2, 6] = 0; //gate
		
		numbers[3, 0] = 0; //gate
		numbers[3, 1] = 1; //lilypad
		numbers[3, 2] = 0; //water
		numbers[3, 3] = 0; //water
		numbers[3, 4] = 0; //water
		numbers[3, 5] = 0; //water
		numbers[3, 6] = 0; //gate
		
		numbers[4, 0] = 0; //gate
		numbers[4, 1] = 1; //lilypad
		numbers[4, 2] = 0; //water
		numbers[4, 3] = 0; //water
		numbers[4, 4] = 0; //water
		numbers[4, 5] = 0; //water
		numbers[4, 6] = 0; //gate
		
		numbers[5, 0] = 0; //gate
		numbers[5, 1] = 1; //lilypad
		numbers[5, 2] = 1; //lilypad
		numbers[5, 3] = 1; //lilypad
		numbers[5, 4] = 1; //lilypad
		numbers[5, 5] = 1; //lilypad
		numbers[5, 6] = 0; //gate
		
		numbers[6, 0] = 0; //bottom right corner
		numbers[6, 1] = 0; //gate
		numbers[6, 2] = 0; //gate
		numbers[6, 3] = 0; //gate
		numbers[6, 4] = 0; //gate
		numbers[6, 5] = 0; //gate
		numbers[6, 6] = 0; //top right corner
	}


	void PrintGrid()
	{
		Debug.Log ("starting to print grid");
		Debug.Log("Col:    " + " " + "0" + " " + "1" + " " + "2" + " " + "3" + " " + "4" + " " + "5" + " " + "6");
		Debug.Log("Row:6:" + " " + numbers[0, 6] + " " + numbers[1, 6] + " " + numbers[2, 6] + " " + numbers[3, 6] + " " + numbers[4, 6] + " " + numbers[5, 6] + " " + numbers[6, 6]);
		Debug.Log("Row:5:" + " " + numbers[0, 5] + " " + numbers[1, 5] + " " + numbers[2, 5] + " " + numbers[3, 5] + " " + numbers[4, 5] + " " + numbers[5, 5] + " " + numbers[6, 5]);
		Debug.Log("Row:4:" + " " + numbers[0, 4] + " " + numbers[1, 4] + " " + numbers[2, 4] + " " + numbers[3, 4] + " " + numbers[4, 4] + " " + numbers[5, 4] + " " + numbers[6, 4]);
		Debug.Log("Row:3:" + " " + numbers[0, 3] + " " + numbers[1, 3] + " " + numbers[2, 3] + " " + numbers[3, 3] + " " + numbers[4, 3] + " " + numbers[5, 3] + " " + numbers[6, 3]);
		Debug.Log("Row:2:" + " " + numbers[0, 2] + " " + numbers[1, 2] + " " + numbers[2, 2] + " " + numbers[3, 2] + " " + numbers[4, 2] + " " + numbers[5, 2] + " " + numbers[6, 2]);
		Debug.Log("Row:1:" + " " + numbers[0, 1] + " " + numbers[1, 1] + " " + numbers[2, 1] + " " + numbers[3, 1] + " " + numbers[4, 1] + " " + numbers[5, 1] + " " + numbers[6, 1]);
		Debug.Log("Row:0:" + " " + numbers[0, 0] + " " + numbers[1, 0] + " " + numbers[2, 0] + " " + numbers[3, 0] + " " + numbers[4, 0] + " " + numbers[5, 0] + " " + numbers[6, 0]);
		Debug.Log("Col:    " + " " + "0" + " " + "1" + " " + "2" + " " + "3" + " " + "4" + " " + "5" + " " + "6");
		Debug.Log ("ending grid");
	}

	List<Vector2> FindPath(int startX, int startY, string direction)
	{
		List<Vector2> search = new List<Vector2>();
		lilysHit = 0;
		Vector2 start = new Vector2(startX, startY);
		movingLily = new Vector2 ();
		targetCoord = new Vector2 ();

		if (direction == "up")
		{
			if (numbers[startX, startY + 1].Equals(1))
			{
				//has hit a block at first  check, store hit and check how far it will move
				Debug.Log("hit lily, now checking how far it can move");
				lilysHit++;
				movingLily = new Vector2(startX, startY + 1);
			}
			else
				Debug.Log("did not hit a lily on first check");

			search.Add(start);
			search.Add(new Vector2(startX, startY + 1));
		}

		if (direction == "down")
		{
			if (numbers[startX, startY - 1].Equals(1))
			{
				//has hit a block at first  check, store hit and check how far it will move
				Debug.Log("hit lily, now checking how far it can move");
				lilysHit++;
				movingLily = new Vector2(startX, startY - 1);
			}
			else
				Debug.Log("did not hit a lily on first check");
			
			search.Add(start);
			search.Add(new Vector2(startX, startY - 1));
		}

		if (direction == "left")
		{
			if (numbers[startX - 1, startY].Equals(1))
			{
				//has hit a block at first  check, store hit and check how far it will move
				Debug.Log("hit lily, now checking how far it can move");
				lilysHit++;
				movingLily = new Vector2(startX - 1, startY);
			}
			else
				Debug.Log("did not hit a lily on first check");
			
			search.Add(start);
			search.Add(new Vector2(startX - 1, startY));
		}

		if (direction == "right")
		{
			if (numbers[startX + 1, startY].Equals(1))
			{
				//has hit a block at first  check, store hit and check how far it will move
				Debug.Log("hit lily, now checking how far it can move");
				lilysHit++;
				movingLily = new Vector2(startX + 1, startY);
			}
			else
				Debug.Log("did not hit a lily on first check");
			
			search.Add(start);
			search.Add(new Vector2(startX + 1, startY));
		}

		List<Vector2> result = DFSSearch (search, direction); //will always search at least one more block so no need for .count ifs!
		if (lilysHit > 1)
		{
			return result;
		}

		//temp return
		List<Vector2> returner = new List<Vector2>();
		return returner;
	}

	List<Vector2>DFSSearch(List<Vector2> listIn, string direction)
	{
		
		List<Vector2> returner = new List<Vector2>();
		foreach (Vector2 vec in listIn)
		{
			//Debug.Log("coords:" + vec.x + "  " + vec.y);
		}
		
		Vector2 currVec = listIn[listIn.Count - 1];
		int currx = (int)currVec.x;
		int curry = (int)currVec.y;
		Debug.Log(currVec.x + "   " + currVec.y + "   " + "current vecs");
		
		if (lilysHit > 1)
		{
			Debug.Log("hit second lily pad, returning list");
			return listIn;
		}

		if (direction == "up")
		{
			if (curry + 1 == 6)
			{
				// found the top of the screen

				if (lilysHit == 0)
					Debug.Log("no lilys found in search, nothing to move");
				else if (lilysHit == 1)
					targetCoord = new Vector2(currx, curry);

				return listIn;
			}

			if (numbers[currx, curry + 1].Equals(1))
			{
				lilysHit++;

				if (lilysHit == 1)
				{
					movingLily = new Vector2(currx, curry + 1);
				}
				else if (lilysHit == 2)
				{
					targetCoord = new Vector2(currx, curry);
				}
			}

			List<Vector2> passedInList = new List<Vector2>();
			passedInList = listIn;
			
			bool addToList = CheckIfContains(passedInList, new Vector2(currVec.x, currVec.y + 1));
			if (!addToList)
			{
				passedInList.Add(new Vector2(currVec.x, currVec.y + 1));
				
				List<Vector2> result = DFSSearch(passedInList, direction);
				if (lilysHit > 1)
				{
					return result;
				}
			}
			else 
			{
				Debug.Log("terminating search, no path here");
			}
		}

		if (direction == "down")
		{
			if (curry - 1 == 0)
			{
				// found the top of the screen
				
				if (lilysHit == 0)
					Debug.Log("no lilys found in search, nothing to move");
				else if (lilysHit == 1)
					targetCoord = new Vector2(currx, curry);
				
				return listIn;
			}

			if (numbers[currx, curry - 1].Equals(1))
			{
				lilysHit++;
				
				if (lilysHit == 1)
				{
					movingLily = new Vector2(currx, curry - 1);
				}
				else if (lilysHit == 2)
				{
					targetCoord = new Vector2(currx, curry);
				}
			}
			
			List<Vector2> passedInList = new List<Vector2>();
			passedInList = listIn;
			
			bool addToList = CheckIfContains(passedInList, new Vector2(currVec.x, currVec.y - 1));
			if (!addToList)
			{
				passedInList.Add(new Vector2(currVec.x, currVec.y - 1));
				
				List<Vector2> result = DFSSearch(passedInList, direction);
				if (lilysHit > 1)
				{
					return result;
				}
			}
			else 
			{
				Debug.Log("terminating search, no path here");
			}
		}

		if (direction == "left")
		{
			if (currx - 1 == 0)
			{
				// found the top of the screen
				
				if (lilysHit == 0)
					Debug.Log("no lilys found in search, nothing to move");
				else if (lilysHit == 1)
				{
					targetCoord = new Vector2(currx, curry);
					Debug.Log("only hit one, last space is target");
				}
				
				return listIn;
			}

			if (numbers[currx - 1, curry].Equals(1))
			{
				lilysHit++;
				
				if (lilysHit == 1)
				{
					movingLily = new Vector2(currx - 1, curry);
				}
				else if (lilysHit == 2)
				{
					targetCoord = new Vector2(currx, curry);
				}
			}
			
			List<Vector2> passedInList = new List<Vector2>();
			passedInList = listIn;
			
			bool addToList = CheckIfContains(passedInList, new Vector2(currVec.x - 1, currVec.y));
			if (!addToList)
			{
				passedInList.Add(new Vector2(currVec.x - 1, currVec.y));
				
				List<Vector2> result = DFSSearch(passedInList, direction);
				if (lilysHit > 1)
				{
					return result;
				}
			}
			else 
			{
				Debug.Log("terminating search, no path here");
			}
		}

		if (direction == "right")
		{
			if (currx + 1 == 6)
			{
				// found the top of the screen
				
				if (lilysHit == 0)
					Debug.Log("no lilys found in search, nothing to move");
				else if (lilysHit == 1)
					targetCoord = new Vector2(currx, curry);
				
				return listIn;
			}

			if (numbers[currx + 1, curry].Equals(1))
			{
				lilysHit++;
				
				if (lilysHit == 1)
				{
					movingLily = new Vector2(currx + 1, curry);
				}
				else if (lilysHit == 2)
				{
					targetCoord = new Vector2(currx, curry);
				}
			}
			
			List<Vector2> passedInList = new List<Vector2>();
			passedInList = listIn;
			
			bool addToList = CheckIfContains(passedInList, new Vector2(currVec.x + 1, currVec.y));
			if (!addToList)
			{
				passedInList.Add(new Vector2(currVec.x + 1, currVec.y));
				
				List<Vector2> result = DFSSearch(passedInList, direction);
				if (lilysHit > 1)
				{
					return result;
				}
			}
			else 
			{
				Debug.Log("terminating search, no path here");
			}
		}
		
		return returner;
	}
	
	bool CheckIfContains(List<Vector2> inList, Vector2 comparison)
	{
		foreach(Vector2 vec in inList)
		{
			if (comparison == vec)
			{
				Debug.Log("the value was found inside the list already");
				return true;
				
			}
		}
		return false;
	}

	public void InitiateMovement(Vector2 gateCoord)
	{
		//PrintGrid();

		string direction2 = "";
		if (gateCoord.x < 1)
		{
			direction2 = "right";
		}

		if (gateCoord.x > 5)
		{
			direction2 = "left";
		}

		if (gateCoord.y < 1)
		{
			direction2 = "up";
		}

		if (gateCoord.y > 5)
		{
			direction2 = "down";
		}

		FindPath((int)gateCoord.x, (int)gateCoord.y, direction2);

		//Debug.Log("first lily hit: " + movingLily);
		Debug.Log("target coord: " + targetCoord);

		numbers[(int)movingLily.x, (int)movingLily.y] = 0;
		numbers[(int)targetCoord.x, (int)targetCoord.y] = 1;
		
		Vector2[] tempArray = new Vector2[2];

		tempArray[0] = movingLily;
		tempArray[1] = targetCoord;
		
		BroadcastMessage("MoveLilyPad", tempArray);
		snailPathfinder.CheckButton ();
		//PrintGrid();
	}
}
