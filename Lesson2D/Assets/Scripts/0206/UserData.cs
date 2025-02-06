using UnityEngine;

[System.Serializable]
public class UserData
{
    public string UserID;
    public string UserName;
    public string UserPassword;
    public string UserEmail;

    public UserData()
    {

    }

    public UserData(string userID, string userName, string userPassword, string userEmail)
    {
        UserID = userID;
        UserName = userName;
        UserPassword = userPassword;
        UserEmail = userEmail;
    }

    public string GetData() => $"{UserID}, {UserName}, {UserPassword}, {UserEmail}";

    public static UserData SetData(string rawUserDataString)
    {
        string[] userDataString = rawUserDataString.Split(',');

        return new UserData(userDataString[0], userDataString[1], userDataString[2], userDataString[3]);
    }


}
