using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public static MenuManager refrence;

    public enum Mode { pvp, pvc, cvc }; // player vs player or player vs code or code vs code
    public Mode gameMode;

    void Awake()
    {
        if(refrence == null)
        {
            refrence = this;
        }
    }

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void goToGamePVP()
    {
        gameMode = Mode.pvp;
        openGamePlayScene();
    }

    public void goToGamePVC()
    {
        gameMode = Mode.pvc;
        openGamePlayScene();
    }

    public void goToGameCVC()
    {
        gameMode = Mode.cvc;
        openGamePlayScene();
    }

    public void openGamePlayScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        
    }
}
