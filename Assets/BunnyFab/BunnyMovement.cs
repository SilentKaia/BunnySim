using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BunnyMovement : MonoBehaviour
{
    Rigidbody rb;
     bool hopping = false;
     int hops = 0;
     int hopsTillChange = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

    }
    void Update() {
        AIMovement();
    }
    void AIMovement(){ 

        var changeDirection = ChangeDirection();
        if(changeDirection){
            var turnRate = Random.Range(1,360);
            rb.transform.Rotate(0, turnRate, 0);
        }
        if(!hopping){

            
            Vector3 hop = rb.transform.forward;
            hop.z *= -250;
            hop.y = 150;
            rb.AddForce(hop);
            hopping = true;

            hops++;
            StartCoroutine(WaitForHopDelay());
            
        }
    }
    bool ChangeDirection(){

        if(hopsTillChange == 0)
            hopsTillChange = Random.Range(0,4);
        if(hops == hopsTillChange){
            hops = 0;
            return true;
        }

        return false;
    }
    IEnumerator WaitForHopDelay(){
        
        yield return new WaitForSeconds(2);
        hopping = false;

    }
}
