    using System.Collections;
using System.Collections.Generic;
using Fusion;
using TMPro;
using UnityEngine;

public class PlayerIdentity : NetworkBehaviour
{
    [Networked]
     public PlayerRef playerRef { get; set; }
    // This class is used to identify the player in the game.
     public TextMeshProUGUI playerNameText;


     

    void Start()
    {

    }

 
    public void UpdatePlayerNameUi()
    {
        //GetComponent<PlayerNameUI>().SetPlayerName(playerRef.ToString());
        playerNameText.text = playerRef.ToString(); // Update the player name UI with the playerRef
    }

    public override void Spawned()
    {
        if (Object.HasInputAuthority)
        {
            playerRef = Object.InputAuthority; // assign the playerRef to the PlayerIdentity component
            UpdatePlayerNameUi(); // update the player name UI with the playerRef
            Debug.Log("spawned player : " + Object.InputAuthority); // give local player a unique identity

        }
    }  
    
    
}
