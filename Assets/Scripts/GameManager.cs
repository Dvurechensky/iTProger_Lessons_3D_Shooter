using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string PLAYER_ID = "Player ";
    private static Dictionary<string, Player> _players = new ();
    public static void RegisterPlayer(string _netId, Player player)
    {
        string playerID = PLAYER_ID + _netId;
        _players.Add(playerID, player);
        player.transform.name = playerID;
    }

    public static void UnRegisterPlayer(string playerID)
    {
        _players.Remove(playerID);
    }

    public static Player GetPlayer(string playerID)
    {
        return _players[playerID];
    }
}
