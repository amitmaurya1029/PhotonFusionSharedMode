using Fusion;
using Fusion.Sockets;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManagerVR : MonoBehaviour, INetworkRunnerCallbacks
{
    [Header("Assign Your Player Prefab")]
    public NetworkPrefabRef playerPrefab;

    private NetworkRunner _runner;

    private async void Start()
    {
        _runner = gameObject.AddComponent<NetworkRunner>();
        _runner.ProvideInput = true;


        // Register callbacks
        _runner.AddCallbacks(this);

        // Start Shared Mode Session
        var startGameArgs = new StartGameArgs()
        {
            GameMode = GameMode.Shared,
            SessionName = "newsessionforVR",
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>(),
            Scene = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex)
        };

        var result = await _runner.StartGame(startGameArgs);

        if (result.Ok)
        {
            Debug.Log("Fusion Shared Mode started successfully. : 1");
        }
        else
        {
            Debug.LogError($"Fusion failed to start: {result.ShutdownReason}");
        }
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {

        if (player == runner.LocalPlayer)
        {
            Debug.Log($"Player join 1: ");

            // Spawn position can be customized
            Vector3 spawnPosition = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            Debug.Log($"Player join 2: ");
            runner.Spawn(playerPrefab, new Vector3(Random.Range(1, 5), 0, 0), Quaternion.identity, player);
            Debug.Log($"Player join 3: ");
        }

    }
    #region Not Implemented callbacks
    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        //throw new System.NotImplementedException();
    }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        // throw new System.NotImplementedException();
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {
        //  throw new System.NotImplementedException();
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        request.Accept();
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        // throw new System.NotImplementedException();
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        // throw new System.NotImplementedException();
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, System.ArraySegment<byte> data)
    {

    }

    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {

    }

    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        // throw new System.NotImplementedException();
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {

    }

    public void OnConnectedToServer(NetworkRunner runner)
    {

    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        //throw new System.NotImplementedException();
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        //throw new System.NotImplementedException();
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        //  throw new System.NotImplementedException();
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        //throw new System.NotImplementedException();
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
        // throw new System.NotImplementedException();
    }
    #endregion

   
}
