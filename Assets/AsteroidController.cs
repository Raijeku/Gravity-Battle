using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleKeplerOrbits;

public class AsteroidController : MonoBehaviour
{

    private bool isAttached;
    KeplerOrbitMover keplerOrbitMover;

    // Start is called before the first frame update
    void Start()
    {
        keplerOrbitMover=GetComponent<KeplerOrbitMover>();
        if (keplerOrbitMover.AttractorSettings.AttractorObject!=null)
        {
            isAttached=true;
        }
        else
        {
            isAttached=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        if (collider.tag=="Planet")
        {
            if (!isAttached)
            {
                keplerOrbitMover.AttractorSettings.AttractorObject=collider.gameObject.transform;
                keplerOrbitMover.SetAutoCircleOrbit();
            }
            
        }
        else if(collider.tag=="Planet Sphere")
        {
            if (collider.name=="Player")
            {
                AndroidCollision(collider.gameObject);
            }
            Destroy(gameObject);
        }
        
    }

    void AndroidCollision(GameObject player){
        player.GetComponent<PlayerController>().TakeDamage();
    }
}
