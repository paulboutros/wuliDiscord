using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

 using UnityEngine.Networking;
 
using System.Net;
 
 
using System.IO;
using System;
using System.Threading.Tasks;

public class DiscordController : MonoBehaviour
{

    public string loginText;
    public string getUrl;
    public string postUrl;

    // find it in  Dicord application Auth2
    // client secret :DpCOc0lq40N2KcOSGikVEQofgoF-irAH
    //Git Hub:
    //https://github.com/business-helper/auto-fill-v2/blob/c3ec06a695d56a296cb43fff55c03c335b5a1ee3/src/js/pages/signin.js#L106
    //authorixaion code  = AcOLG7GJjoNDIXKREG0NT9OozvNK0r
    //                     AcOLG7GJjoNDIXKREG0NT9OozvNK0r
    // client secret X7q0ISLXVZMF9fyRXgRe4bS482LZItSy
    //Discord provided url , you must open the url and press AUTHORIZE
    //https://discord.com/api/oauth2/authorize?client_id=965323445334331412&redirect_uri=http%3A%2F%2F127.0.0.1&response_type=code&scope=guilds%20identify

    public static string clientIdstring = "965323445334331412";
public static System.Int64 clientId = 965323445334331412;
    public   void Button_postRequest( string URL)
    { // ser wuli server ID: 947487866622201886
    
 
    
      //    string URL =  "https://discord.com/oauth2/authorize?client_id=965323445334331412&redirect_uri=http%3A%2F%2F127.0.0.1&response_type=code&scope=guilds%20identify" ;
        string DATA = @"{""object"":{""name"":""Name""}}";
 
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.ContentLength = DATA.Length;
        StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
        requestWriter.Write(DATA);
        requestWriter.Close();

        try
        {
            WebResponse webResponse = request.GetResponse();
            Stream webStream = webResponse.GetResponseStream();
            StreamReader responseReader = new StreamReader(webStream);
            string response = responseReader.ReadToEnd();
           Debug.Log(response);
            responseReader.Close();
        }
        catch (Exception e)
        {
            Debug.Log("-----------------");
           Debug.Log(e.Message);
        }

    }

     

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }




    string webhook_link =
        "https://discord.com/api/webhooks/966042841149210695/q2bjyEd72ZFO3o0S2axPn9bCJPIcQsl5mjzOQLA9xBP0gb1cQfMGxTUrWpBHtpxql_Ek";
        //"https://discord.com/api/webhooks/965571759489318942/hzf5VgPtOkgcMLE-HZjY8bx-_qHk-6DJ-8ePxvxSH3Sxb_QnH5Do8P0UYOsKJVsiGrai";
    //"https://discord.com/api/webhooks/779882899339739196/ETwncddV1Xar890W59khZn6xvs7PnhzYMGHPm7dPjljpaTyzlgRHpRS-ZXDJehizUjS_";
    public Discord.Discord discord;
    // Start is called before the first frame update


    void Start () {

        GerDiscordData();
    }
    void GerDiscordData()
    {


 // Call 
    // authorixaion code  = AcOLG7GJjoNDIXKREG0NT9OozvNK0r
   //     Application.OpenURL( "https://discord.com/api/oauth2/authorize?client_id=966257659374350346&redirect_uri=https%3A%2F%2Fwww.google.com%2F&response_type=code&scope=guilds%20identify" );
//*******
       //Post_objectCreation();
       
        
     //  Application.OpenURL("https://discord.com/invite/TZszHsf92c");


  
        /*
        StartCoroutine(SendWebhook(webhook_link, "Some Message To the Server", (success) =>
        {
            if (success)
                Debug.Log("Message Sent");
        }));
        //***********
        */

       

         discord = new Discord.Discord(clientId, (System.UInt64)Discord.CreateFlags.Default ); // client ID


    

//discord.GetHas
 //let members =  discord.guilds.get(ID).members();

        /*
      var activityManager  =  discord.GetActivityManager();
      var activity = new Discord.Activity{
         Details = " on te desert Map",
         State  = " Playing GAme Alone" 
       };

        
      activityManager.UpdateActivity(  activity, (res) => {
        if ( res == Discord.Result.Ok ){
          Debug.Log("Discord status set");
        }else{

            Debug.Log("Discord status failed");
        }

      });
      */


       
       /*
       activityManager.SendInvite(clientId, Discord.ActivityActionType.Join, "Come play!", (result) =>
       {
           if (result == Discord.Result.Ok)
           {
               Debug.Log("Successfully joined !");
           }
           else
           {
               Debug.Log("Failed to join");
           }
       });
       */
       // testing User info:
       //**********************************************************************************
       var userManager = discord.GetUserManager();
// GetCurrentUser will error until this fires once.
userManager.OnCurrentUserUpdate += () => {
  var currentUser = userManager.GetCurrentUser();
 Debug.Log("username => " +currentUser);
   Debug.Log("username => " +currentUser.Username);
  Debug.Log("ID  => " +currentUser.Id);
  Debug.Log("Discriminator => " +currentUser.Discriminator);
  Debug.Log("Avatar => " +currentUser.Avatar);

 
   
   Program.MainX();
};

 
  TestFecthUserData();
 
    }

    public void Button_GetRequest(  string url ) {
        StartCoroutine(GetRequest(url));
    }

    IEnumerator SendWebhook(string link, string message, System.Action<bool> action)
    {
        WWWForm form = new WWWForm();
        form.AddField("content", message);
        using (UnityWebRequest www = UnityWebRequest.Post(link, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                action(false);
            }
            else
                action(true);
        }
    }




    void TestFecthUserData(){

      System.Int64 clientId =  965323445334331412;
 var discord = new Discord.Discord(clientId, (System.UInt64)Discord.CreateFlags.Default);
var userManager = discord.GetUserManager();
  

//var tt = discord.GetUserManager().GetUser(965323445334331412,  (Discord.Result result, ref Discord.User user ) ;
 
userManager.GetUser( clientId  , (Discord.Result result, ref Discord.User user) =>
{
  
  if (result == Discord.Result.Ok)
  {
    
     Debug.Log("user fetched: " +  user.Bot);
  }
  else
  {
    Debug.Log("user fetch error:  " +  result);
  }
});

    

    }

    // Update is called once per frame
    void Update()
    {

      
         discord.RunCallbacks();
    }
}
