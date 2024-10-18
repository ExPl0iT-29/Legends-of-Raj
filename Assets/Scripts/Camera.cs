using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] private Transform player;
    private float smoothspeed = 0.125f;
    private float startFollowXPosition = 0;

    public UnityEngine.Vector3 offset;

    private bool _isFollowing = false;

    // Update is called once per frame
    void Update()
    {
        if(!_isFollowing && player != null){
            if(player.position.x >= startFollowXPosition){
                _isFollowing = true;
            }
        }

        if(_isFollowing && player != null){
            var desiredPosition = player.position;
            var smoothPosition = UnityEngine.Vector3.Lerp(transform.position, desiredPosition, smoothspeed);

            var freezeYPosition = new UnityEngine.Vector3(smoothPosition.x, transform.position.y, transform.position.z);
            transform.position = freezeYPosition;
        }






    }
}
