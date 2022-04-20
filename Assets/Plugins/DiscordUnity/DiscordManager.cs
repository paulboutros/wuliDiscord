using UnityEngine;
using System;
using System.Linq;
using DiscordUnity;
using DiscordUnity.API;
using DiscordUnity.State;

public class DiscordManager : MonoBehaviour, IDiscordServerEvents
{
    // see  discord  aplliction  / bot  .. token
    string botToken = "OTY1MzIzNDQ1MzM0MzMxNDEy.YlxhhA.-2K4vW-JNEMci2fFmy7xCsoMINg";
    public DiscordLogLevel logLevel = DiscordLogLevel.None;

    #region Singleton
    public static DiscordManager Singleton { get; private set; }

    protected virtual void Awake()
    {
        if (Singleton != null)
        {
            Destroy(gameObject);
            return;
        }

        Singleton = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        if (Singleton == this)
        {
            DiscordAPI.UnregisterEventsHandler(this);
            DiscordAPI.Stop();
            Singleton = null;
        }
    }
    #endregion

    protected virtual async void Start()
    {
        Debug.Log("Starting DiscordUnity ...");
        DiscordAPI.Logger = new DiscordLogger(logLevel);
        DiscordAPI.RegisterEventsHandler(this);
        await DiscordAPI.StartWithBot(botToken);
        Debug.Log("DiscordUnity started.");
    }

    private void Update()
    {
        DiscordAPI.Update();
    }

    public void OnServerJoined(DiscordServer server)
    {
        server.Channels.Values.FirstOrDefault(x => x.Type == DiscordUnity.Models.ChannelType.GUILD_TEXT)?.CreateMessage("Hello World!", null, null, null, null, null, null);
    }

    public void OnServerUpdated(DiscordServer server)
    {

    }

    public void OnServerLeft(DiscordServer server)
    {

    }

    public void OnServerBan(DiscordServer server, DiscordUser user)
    {

    }

    public void OnServerUnban(DiscordServer server, DiscordUser user)
    {

    }

    public void OnServerEmojisUpdated(DiscordServer server, DiscordEmoji[] emojis)
    {

    }

    public void OnServerMemberJoined(DiscordServer server, DiscordServerMember member)
    {

    }

    public void OnServerMemberUpdated(DiscordServer server, DiscordServerMember member)
    {

    }

    public void OnServerMemberLeft(DiscordServer server, DiscordServerMember member)
    {

    }

    public void OnServerMembersChunk(DiscordServer server, DiscordServerMember[] members, string[] notFound, DiscordPresence[] presences)
    {

    }

    public void OnServerRoleCreated(DiscordServer server, DiscordRole role)
    {

    }

    public void OnServerRoleUpdated(DiscordServer server, DiscordRole role)
    {

    }

    public void OnServerRoleRemove(DiscordServer server, DiscordRole role)
    {

    }

    #region Logger
    public enum DiscordLogLevel
    {
        None = 0,
        Error = 1,
        Warning = 2,
        Debug = 3
    }

    private class DiscordLogger : DiscordUnity.ILogger
    {
        private readonly DiscordLogLevel level;

        public DiscordLogger(DiscordLogLevel level)
        {
            this.level = level;
        }

        public void Log(string log)
        {
            if (level >= DiscordLogLevel.Debug)
                Debug.Log(log);
        }

        public void LogWarning(string log)
        {
            if (level >= DiscordLogLevel.Warning)
            {
                Debug.LogWarning(log);
            }
        }

        public void LogError(string log, Exception exception = null)
        {
            if (level >= DiscordLogLevel.Error)
            {
                Debug.LogError(log);
                Debug.LogError(exception);
            }
        }
    }
    #endregion
}
