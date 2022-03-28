using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostWwiseEvent : MonoBehaviour
{

    public AK.Wwise.Event Player_Footstep;
    public AK.Wwise.Event Player_Jump;
    public AK.Wwise.Event Player_Land;


    public void Player_Footstep_Event()
    {
        Player_Footstep.Post(gameObject);
    }

    public void Player_Jump_Event()
    {
        Player_Jump.Post(gameObject);
    }

    public void Player_Land_Event()
    {
        Player_Land.Post(gameObject);
    }

}
