using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;
    public GameObject playerPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Debug.Log("Zaten var");
            Destroy(this);
        }



    }

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;

        Server.Start(50, 26950);
      

    }

    private void OnApplicationQuit()
    {
        Server.Stop();
    }
    public Player InstantiatePlayer()
    {
        return Instantiate(playerPrefab,new  Vector3(333.3f,-14.0f,77.7f),Quaternion.identity).GetComponent<Player>();
    }
}
