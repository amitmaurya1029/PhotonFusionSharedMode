using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System;

public class PlayerSpawn : SimulationBehaviour, IPlayerJoined
{
   

   [SerializeField] private NetworkObject xrPlayerRig;

   public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            if (Object.HasStateAuthority)
            {
                Vector3 spawnPosition = new Vector3(0, 1, 0);
                Quaternion spawnRotation = Quaternion.identity;

                var playerObject = Runner.Spawn(xrPlayerRig, spawnPosition, spawnRotation, player);

                // Optionally, you can set up the player here (e.g., initialize components)
                Debug.Log("Player joined: " + playerObject.name);
            }
        }
    }

  
}
