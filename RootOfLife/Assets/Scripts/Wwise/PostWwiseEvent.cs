using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostWwiseEvent : MonoBehaviour
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

 //Player Death
    //Object Definitions
    public AK.Wwise.Event Player_Death;
    public AK.Wwise.Event Player_Fall;
    public AK.Wwise.Event Player_Ram;
    public AK.Wwise.Event Player_Shot;
    public AK.Wwise.Event Player_Suffocate;

    public AK.Wwise.Event Player_Respawn;
    public AK.Wwise.Event Player_Spawn;

    //Functions
    public void CallAKEvent_Player_Death()
    {
        Player_Death.Post(gameObject);
    }

    public void CallAKEvent_Player_Fall()
    {
        Player_Fall.Post(gameObject);
    }

    public void CallAKEvent_Player_Ram()
    {
        Player_Ram.Post(gameObject);
    }

    public void CallAKEvent_Player_Shot()
    {
        Player_Shot.Post(gameObject);
    }

    public void CallAKEvent_Player_Suffocate()
    {
        Player_Suffocate.Post(gameObject);
    }



    public void CallAKEvent_Player_Respawn()
    {
        Player_Respawn.Post(gameObject);
    }

    public void CallAKEvent_Player_Spawn()
    {
        Player_Spawn.Post(gameObject);
    }


 // Actions
    public AK.Wwise.Event Move_Box;
    public AK.Wwise.Event Pickup;

    public void CallAKEvent_Move_Box()
    {
        Move_Box.Post(gameObject);
    }

    public void CallAKEvent_Pickup()
    {
        Pickup.Post(gameObject);
    }

}
