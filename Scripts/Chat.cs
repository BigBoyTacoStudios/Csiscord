using Firebase;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Chat : MonoBehaviour
{
    [Header("Chat stuff")]
    public InputField Message;
    public Text Username;
    [Header("Firebase")]
    public Login_Signup_Manager auth;
    [Header("Random stuff idk")]
    public GameObject Login;
    public GameObject ChatBox;
    public float refreshTime;
    //message stuff
    [Header("Message Stuff")]
    public Vector3 MessageScale;
    public Vector3 MessagePos;
    private string MessageContents;
    public Text MessageError;
    private int MessageObjectName = 0;

    //starts script when somone logs in
    public void Init()
    {
        Login.SetActive(false);
        ChatBox.SetActive(true);
        //Get varibles
        auth = FindObjectOfType<Login_Signup_Manager>();
        //Put the user varible
        Username.text = auth.User.DisplayName;
        //1s delay, repeat every 1s
        InvokeRepeating("RefreshChat", refreshTime, refreshTime);
        Debug.Log("chat Script Initialized");
    }
    //check if anything new needs to be displayed
    public void RefreshChat()
    {
        //code to refresh chat goes here
        StartCoroutine(CheckIfEmpty(Message.text));
    }
    //creates a text object to display the message recieved/sent
    public void CreateMessageObject()
    {
        //creates message object
        GameObject MessageObject = new GameObject();
        MessageObject.SetActive(false);
        MessageObject.name = MessageObjectName.ToString();
        MessageObject.AddComponent<Text>();
        MessageObject.AddComponent<CanvasRenderer>();
        MessageObject.AddComponent<RectTransform>();
        MessageObject.transform.localScale = MessageScale;
        MessageObject.transform.position = MessagePos;
        Text MessageText = MessageObject.GetComponent<Text>();
        MessageObject.SetActive(true);
        MessageObjectName += 1;
        //creates UI that shows which user sent message
        GameObject MessageObjectUsername = new GameObject();
        MessageObjectUsername.SetActive(false);
        MessageObjectUsername.name = MessageObjectName.ToString() + "User";
        MessageObjectUsername.AddComponent<Text>();
        Text UserNameText = MessageObjectUsername.GetComponent<Text>();
        MessageObjectUsername.AddComponent<CanvasRenderer>();
        MessageObjectUsername.AddComponent<RectTransform>();
        MessageObjectUsername.SetActive(true);
    }

    public IEnumerator CheckIfEmpty(string _MessageText)
    {
        if (_MessageText.Length < 1)
        {
            MessageError.text = "Message too short, must have atleast 1 letter";
            yield return new WaitForSeconds(4);
        }
    MessageError.text = "";
    }

}