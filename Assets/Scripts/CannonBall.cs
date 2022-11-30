using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float lifeTime=5f;
    public GameObject explosion;
    public float minY =-20f;
    GameManager GM;
    void Start()
    {
        GM=(GameManager)FindObjectOfType(typeof(GameManager));
    }

    
    void Update()
    {
        StatusCheck();

    }
    void StatusCheck(){
        lifeTime-=Time.deltaTime;
        if(lifeTime<0){
            Debug.Log("workign");
            CannonBallDestroy();
        }
        if(transform.position.y<minY){
            CannonBallDestroy();        }
    }
    void CannonBallDestroy(){
        Instantiate(explosion,transform.position,transform.rotation);
        GM.ChangeToCannon();
        Destroy(this.gameObject);
    }
     private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="GreenTarget"){
            GM.GreenTargetHit();
            CannonBallDestroy();
        }
        if(other.gameObject.tag=="YellowTarget"){
            GM.YellowTargetHit();
            CannonBallDestroy();

        }
        if(other.gameObject.tag=="RedTarget"){
            GM.RedTargetHit();
             CannonBallDestroy();

        }
    }
}
