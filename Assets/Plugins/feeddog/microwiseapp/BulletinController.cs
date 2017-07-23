using UnityEngine;
using LitJson;

public class BulletinController : MonoBehaviour
{
    void Start()
    {
        AppInfo.instance.conn.addMessageListener(processMessage);
    }

    private void processMessage(JsonData json)
    {
        if (json["monitorId"] == null)
        {
            json["monitorId"] = "";
        }
        //Debug.Log(json.ToJson());
        if(json["contentBean"]["command"].ToString() == "showBulletin")
        {
            showMessage(json["contentBean"]["args"][0].ToString());
        }
    }

    private void showMessage(string str)
    {
        Debug.Log(str);
    }
}
