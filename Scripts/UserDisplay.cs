using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameJolt.API;
using GameJolt.UI;
using TMPro;
public class UserDisplay : MonoBehaviour {
    public Button signin_button;
    public Image user_image;
    public TextMeshProUGUI user_name;
    // Use this for initialization
    void Start () {
        if (GameJoltAPI.Instance == null)
        {
            gameObject.SetActive(false);
            return;
        }
        Debug.Log(GameJoltAPI.Instance.CurrentUser);
	}
    float downloadWait = 0;
	// Update is called once per frame
	void Update () {
        if (GameJoltAPI.Instance == null)
            return;
        if (GameJoltAPI.Instance.CurrentUser == null)
        {
            signin_button.gameObject.SetActive(true);
            user_image.gameObject.SetActive(false);
            user_name.gameObject.SetActive(false);
        }
        else
        {
            signin_button.gameObject.SetActive(false);
            if (user_image != null && GameJoltAPI.Instance.CurrentUser.Avatar != null)
                user_image.sprite = GameJoltAPI.Instance.CurrentUser.Avatar;
            if (user_name != null)
                user_name.text = GameJoltAPI.Instance.CurrentUser.Name;
            if (GameJoltAPI.Instance.CurrentUser.Avatar == null)
            {
                if (downloadWait <= 0)
                {
                    GameJoltAPI.Instance.CurrentUser.DownloadAvatar();
                    downloadWait = 120f;
                }
                downloadWait -= Time.deltaTime;
            }
                

            user_image.gameObject.SetActive(true);
            user_name.gameObject.SetActive(true);
        }

    }

    public void ShowLogin()
    {
        GameJoltUI.Instance.ShowSignIn(
        (bool signInSuccess) => {
            Debug.Log(string.Format("Sign-in {0}", signInSuccess ? "successful" : "failed or user's dismissed the window"));
            signin_button.gameObject.SetActive(!signInSuccess);
            Debug.Log(GameJoltAPI.Instance.CurrentUser);
        },
        (bool userFetchedSuccess) => {
            Debug.Log(string.Format("User details fetched {0}", userFetchedSuccess ? "successfully" : "failed"));
            Debug.Log(GameJoltAPI.Instance.CurrentUser);
        });
        Debug.Log(GameJoltAPI.Instance.CurrentUser);
    }
}
