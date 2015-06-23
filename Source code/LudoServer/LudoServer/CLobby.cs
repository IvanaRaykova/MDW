using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LudoServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CLobby:ILobby,ILogin
 
 {
       DataHelper dataHelper;
       private List<User> users;
       private static readonly List<ILobbyCallback> subscribers = new List<ILobbyCallback>();
       private static readonly List<ILobbyCallback> privateSubscribers = new List<ILobbyCallback>();

       public CLobby()
       {
           users = new List<User>();
           dataHelper = new DataHelper();
       }

       bool ILogin.Login(string username,string pass)
       {
           User user = dataHelper.isUser(username,pass);
         
           if (user != null)
           {
               foreach (User item in users)
               {
                   if (item.name == username)
                   {
                       return false;
                   }
               }
               users.Add(user);
               FireEvent(user.name);
               return true;
           }
           return false;

       }
     
       bool ILobby.Subscribe()
       {
           try
           {
               ILobbyCallback chatCallBack = OperationContext.Current.GetCallbackChannel<ILobbyCallback>();
               if (!subscribers.Contains(chatCallBack))
               
                   subscribers.Add(chatCallBack);
                   return true;
               
           }
           catch 
           {
               return false;
           }
       }
       bool ILobby.UnSubscribe()
       {
           try
           {
               ILobbyCallback callback = OperationContext.Current.GetCallbackChannel<ILobbyCallback>();
               if (subscribers.Contains(callback))
                   subscribers.Remove(callback);
               return true;
           }
           catch
           {
               return false;
           }
       }
       void ILobby.AddMessage(string userName,string message)
       {
           subscribers.ForEach(delegate(ILobbyCallback callback)
           {
               if (((ICommunicationObject)callback).State == CommunicationState.Opened)
               {
                   callback.onMessageAdded(DateTime.Now, userName, message);
                   
               }
               else
               {
                   subscribers.Remove(callback);
               }
           });

       }


       public void Register(string username, string password)
       {
           dataHelper.RegisterPlayer(username,password);
       }


       public List<User> GetOnlineUsers()
       {
           return users;
       }

       public void FireEvent(string playerName)
       {
           subscribers.ForEach(delegate(ILobbyCallback callback)
           {
               if (((ICommunicationObject)callback).State == CommunicationState.Opened)
               {
                   callback.OnOnline(playerName);

               }
               else
               {
                   subscribers.Remove(callback);
               }
           });

       }
       public bool PrivateSubscribe()
       {
           try
           {
               ILobbyCallback chatCallBack = OperationContext.Current.GetCallbackChannel<ILobbyCallback>();
               if (!privateSubscribers.Contains(chatCallBack))
                   privateSubscribers.Add(chatCallBack);
               return true;

           }
           catch
           {
               return false;
           }
       }


       public void AddPrivateMessage(string playerName, string message)
       {

           privateSubscribers.ForEach(delegate(ILobbyCallback callback)
           {
               if (((ICommunicationObject)callback).State == CommunicationState.Opened)
               {
                   callback.onMessageAdded(DateTime.Now, playerName, message);

               }
               else
               {
                   privateSubscribers.Remove(callback);
               }
           });
       }
    }

}
