using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{

    public string currentUser = "No Data";
    public int isCharSelected;

    void Start()
    {
        this.currentUser = PlayerPrefs.GetString("user", "No Data");
        this.isCharSelected = PlayerPrefs.GetInt("charSelect", 0);
    }

    void OnDestroy()
    {
        PlayerPrefs.SetString("user", currentUser);
        PlayerPrefs.SetInt("charSelect", isCharSelected);
        PlayerPrefs.Save();
    }

    public string getCurrentUser()
    {
        return this.currentUser;
    }

    public void setCurrentUser(string nText)
    {
        this.currentUser = nText;
    }

    public int getIsCharSelected()
    {
        return this.isCharSelected;
    }

    public void setIsCharSelected(int gg)
    {
        this.isCharSelected = gg;
    }
}
