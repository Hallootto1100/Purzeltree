using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Canvas pauseMenu;
    public PostProcessVolume postVolume;

    private DepthOfField dof;
    
    private void Update() {
        if(SceneManager.GetActiveScene().name == "StartScreen")    
            return;
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            togglePause();
        }
    }

    private void Awake() 
    {
        if(postVolume){
            postVolume.profile.TryGetSettings<DepthOfField>(out dof);
            dof.enabled.value = false;

        }

        if(pauseMenu)
            pauseMenu.enabled = false;   
            
        Time.timeScale = 1f;
    }


    private void togglePause()
    {
        if(Time.timeScale == 0f){
            Time.timeScale = 1f;
            pauseMenu.enabled = false;
            dof.enabled.value = false;
        }
        else{
            Time.timeScale = 0f;
            pauseMenu.enabled = true;
            dof.enabled.value = true;
        }
    }

    public void exitGame()
    {
        Debug.Log("Bye!");
        Application.Quit(0);
    }

    public void goToMainMenu()
    {
        Debug.Log("Back to Main Menu");
        SceneManager.LoadScene("StartScreen");
    }

    public void startGame()
    {
        Debug.Log("Game Started");
        SceneManager.LoadScene("SampleScene");
    }
}
