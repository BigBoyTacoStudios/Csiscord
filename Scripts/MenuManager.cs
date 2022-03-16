using UnityEngine;
using System.Diagnostics;
using System.IO;

public class MenuManager : MonoBehaviour
{
    [Header("Main")]
    //menu items
    public GameObject SignUp;
    public GameObject LogIn;
    public GameObject LoadingCanvas;
    public GameObject Chat;
    public GameObject ThanksForSign;
    [Header("Chat Stuff")]
    public GameObject Chat_Home;
    //strings
    private string filePath;
    private string Username;
    private string tempFilePath;

    public void Start()
    {
        filePath = Application.dataPath;
    }
    //functions
    public void ToLogIn()
    {
        SignUp.SetActive(false);
        LogIn.SetActive(true);
    }
    public void ToSignUp()
    {
        SignUp.SetActive(true);
        LogIn.SetActive(false);
    }
    //load chat scene
    public void ToChat()
    {
        /*LogIn.SetActive(false);
        SignUp.SetActive(false);*/
        LoadingCanvas.SetActive(true);
        //CreateDatafile();
        //changes scenes
        //Chat.SetActive(true);
        ThanksForSign.SetActive(true);
        LoadingCanvas.SetActive(false);
        
    }
    public void CreateDatafile()
    {
        //creates temp file path under ciscord_data
        Directory.CreateDirectory(filePath + "/.temp");
        //gets users info
        Username = "test";
        tempFilePath = filePath + "/.temp/Userdat.txt";
        //writes info about our user
        using (StreamWriter writer = new StreamWriter(tempFilePath, false))
        {
            writer.WriteLine(Username);
            writer.Flush();
        }
    }
}