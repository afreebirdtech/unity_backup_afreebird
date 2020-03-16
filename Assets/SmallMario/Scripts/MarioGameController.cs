using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioGameController : MonoBehaviour
{
    public static MarioGameController instance;

    public AudioSource source;
    public AudioClip DiedSound, JumpSound, TreasureSound, FlagSound;

    int treasureNum = 0;
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public void ChangeScene(string scene)
    {
        treasureNum = 0;
        SceneManager.LoadScene(scene);
    }

    public void GetOneTreasure()
    {
        treasureNum++;
    }

    public bool hasThree()
    {
        return treasureNum == 3;
    }

    public int showTreasureNumber()
    {
        return treasureNum;
    }

    public void PlayDiedSound()
    {
        source.clip = DiedSound;
        source.Play();
    }

    public void PlayJumpSound()
    {
        source.clip = JumpSound;
        source.Play();
    }

    public void PlayTreasureSound()
    {
        source.clip = TreasureSound;
        source.Play();
    }

    public void PlayFlagSound()
    {
        source.clip = FlagSound;
        source.Play();
    }
}
