using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;

public class WebSocketClient : MonoBehaviour
{

    WebSocketData webSocketData;
    GameObject[] planets;
    public GameObject asteroid;
    public GameObject planet;
    WebSocket ws;

    // Start is called before the first frame update
    void Awake()
    {
        /*string json="{\"Reason\":\"Generate\",\"ID\":\"00000000-0000-0000-0000-000000000000\",\"RX\":0.0,\"RY\":0.0,\"RZ\":0.0,\"Mob\":\"Planet\",\"X\":-63.0,\"Y\":71.0,\"Z\":-41.0}";
                Debug.Log(json);
                var data=JsonConvert.DeserializeObject<WebSocketData>(json);
                Debug.Log(data);*/
        /*using (var ws = new WebSocket("ws://localhost:2012"))
            {
               ws.OnMessage += (sender, e) =>
                    webSocketData=new WebSocketData(e.Data);
                    switch (webSocketData.Reason)
                    {
                        case "Movement":
                            planets=GameObject.FindGameObjectsWithTag("Planet");
                            foreach (GameObject planet in planets)
                            {
                                if (webSocketData.ID==planet.GetComponent<MobController>().ID)
                                {
                                    planet.transform.rotation=webSocketData.Rotation;
                                    planet.GetComponent<Rigidbody>().AddForce(webSocketData.Force);
                                }
                            }
                            break;
                        case "Generate":
                            if (webSocketData.Mob=="Asteroid")
                            {
                                Instantiate(asteroid,new Vector3(webSocketData.X,webSocketData.Y,webSocketData.Z), Quaternion.identity);
                                asteroid.GetComponent<MobController>().ID=webSocketData.ID;
                            }
                            else if (webSocketData.Mob=="Planet")
                            {
                                Instantiate(planet,new Vector3(webSocketData.X,webSocketData.Y,webSocketData.Z), Quaternion.identity);
                                planet.GetComponent<MobController>().ID=webSocketData.ID;
                            }
                            break;
                        case "Dead":
                            foreach (GameObject planet in planets)
                            {
                                if (webSocketData.ID==planet.GetComponent<MobController>().ID)
                                {
                                    Destroy(planet);
                                }
                            }
                            break;
                        default:
                            break;
                    }

                ws.Connect();
                //ws.Send("Yeah");
                //Console.ReadKey(true);
            }*/
            ws = new WebSocket("ws://localhost:2012");
            ws.OnMessage += (sender, e) => /* {Send("On Message");};*/SetupWebSocket(e.Data);
                    /*{ 
                        webSocketData=new WebSocketData(e.Data);
                        Debug.Log(webSocketData.Reason);
                    switch (webSocketData.Reason)
                    {
                        case "Movement":
                            planets=GameObject.FindGameObjectsWithTag("Planet");
                            foreach (GameObject planet in planets)
                            {
                                if (webSocketData.ID==planet.GetComponent<MobController>().ID)
                                {
                                    planet.transform.rotation=new Quaternion(webSocketData.RX,webSocketData.RY,webSocketData.RZ,planet.transform.rotation.w);
                                    planet.GetComponent<Rigidbody>().AddForce(new Vector3(webSocketData.X,webSocketData.Y,webSocketData.Z));
                                }
                            }
                            break;
                        case "Generate":
                            if (webSocketData.Mob=="Asteroid")
                            {
                                Instantiate(asteroid,new Vector3(webSocketData.X,webSocketData.Y,webSocketData.Z), Quaternion.identity);
                                asteroid.GetComponent<MobController>().ID=webSocketData.ID;
                            }
                            else if (webSocketData.Mob=="Planet")
                            {
                                Instantiate(planet,new Vector3(webSocketData.X,webSocketData.Y,webSocketData.Z), Quaternion.identity);
                                planet.GetComponent<MobController>().ID=webSocketData.ID;
                            }
                            break;
                        case "Dead":
                            foreach (GameObject planet in planets)
                            {
                                if (webSocketData.ID==planet.GetComponent<MobController>().ID)
                                {
                                    Destroy(planet);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    };*/

                ws.Connect();
            
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void Send(string json){
        //using (var ws = new WebSocket("ws://localhost:2012"))
          //  {
                ws.Send(json);
            //}
    }

    public void SetupWebSocket(string data){
        //webSocketData= new WebSocketData();
        //webSocketData = webSocketData.Deserealize(data);
        webSocketData=new WebSocketData(data);
                Send("On Message");

                    switch (webSocketData.Reason)
                    {
                        case "Movement":
                        Debug.Log("Movement");
                            planets=GameObject.FindGameObjectsWithTag("Planet");
                            foreach (GameObject planet in planets)
                            {
                                if (webSocketData.ID==planet.GetComponent<MobController>().ID)
                                {
                                    planet.transform.rotation=new Quaternion(webSocketData.RX,webSocketData.RY,webSocketData.RZ,planet.transform.rotation.w);
                                    planet.GetComponent<Rigidbody>().AddForce(new Vector3(webSocketData.X,webSocketData.Y,webSocketData.Z));
                                }
                            }
                            break;
                        case "Generate":
                        Debug.Log("Generate");
                            if (webSocketData.Mob=="Asteroid")
                            {
                                Instantiate(asteroid,new Vector3(webSocketData.X,webSocketData.Y,webSocketData.Z), Quaternion.identity);
                                asteroid.GetComponent<MobController>().ID=webSocketData.ID;
                            }
                            else if (webSocketData.Mob=="Planet")
                            {
                                Instantiate(planet,new Vector3(webSocketData.X,webSocketData.Y,webSocketData.Z), Quaternion.identity);
                                planet.GetComponent<MobController>().ID=webSocketData.ID;
                            }
                            break;
                        case "Dead":
                                                Debug.Log("Dead");

                            foreach (GameObject planet in planets)
                            {
                                if (webSocketData.ID==planet.GetComponent<MobController>().ID)
                                {
                                    Destroy(planet);
                                }
                            }
                            break;
                        default:
                            break;
        }
    }
}
