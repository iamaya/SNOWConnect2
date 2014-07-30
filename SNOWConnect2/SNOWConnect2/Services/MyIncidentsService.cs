using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNOWConnect2.Models.MyIncidents;

namespace SNOWConnect2
{
    public interface IMyIncidentsService
    {
        void GetMyIncidents(string domain, string username, string password, Action<RootObject> success, Action<Exception> error);
    }

    public class MyIncidentsService : IMyIncidentsService
    {
        ISNOWService _snowService = new SNOWService();

        public void GetMyIncidents(string domain, string username, string password, Action<RootObject> success, Action<Exception> error)
        {
            //    throw new NotImplementedException();
            string URL = string.Format("https://{0}/api/now/table/incident?sysparm_limit=5&sysparm_query=active=true^sys_created_by={1}", (domain ?? "empty") + ".service-now.com", username);
            _snowService.MakeRequest<RootObject>(URL, "GET", username, password, success, error);
        }
    }
}