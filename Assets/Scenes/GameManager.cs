using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    private void Update() {
        if(SceneManager.GetActiveScene().name == "StartScreen")    
            return;
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            togglePause();
        }
    }

    private void togglePause()
    {
        if(Time.timeScale == 0f)
            Time.timeScale = 1f;
        else
            Time.timeScale = 0f;
    }

    public void startGame()
    {
        Debug.Log("Game Started");
        SceneManager.LoadScene("SampleScene");
    }
}
