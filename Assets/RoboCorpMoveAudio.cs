using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboCorpMoveAudio : MonoBehaviour
{
    public AK.Wwise.Event MoveEvent;
    

    public void RoboMoveEvent()
    {
        MoveEvent.Post(gameObject);
    }
}
