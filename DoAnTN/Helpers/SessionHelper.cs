using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using DoAnTN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnTN.Helpers
{
    public static class SessionHelper
    {
        public static void SetSession(this ISession session, string key, object ojb)
        {
            session.SetString(key, JsonConvert.SerializeObject(ojb));
        }
        public static T GetSession<T>(this ISession session, string key)
        {
            var valueSession = session.GetString(key);
            var result = valueSession == null ? default : JsonConvert.DeserializeObject<T>(valueSession);
            return result;
        }
    }
}
