using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class BulletScript : MonoBehaviour
{
    //Attributes: uses serialize field to expose bullet speed in the editor
    [SerializeField] private int speed = 50;

    //Events: The event that will trigger when an enemy is hit and the score updates
    public static event Action<BulletScript> ScoreUpdate;

    void Update()
    {
        transform.position += (transform.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");

        if (collision.gameObject.tag == "enemy")
        {
            //Statics: static score variable updated
            GameManagerScript.Score += 1;
            Debug.Log("Enemy down, score:" + GameManagerScript.Score);
            
            //Events: Only invokes the event if there are any subscribers
            if (ScoreUpdate != null) ScoreUpdate(this);

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
