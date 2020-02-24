using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/**
 * When the computer's tank is hit, a red X is displayed in the top right hand corner, representing the number of times the player has been hit.
 * When the player's tank is hit, a red X is displayed in the bottom right hand corner.
 * After being hit three times, either the player tank wins or the computer opponent wins. A message is displayed and the losing tank disappears.
 * The game can start immediately when launched.
 */
public class GameController : MonoBehaviour
{
    public Text playerHitsText;
    public Text computerHitsText;
    public Text gameEndText;
    private int playerHits = 0;
    private int compHits = 0;
    private bool gameEnd = false;

    // Start is called before the first frame update
    private void Start()
    {
        gameEndText.text = ""; // Set End Game Text to nothing
        playerHitsText.text = ""; // Set Player hits Text to nothing
        computerHitsText.text = ""; // Set Computer hits Text to nothing
    }

    private void Update()
    {

        // Game has ended
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Exit Game
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Pressing 'R' should restart the game, and can happen at anytime.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    public bool SetComputerTankText()
    {
        // Setting Computers Text
        if (compHits < 3)
        {
            computerHitsText.text = computerHitsText.text + "X"; // Set Computer hits Text to nothing
            compHits++;
        }
        if(compHits == 3) {
            gameEnd = true;
            gameEndText.text = "GAME OVER YOU WIN\nPress ESC to exit\nPress R to restart.";
        }
        return gameEnd;
    }

    public bool SetPlayerTankText()
    {
        // Settig Players Text
        if (playerHits < 3)
        {
            playerHitsText.text = playerHitsText.text + "X"; // Set Player hits Text to nothing
            playerHits++;
        }
        if (playerHits == 3) {
            gameEnd = true;
            gameEndText.text = "GAME OVER COMPUTER WINS\nPress ESC to exit\nPress R to restart.";
        }
        return gameEnd;
    }
}
