using UnityEngine;

public class DataSample : MonoBehaviour
{
    public UserData userData;

    private void Start()
    {
        //PlayerPrefs.SetString("UserID", userData.UserID);
        //PlayerPrefs.SetString("UserName", userData.UserName);
        //PlayerPrefs.SetString("UserPassword", userData.UserPassword);
        //PlayerPrefs.SetString("UserEmail", userData.UserEmail);
        //Debug.Log("Saved");

        //Debug.Log(PlayerPrefs.GetString("UserID"));

        PlayerPrefs.DeleteAll();
        Debug.Log("Deleted all");
    }
}
