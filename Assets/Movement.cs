using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody objectRigidbody;
    WebSocketData webSocketData;

    // Start is called before the first frame update
    void Start()
    {
        objectRigidbody=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit, 100))
        //{
            Vector2 lookPosition=Input.mousePosition;
            lookPosition.x=lookPosition.x-Screen.width/2;
            lookPosition.y=lookPosition.y-Screen.height/2;
            this.transform.LookAt(lookPosition);
        //}

        if (Input.GetButtonDown("Forward"))
        {
            objectRigidbody.AddForce(transform.forward*Input.GetAxis("Forward")*20f);
            webSocketData=new WebSocketData("Movement",gameObject.GetComponent<MobController>().ID,transform.forward.x*Input.GetAxis("Forward")*20f,transform.forward.y*Input.GetAxis("Forward")*20f,transform.forward.z*Input.GetAxis("Forward")*20f,transform.rotation.x,transform.rotation.y,transform.rotation.z);
            GameObject.Find("Web Socket Client").GetComponent<WebSocketClient>().Send(webSocketData.Serialize());
            //Debug.Log(JsonUtility.ToJson(webSocketData));
        }
    }
}
