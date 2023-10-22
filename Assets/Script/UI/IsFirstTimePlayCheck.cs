using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFirstTimePlayCheck : MonoBehaviour
{
    private void Awake()
    {
        FirstTimePlayState();
    }

    public void FirstTimePlayState()
    {
        /*
        if (!PlayerPrefs.HasKey("IsFirstTimePlay"))
        {
            PlayerPrefs.SetInt("IsFirstTimePlay", 1);

            PlayerPrefs.SetInt("PlayerLife", 5);
            PlayerPrefs.SetInt("PlayerEnergy", 3);
            PlayerPrefs.SetInt("PlayerDiamond", 0);
            PlayerPrefs.SetInt("clearedLevel", 0);
        }*/

        //PlayerPrefs.SetInt("IsFirstTimePlay", 1);

        PlayerPrefs.SetInt("PlayerLife", 5);
        PlayerPrefs.SetInt("PlayerBlade", 3);
        PlayerPrefs.SetInt("PlayerStone", 0);
        //PlayerPrefs.SetInt("clearedLevel", 0);
    }
}
