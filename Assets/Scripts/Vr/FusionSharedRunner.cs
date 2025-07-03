using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Fusion;

public class FusionSharedRunner : MonoBehaviour
{
    async void Start()
    {
        var runner = gameObject.AddComponent<NetworkRunner>();

        runner.ProvideInput = true;


        await runner.StartGame(new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = "10203vrfusion",
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>(),
        });
    }

    


}
