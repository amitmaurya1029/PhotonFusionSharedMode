using Fusion;
using UnityEngine;

public class Health : NetworkBehaviour
{
    [Networked, OnChangedRender(nameof(HealthChanged))]
    public float NetworkedHealth { get; set; } = 100;
    

    void HealthChanged()
    {
        //Debug.Log($"Health changed to: {NetworkedHealth}");
          Debug.Log($"Current health  : {NetworkedHealth}" + $"playerName : {GetComponent<PlayerIdentity>().playerRef.ToString()}");

    }


    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]     // rpc sources. all means that all the clinets has the ability to call the rpc functions
    public void DealDamageRpc(float damage, string playerName)
    {
        // The code inside here will run on the client which owns this object (has state and input authority).
        NetworkedHealth -= damage;
        Debug.Log("Checking current health from dealDamageRPC : " + NetworkedHealth);
      
    }


    
}


// Player A.
// dealDamageRPC();


//RpcTargets.StateAuthority means that only how has the stateAuthority can call the rpc function

// anyone can call the rpc function who ons the sateauthority



