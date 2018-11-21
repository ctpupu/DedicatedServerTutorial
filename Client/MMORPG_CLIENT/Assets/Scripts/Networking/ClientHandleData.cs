using System;
using UnityEngine;
using UnityEngine.UI;

public class ClientHandleData : MonoBehaviour
{

    public static ClientHandleData instance;

    private void Awake()
    {
        instance = this;
    }

    void HandleMessages(int packetNum, byte[] data)
    {
        switch (packetNum)
        {
            case 1:
                HandleJoinGame(packetNum,data);
                break;
            case 2:
                HandleInstantiatePlayer(packetNum, data);
                break;
            case 3:
                HandleGetOtherPlayer(packetNum, data);
                break;
        }
    }

    public void HandleData(byte[] data)
    {
        int packetnum;
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteBytes(data);
        packetnum = buffer.ReadInteger();
        buffer = null;
        if (packetnum == 0)
            return;

        HandleMessages(packetnum, data);
    }

    void HandleJoinGame(int packetNum,byte[]data)
    {
        int packetnum;
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteBytes(data);
        packetnum = buffer.ReadInteger();
        int MyIndex = buffer.ReadInteger();
        Globals.instance.MyIndex = MyIndex;
        Network.instance.playerPref = Instantiate(Network.instance.playerPref, Network.instance.spawnPoint);
        Network.instance.playerPref.name = "Player: " + MyIndex.ToString();
        Network.instance.playerPref.GetComponent<NetPlayer>().Index = MyIndex;
    }

    public void HandleInstantiatePlayer(int packetNum,byte[]data)
    {
        int packetnum;
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteBytes(data);
        packetnum = buffer.ReadInteger();
        int PlayerIndex = buffer.ReadInteger();
        Network.instance.playerPref = Instantiate(Network.instance.playerPref, Network.instance.spawnPoint);
        Network.instance.playerPref.name = "Player: " + PlayerIndex.ToString();
        Network.instance.playerPref.GetComponent<NetPlayer>().Index = PlayerIndex;
    }

    public void HandleGetOtherPlayer(int packetNum,byte[]data)
    {
        int packetnum;
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteBytes(data);
        packetnum = buffer.ReadInteger();
        int PlayerIndex = buffer.ReadInteger();
        Network.instance.playerPref = Instantiate(Network.instance.playerPref, Network.instance.spawnPoint);
        Network.instance.playerPref.name = "Player: " + PlayerIndex.ToString();
        Network.instance.playerPref.GetComponent<NetPlayer>().Index = PlayerIndex;
    }
}
