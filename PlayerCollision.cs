using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Move movement;

    void OnCollisionEnter(Collision collisionInfo)
    {
    	if(collisionInfo.collider.tag=="Obstacle")
    	{
    		movement.enabled=false;
    		FindObjectOfType<Gamemanager>().EndGame();
    	}
    }
}
