using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class information : MonoBehaviour
{
    public TMP_Text heightText;
    public TMP_Text gravityText;
    public TMP_Text forceText;
    public TMP_InputField forceField;
    public Slider heightSlider;
    public Vector3 initialPos;
    private float gravity = 9.807f;
    private float force = 1f;
    private float angle = 45f;
    private GameObject projectile;
    public GameObject projectileTemplate;

    void Start(){
        initialPos = transform.position;
    }
    void Update()
    {
        transform.position = new Vector3(initialPos.x,heightSlider.value,initialPos.z);
        heightText.text = transform.position.y.ToString() + "m";

    }

    public void changeGravity(int value){
        switch(value){
            case 0: //Earth
            gravity = 9.807f;
            break;
            case 1: //Moon
            gravity = 1.6f;
            break;
            case 2: //Mars
            gravity = 3.721f;
            break;
            case 3: //Venus
            gravity = 8.87f;
            break;
            case 4: //Mercury
            gravity = 3.7f;
            break;
            case 5: //Jupiter
            gravity = 24.79f;
            break;
            case 6: //Saturn
            gravity = 10.44f;
            break;
            case 7: //Uranus
            gravity = 8.87f;
            break;
            case 8: //Neptune
            gravity = 11.15f;
            break;
            default:
            gravity = 9.8f;
            break;
        }
        gravityText.text = "Gravity " + gravity + "m^2/s";
    }

    public void changeForce(){     
        force = float.Parse(forceField.text);
        forceText.text = "Initial Force (m/s) " + force;
    }

    public void fire(){
        if(projectile == null){
            Debug.Log("New projectile");
            GameObject projectile = Instantiate(projectileTemplate, new Vector3(-10,transform.position.y,0),Quaternion.identity);
            projectile.GetComponent<Projectile>().startFire(gravity,angle,transform.position.y,force);
        }
        
    }
}
