using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player Movement
    //Object Definitions
    public AK.Wwise.Event Player_Footstep;
    public AK.Wwise.Event Player_Jump;
    public AK.Wwise.Event Player_Land;
    public AK.Wwise.Event Close_Hangglider;
    public AK.Wwise.Event Open_Hangglider;

    //Functions
    public void CallAKEvent_Player_Footstep()
    {
        Player_Footstep.Post(gameObject);
    }

    public void CallAKEvent_Player_Jump()
    {
        Player_Jump.Post(gameObject);
    }

    public void CallAKEvent_Player_Land()
    {
        Player_Land.Post(gameObject);
    }

    public void CallAKEvent_Close_Hangglider()
    {
        Close_Hangglider.Post(gameObject);
    }

    public void CallAKEvent_Open_Hangglider()
    {
        Open_Hangglider.Post(gameObject);
    }

}
