using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerNameTaker : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject inputNamePanel;
    [SerializeField] private PlayerSO playerSO; // ScriptableObject to store player data;
    // Removed unused instance creation to avoid errors

    void Start()
    {
        // Add listener to the input field to get the player name when the input field is closed
        inputField.onEndEdit.AddListener(delegate { LocalPlayerName(); });
    }

    public void LocalPlayerName()
    {
        playerSO.playerName = inputField.text; // get the player name from the input field
        Debug.Log("Player Name: " + playerSO.playerName); // log the player name
       // inputNamePanel.SetActive(false); // hide the input name panel after getting the player name
        LoadMinigameScene();
    }


    private void LoadMinigameScene()
    {
        SceneManager.LoadScene("Main"); // Load the minigame scene
    }
}
