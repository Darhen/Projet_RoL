using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostWwiseEvent : MonoBehaviour
{

    public AK.Wwise.Event Player_Footstep;
    public AK.Wwise.Event Player_Jump;


    public void PlayFootstepSound()
    {
        Player_Footstep.Post(gameObject);
    }

    public void PlayJumpSound()
    {
        Player_Jump.Post(gameObject);
    }
}
