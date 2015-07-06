using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playButton()
    {
        Application.LoadLevel(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

	public void StartGame()
	{
		Application.LoadLevel (2);
	}

	public void Menu()
	{
		Application.LoadLevel (0);
	}



    

   // public void optionsButton()
    //{
     //   Application.LoadLevel("Options");
    //}
    
}

