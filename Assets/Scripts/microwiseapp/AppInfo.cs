using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class AppInfo : MonoBehaviour {

    public string appName;
    public string version;
    public string type;

    private ConnController conn = new ConnController();

    void Start()
    {
        Application.runInBackground = true;
        conn.init(this);
    }

    void OnDestroy()
    {
        conn.close();
    }

	public void buildTagBat () {
        string filePath = Path.Combine(Application.streamingAssetsPath, "tag.bat");
        StringBuilder stringBuilder = new StringBuilder("@echo off");
        stringBuilder.Append("\necho name:" + appName);
        stringBuilder.Append("\necho version:" + version);
        stringBuilder.Append("\necho type:" + type);
        stringBuilder.Append("\necho.");

        stringBuilder.Append("\n\ngit checkout master \ngit pull \necho. \n \ngit add -A");
        stringBuilder.Append("\ngit commit -m \"" + version + "\"");
        stringBuilder.Append("\ngit push \necho.");

        stringBuilder.Append("\n\ngit tag -d " + version);
        stringBuilder.Append("\ngit push origin :" + version);
        stringBuilder.Append("\ngit tag " + version);
        stringBuilder.Append("\ngit push origin " + version);
        stringBuilder.Append("\necho. \n\ngit log --decorate -3");

        saveFile(filePath, stringBuilder.ToString());
	}

    private void saveFile(string path, string content){
        FileStream fs = new FileStream(path, FileMode.Create);

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(content);
        fs.Write(bytes, 0, bytes.Length);
        fs.Close();
    }
}
