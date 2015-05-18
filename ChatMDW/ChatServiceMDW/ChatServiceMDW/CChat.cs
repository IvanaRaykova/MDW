using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChatServiceMDW;
using System.Timers;

namespace ChatServiceMDW
{
   [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CChat : IChat,ILogin
    {
       DataHelper dataHelper;
       private List<Player> players;
       private static readonly List<IChatCallback> subscribers = new List<IChatCallback>();


       public CChat()
       {
           players = new List<Player>();
           dataHelper = new DataHelper();
       }

       bool ILogin.Login(string username,string pass)
       {
           //Player player   = datahelper.Isuser(username,password);
           Player player = new Player("iva");
           Player playerOne = new Player("toshko");
           Player playerTwo = new Player("zair");

           if (player != null)
           {
               foreach (Player item in players)
               {
                   if (item.name == username)
                   {
                       return false;
                   }
               }
               players.Add(player);
               return true;
           }
           return false;

       }
       bool IChat.Subscribe()
       {
           try
           {
               IChatCallback chatCallBack = OperationContext.Current.GetCallbackChannel<IChatCallback>();
               if (!subscribers.Contains(chatCallBack))
               
                   subscribers.Add(chatCallBack);
                   return true;
               
           }
           catch 
           {
               return false;
           }
       }
       bool IChat.UnSubscribe()
       {
           try
           {
               IChatCallback callback = OperationContext.Current.GetCallbackChannel<IChatCallback>();
               if (subscribers.Contains(callback))
                   subscribers.Remove(callback);
               return true;
           }
           catch
           {
               return false;
           }
       }
       void IChat.AddMessage(string playerName,string message)
       {
           subscribers.ForEach(delegate(IChatCallback callback)
           {
               if (((ICommunicationObject)callback).State == CommunicationState.Opened)
               {
                   callback.onMessageAdded(DateTime.Now, playerName, message);
               }
               else
               {
                   subscribers.Remove(callback);
               }
           });

       }
      }
}
