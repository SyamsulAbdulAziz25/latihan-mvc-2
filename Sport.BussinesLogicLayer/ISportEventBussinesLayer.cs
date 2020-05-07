using SportEvent.Core;
using SportEvent.Core.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportEvent.Controllers
{/// <summary>
/// 
/// </summary>
    public interface ISportEventBussinesLayer
    {
        IEnumerable<SportEventOutput> GetActiveEvents();
        SportEventOutput FindUser(string id);
        Event FindUserForDelete(string id);
        IEnumerable<Event> GetActiveAllEvents();
        void InsertUser(Event @event);
        void UpdateUser(string id, SportEventOutput @sportEventOutput);
        void DeleteUser(String id);
        //tanya
        //event EventHandler PoweringUp;
    }
}