using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDroneWalkScript : MonoBehaviour
{
    public AK.Wwise.Event moveEvent;
    
    public void AudioDroneWalk()
    {
        moveEvent.Post(gameObject);
    }
}
