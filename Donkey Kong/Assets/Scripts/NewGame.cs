using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {

	void Update()
	{
		if(Input.GetKeyDown("enter"))
		{
				GameA();
		}
	}


	public void GameA()
	{
		SceneManager.LoadScene ("Level 1");
	}
}
