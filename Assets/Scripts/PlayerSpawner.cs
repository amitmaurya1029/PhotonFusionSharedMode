using System;
using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;
    NetworkObject spawnedPlayer;


    public void PlayerJoined(PlayerRef player)          // player join function gets call when player joins.
    {

        if (player == Runner.LocalPlayer)
        {
             spawnedPlayer = Runner.Spawn(PlayerPrefab, new Vector3(0, 1, 0), Quaternion.identity, player);
         
             Debug.Log("Player joined: " + player);


            //  obj.GetComponent<PlayerNameUI>().SetPlayerName(identity.playerRef.ToString()); // set the player name in the UI
        }


    }



 
}

// notes all the classes in multiplayer 
//just like the normal class in unity when we are making non multiplayer game?


