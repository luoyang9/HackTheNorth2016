using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public bool isGameOver;
    public Text scoreTxt;
    public Text VRGameOverText;
    public Canvas VRGameOverCanvas;

    private int _currScore;

    /// <summary>
    /// Start a new game.
    /// </summary>
    void NewGame()
    {
        ResetGame();
    }


    /// <summary>
    /// Got an enemy! Increment the score and see if we win.
    /// </summary>
    public void GotOne()
    {
        _currScore++;
        scoreTxt.text = "" + _currScore;
    }

    /// <summary>
    /// Game's over. 
    /// </summary>
    public void GameOver()
    {
        isGameOver = true;
        string finalText = "Too bad";
        if (GvrViewer.Instance.VRModeEnabled)
        {
            VRGameOverCanvas.enabled = true;
            VRGameOverText.text = finalText;
        }
    }


    /// <summary>
    /// Resets the interface, removes remaining game objects. Basically gets us to a point
    /// where we're ready to play again.
    /// </summary>
    public void ResetGame()
    {
        // Reset the interface
        VRGameOverCanvas.enabled = false;
        isGameOver = false;
        _currScore = 0;
        scoreTxt.text = "--";
        PlayerHealth playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        playerHealth.currentHealth = playerHealth.startingHealth;
        // Remove any remaining game objects
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject projectile in projectiles)
        {
            Destroy(projectile);
        }
    }

    void Start()
    {
        NewGame();
    }

}
