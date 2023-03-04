using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    float gravity;
    float angle;
    float initialHeight;
    float vX0;
    float vY0;
    float time;
    float maxHeight = 0f;
    bool start = false;

    public void startFire(float grav, float ang, float height, float force){
        gravity = grav; 
        angle = ang;
        initialHeight = height;
        vX0 = force * Mathf.Cos(ang);   
        vY0 = force * Mathf.Sin(ang);
        time = Time.time;
        start = true;
    }

    void FixedUpdate(){
        if(start){
            float y = initialHeight + vY0*((Time.time - time)) - .5f*(gravity)*(Mathf.Pow((Time.time - time), 2));
            if(y > maxHeight){
                maxHeight = y;
            }
            float x = -10 + vX0 * ((Time.time - time));
            Debug.Log("Delta time difference: " + (Time.time - time));
            transform.position = new Vector3(x,y,0);
        }
        if(transform.position.y < 0){
            Debug.Log(transform.position.y);
            Debug.Log("Final x: " + transform.position.x);
            Debug.Log("Max Height (m): " + maxHeight);
            Debug.Log("Time: " + (Time.time - time));
            Destroy(this.gameObject);
        }
    }
}
