using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;


public class PlayerController : MonoBehaviour
{

    Guid guid;
    public int lives;
    WebSocketData webSocketData;
    System.Random random;
    public GameObject asteroid;

    // Start is called before the first frame update
    void Start()
    {
        random= new System.Random();
        webSocketData=new WebSocketData("Generate",Guid.NewGuid().ToString(),0f,0f,0f,"Planet");
        GameObject.Find("Web Socket Client").GetComponent<WebSocketClient>().Send(webSocketData.Serialize());
        for (int i = 0; i < 50; i++)
        {
            webSocketData=new WebSocketData("Generate",Guid.NewGuid().ToString(),random.Next(-100,100),random.Next(-100,100),random.Next(-100,100),"Asteroid");
            GameObject.Find("Web Socket Client").GetComponent<WebSocketClient>().Send(webSocketData.Serialize());
            Instantiate(asteroid,new Vector3(webSocketData.X,webSocketData.Y,webSocketData.Z), Quaternion.identity);
        }
        lives=5;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives<=0)
        {
            webSocketData=new WebSocketData("Dead",gameObject.GetComponent<MobController>().ID);
            GameObject.Find("Web Socket Client").GetComponent<WebSocketClient>().Send(webSocketData.Serialize());
        }
    }

    public void TakeDamage(){
        lives=lives-1;
    }
}
