using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using TMPro;


public class PlayerNameUI : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI playerRefText;

    // public override void Spawned()
    // {
    //     // Set the PlayerRef text on spawn
    //     UpdatePlayerRefDisplay();
    // }

    // public override void Render()
    // {
    //     // Always keep the UI updated every frame
    //     UpdatePlayerRefDisplay();
    // }

    // private void UpdatePlayerRefDisplay()
    // {
    //     if (playerRefText != null)
    //     {
    //         playerRefText.text = Object.InputAuthority.ToString();
    //     }
    // }


    
   [Networked]
    public string PlayerName { get; set; }

    private string currentName = "";
    private string lastName = "";
    [SerializeField] private PlayerSO playerSO;







    public override void Spawned()
    {

        // Only the client with Input Authority sets the name
        if (Object.HasInputAuthority)
        {
            // Replace this with actual UI input or local name setting
            currentName = playerSO.playerName;
            RPC_SetPlayerName(currentName);
            lastName = currentName;
        }

        // Show name immediately if it's already set
        playerRefText.text = PlayerName;
    }


    public override void FixedUpdateNetwork()
    {
        // Update the name if it has changed to all clients
        if (PlayerName != lastName)
        {
            lastName = PlayerName;
            playerRefText.text = PlayerName;
        }
    }
    

    
    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]   // only the input authority can call this RPC, and it will be executed on the state authority 
    private void RPC_SetPlayerName(string name)
    {
        PlayerName = name;
    }
    // private static void OnNameChanged(Changed<PlayerNameUI> changed)
    // {
    //     // Called on all clients when name changes
    //     changed.Behaviour.playerRefText.text = changed.Behaviour.PlayerName;
    // }
    // }
   
}
