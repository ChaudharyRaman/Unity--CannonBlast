using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    public int speed;
    public float friction;
    public float lerpSpeed;
    float xDegrees;
    float yDegrees;
    Quaternion fromRotation;
    Quaternion toRotation;
    Camera camera;
    
    //Cannon Firing Variable
    public GameObject cannonBall;
    public Slider slider;
    Rigidbody cannonBallRb;
    public Transform shotPos;
    public GameObject explosion;
    public float firePower;
    public int powerMultiplier=100;
    GameManager GM;
    void Start()
    {
         
        camera=Camera.main;
        //firePower*=powerMultiplier;
        GM=(GameManager)FindObjectOfType(typeof(GameManager));

    }

    void Update()
    {
        RaycastHit hit;
        Ray ray=camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit)){
            if(hit.transform.gameObject.tag=="Cannon"){
                if(Input.GetMouseButton(0)){
                    xDegrees-=Input.GetAxis("Mouse Y")*speed*friction;
                    yDegrees+=Input.GetAxis("Mouse X")*speed*friction;
                    fromRotation=transform.rotation;
                    toRotation=Quaternion.Euler(xDegrees,yDegrees,0);
                    transform.rotation=Quaternion.Lerp(fromRotation,toRotation,Time.deltaTime*lerpSpeed);
                }
            }
        }
        //if(Input.GetMouseButtonDown(1)){
          //  FireCannon();
        //}
    }
    public void FireCannon(){
       
        shotPos.rotation=transform.rotation;
        firePower=slider.value*powerMultiplier;
        GameObject cannonBallCopy=Instantiate(cannonBall,shotPos.position,shotPos.rotation) as GameObject;
        cannonBallRb=cannonBallCopy.GetComponent<Rigidbody>();
        cannonBallRb.AddForce(transform.forward*firePower);
        Instantiate(explosion,shotPos.position,shotPos.rotation);
         GM.ChangeToCannonBall();
    }
}
