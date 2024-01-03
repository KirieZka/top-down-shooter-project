using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvents : MonoBehaviour
{
    public CharNumScript charNum;
    public UserInputData userInputData;
    public AK.Wwise.Event Reloading1Event;
    public AK.Wwise.Event Reloading2Event;
    public AK.Wwise.Event Reloading3Event;

    public AK.Wwise.Event Shoot1Event;
    public AK.Wwise.Event Shoot2Event;
    public AK.Wwise.Event Shoot3Event;

    public AK.Wwise.Event PlayerStepEvent;



    public void ReloadingAudioEvent()
    {
        if (charNum.CharNum == 1)
        {
            Reloading1Event.Post(gameObject);
        }
        if (charNum.CharNum == 2)
        {
            Reloading2Event.Post(gameObject);
        }
        if (charNum.CharNum == 3)
        {
            Reloading3Event.Post(gameObject);
        }
    }

    public void ShootingAudioEvent()
    {
        if (charNum.CharNum == 1 && userInputData.Ammo > 0)
        {
            Shoot1Event.Post(gameObject);
        }
        if (charNum.CharNum == 2 && userInputData.Ammo > 0)
        {
            Shoot2Event.Post(gameObject);
        }
        if (charNum.CharNum == 3 && userInputData.Ammo > 0)
        {
            Shoot3Event.Post(gameObject);
        }
    }

    public void StepEvent()
    {
        PlayerStepEvent.Post(gameObject);
    }


}
