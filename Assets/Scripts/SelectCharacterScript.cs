using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterScript : MonoBehaviour
{
    public CharNumScript CharNum;

    public void SelectChar(int charNum)
    {
        CharNum.CharNum = charNum;
    }
}
