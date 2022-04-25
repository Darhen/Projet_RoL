using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    // Actions
    //public AK.Wwise.Event Move_Box;
    public AK.Wwise.Event Pickup;
    public AK.Wwise.Event Player_Kneel;
    public AK.Wwise.Event Pull_Lever;

    /*public void CallAKEvent_Move_Box()
    {
        Move_Box.Post(gameObject);
    }*/

    public void CallAKEvent_Pickup()
    {
        Pickup.Post(gameObject);
    }

    public void CallAKEvent_Player_Kneel()
    {
        Player_Kneel.Post(gameObject);
    }
    public void CallAKEvent_Pull_Lever()
    {
        Pull_Lever.Post(gameObject);
    }
}
