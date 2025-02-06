using UnityEngine;

public class UserDataSystem : MonoBehaviour
{
    public UserData data01;
    public UserData data02;

    private void Start()
    {
        data01 = new UserData();
        data02 = new UserData("sample0206", "tester", "123456", "tester@unity.com");

        string data_value = data02.GetData();
        Debug.Log(data_value);

        PlayerPrefs.SetString("UserData01", data_value);

        data01 = UserData.SetData(data_value);

        Debug.Log(data01.GetData());
    }
}
