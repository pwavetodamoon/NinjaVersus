using UnityEngine;
using Fusion;
using UnityEngine.Serialization;

public class PlayerSpawn : SimulationBehaviour,IPlayerJoined
{
    [SerializeField] private GameObject _player;
    [FormerlySerializedAs("_player_SpawnPosition")] [SerializeField] private Transform _playerSpawnPosition;

    public void PlayerJoined(PlayerRef player)
    {
        Runner.Spawn(_player, _playerSpawnPosition.position, Quaternion.identity);
    }
}
