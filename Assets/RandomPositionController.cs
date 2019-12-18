using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionController : MonoBehaviour
{
    System.Random random;
    private Transform objectTransform;

    // Start is called before the first frame update
    void Start()
    {
        objectTransform=GetComponent<Transform>();
        /*int index=0;
        int gameObjectInteger=0;
        string name=gameObject.name;
        foreach (var character in name)
        {
            index=character;
            gameObjectInteger=gameObjectInteger+index;
        }
        gameObjectInteger=gameObjectInteger-name.Length*500;
        gameObjectInteger=gameObjectInteger*random.Next(-10,10);
        Vector3 playerPosition=GameObject.Find("Player").transform.position;
        random=new System.Random();
        gameObject.transform.position=new Vector3(5*random.Next(-gameObjectInteger,gameObjectInteger), 5*random.Next(-gameObjectInteger,gameObjectInteger), 5*random.Next(-gameObjectInteger,gameObjectInteger));
        foreach (Transform child in transform.GetChild(0).transform)
        {
            if (child.gameObject.name=="Velocity")
            {
                child.gameObject.transform.position = new Vector3(random.Next(-2,2),random.Next(-2,2),random.Next(-2,2));
            }
        }*/
    }

    [ContextMenu("Randomize Position")]
		public void RandomPosition()
		{
			objectTransform.position=new Vector3(random.Next(-100,100), random.Next(-100,100), random.Next(-100,100));
            foreach (Transform child in transform.GetChild(0).transform)
        {
            if (child.gameObject.name=="Velocity")
            {
                child.gameObject.transform.position = new Vector3(random.Next(-2,2),random.Next(-2,2),random.Next(-2,2));
            }
        }
		}

}
