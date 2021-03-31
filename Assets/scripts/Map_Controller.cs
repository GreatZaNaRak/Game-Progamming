using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Controller : MonoBehaviour
{
    public Player_Controller Player;

    public void enterMap0()
    {
        Player.setCurrenMapIndex(0);
        onEnter();
    }

    public void exitMap0()
    {
        onExit();
        Player.setCurrenMapIndex(-1);
    }
    public void enterMap1()
    {
        Player.setCurrenMapIndex(1);
        onEnter();
    }

    public void exitMap1()
    {
        onExit();
        Player.setCurrenMapIndex(-1);
    }

    public void enterMap2()
    {
        Player.setCurrenMapIndex(2);
        onEnter();
    }

    public void exitMap2()
    {
        onExit();
        Player.setCurrenMapIndex(-1);
    }

    private void onEnter()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(130, 130);
    }

    private void onExit()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
    }

}
