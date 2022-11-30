using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
   public float redScore=1f;
   public float yellowScore=5f;
   public float greenScore=10f;
   public Text scoreText;
   public float score=0f;
    public Camera cannonCam;
    public Camera cannonBallCam;
    public FollowCamera followCamera;
    private void Start() {
        cannonBallCam.enabled=false;
    }
    public void ChangeToCannonBall(){
        cannonBallCam.enabled=true;
        followCamera=cannonBallCam.GetComponent<FollowCamera>();
       followCamera.target=GameObject.FindGameObjectWithTag("CannonBall").transform;
       cannonCam.enabled=false;
    }
    public void ChangeToCannon(){
        cannonCam.enabled=true;
        cannonBallCam.enabled=false;
    }
    public void ResetCannonBallCam(){
        cannonBallCam.transform.position=followCamera.initialPos; 
    }
    public void GreenTargetHit(){
        score+=greenScore;
        scoreText.text="Score: "+score;
    }
    public void YellowTargetHit(){
        score+=yellowScore;
        scoreText.text="Score: "+score;
    }
    public void RedTargetHit(){
        score+=redScore;
        scoreText.text="Score: "+score;
    }

}
