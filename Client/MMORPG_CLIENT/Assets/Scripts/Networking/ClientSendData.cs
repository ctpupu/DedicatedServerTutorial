using UnityEngine;
using System.Collections;

public class ClientSendData : MonoBehaviour
{
    public static ClientSendData instance;
    public Network network;

    // Use this for initialization
    void Awake()
    {
        instance = this;
    }

    public void SendDataToServer(byte[] data)
    {
        KaymakGames.KaymakGames buffer = new KaymakGames.KaymakGames();
        buffer.WriteBytes(data);
        network.myStream.Write(buffer.ToArray(), 0, buffer.ToArray().Length);
        buffer = null;
    }
}
