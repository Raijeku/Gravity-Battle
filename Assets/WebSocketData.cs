using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class WebSocketData
{

    public string Reason { get; set; }
    public string ID { get; set; }
    public float RX { get; set; }
    public float RY { get; set; }
    public float RZ { get; set; }
    public string Mob { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public WebSocketData(string Reason, string ID, float X, float Y, float Z, float RX, float RY, float RZ){
        this.Reason=Reason;
        this.ID=ID;
        this.X=X;
        this.Y=Y;
        this.Z=Z;
        this.RX=RX;
        this.RY=RY;
        this.RZ=RZ;
        this.Mob="";
    }

    public WebSocketData(string Reason, string ID, float X, float Y, float Z, string Mob){
        this.Reason=Reason;
        this.ID=ID;
        this.X=X;
        this.Y=Y;
        this.Z=Z;
        this.Mob=Mob;
        this.RX=0f;
        this.RY=0f;
        this.RZ=0f;
    }

    public WebSocketData(string Reason, string ID){
        this.Reason=Reason;
        this.ID=ID;
        this.X=0f;
        this.Y=0f;
        this.Z=0f;
        this.Mob="";
        this.RX=0f;
        this.RY=0f;
        this.RZ=0f;
    }

    public WebSocketData(string json){
        Debug.Log(json);
        WebSocketData data=JsonConvert.DeserializeObject<WebSocketData>(json);
        Debug.Log(data);
        Reason=data.Reason;
        ID=data.ID;
        X=data.X;
        Y=data.Y;
        Z=data.Z;
        RX=data.RX;
        RY=data.RY;
        RZ=data.RZ;
        Mob=data.Mob;
    }

    public WebSocketData(){

    }

    public string Serialize(){
        string json=JsonConvert.SerializeObject(this);
        return json;
    }

    public WebSocketData Deserealize(string json){
                Debug.Log(json);

        WebSocketData data=JsonConvert.DeserializeObject<WebSocketData>(json);
        return data;
    }

}
