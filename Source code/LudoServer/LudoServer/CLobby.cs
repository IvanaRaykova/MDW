using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using LudoServer;
using System.Timers;
using System.Runtime.Serialization;
using System.ServiceModel;




namespace LudoServer

{
    [ServiceBehavior(InstanceContextMode =  InstanceContextMode.Single)]
    public class CLobby: ILobby
    {
        datahelper DBhelper;

        private List<Player> players;
        private static readonly List<ILobbyCallBack> subscribers = new List<ILobbyCallBack>();
        private static readonly List<ILobbyCallBack> GameLobbySubscribers = new List<ILobbyCallBack>();


        public CLobby()
        {
            players = new List<Player>();
            DBhelper = new datahelper();

         }

        bool Login(string username, string password)
        {
            Player player = DBhelper.IsUser(username, password);

            if (player != null)
            {
                foreach (Player item in players)
                {
                    return false;
                }
                players.Add(player);
                FireEvent(player.name);
                return true;

            }
            return false;
        }

        bool Subscribe()
        {
            try
            {
                ILobbyCallBack lobbycallback = OperationContext.Current.GetCallbackChannel<ILobbyCallBack>();
                if (!subscribers.Contains(lobbycallback))

                    subscribers.Add(lobbycallback);
                return true;
            }

            catch
            {
                return false;
            }
        }

        bool Unsubscribe()
        {
            try
            {
                ILobbyCallBack callback = OperationContext.Current.GetCallbackChannel<ILobbyCallBack>();
                if (!subscribers.Contains(callback))
                    subscribers.Remove(callback);
                return true;
            }
            catch
            {

                return false;
            }
        }

        void AddMessage(string playerName, string message)
        {
            subscribers.ForEach(delegate(ILobbyCallBack lobbycallback)
            {
                if (((ICommunicationObject)lobbycallback).State == CommunicationState.Opened)
                {
                    lobbycallback.onMessageAdded(DateTime.Now, playerName, message);
                }
                else
                {
                    subscribers.Remove(lobbycallback);
                }
            }
            );
        }

        public void Register(string username, string password)
        {
            DBhelper.RegisterPlayer(username, password);
        }

        public List<Player> GetOnlinePlayers()
        {
            return players;
        }

        public void FireEvent(string playerName)
        {
            subscribers.ForEach(delegate(ILobbyCallBack lobbycallback)
            {
                if (((ICommunicationObject)lobbycallback).State == CommunicationState.Opened)
                {
                    lobbycallback.OnOnline(playerName);
                }

                else
                {
                    subscribers.Remove(lobbycallback);
                }
            }
            );
        }

        public bool JoinGameSub()
        {
            try
            {
                ILobbyCallBack lobbycallback = OperationContext.Current.GetCallbackChannel<ILobbyCallBack>();
                if (!GameLobbySubscribers.Contains(lobbycallback))
                    GameLobbySubscribers.Add(lobbycallback);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void AddMessageGame(string playerName, string message)
        {
            GameLobbySubscribers.ForEach(delegate(ILobbyCallBack lobbycallback)
            {
                if (((ICommunicationObject)lobbycallback).State == CommunicationState.Opened)
                {
                    lobbycallback.onMessageAdded(DateTime.Now, playerName, message);
                }
                else
                {
                    GameLobbySubscribers.Remove(lobbycallback);
                }
            });
        }
    }


}