using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace ZhengRSVP
{
    public class Event
    { 
        public Int64 Id { get; set; }
        public String HostPerson { get; set; } 
        public String Eventname { get; set; }      
        public String Eventaddress { get; set; }      
        public String Maxpeople { get; set; }     
        public DateTime Eventdate { get; set; }    
        public DateTime Deadline { get; set; }
        public string nameOfEvent { get { return Eventname; } }
        public string info { get { return "Address: " + Eventaddress; } }
    }

    public class User
    {
        public Int64 Id { get; set; } 
        public String Name { get; set; }  
        public String EmailAddress { get; set; } 
        public String Password { get; set; } 
        public String PhoneNumber { get; set; }
    }
   
    public class DAL
    {
     
        public DAL()
        {
            
        }

        public void AddUser(User user)
        {
            HttpClient client;
            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/json");
                var content = JsonConvert.SerializeObject(user);
                var buff = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buff);
                byteContent.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage resp =
                    client.PostAsync("http://10.0.2.2:63357/api/User", byteContent).Result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddEvent(Event events)
        {
            HttpClient client;
            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/json");
                var content = JsonConvert.SerializeObject(events);
                var buff = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buff);
                byteContent.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage resp =
                    client.PostAsync("http://10.0.2.2:63357/api/Event", byteContent).Result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Event> GetAllEvent()
        {
            HttpClient client;
            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/json");
                List<Event> events = new List<Event>();
                var resp = client.GetAsync("http://10.0.2.2:63357/api/Event").Result;
                if (resp.IsSuccessStatusCode)
                {
                    var content = resp.Content.ReadAsStringAsync().Result;
                    events = JsonConvert.DeserializeObject<List<Event>>(content);
                }
                return events;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool AuthenticateUser(string id, string pw)
        {

            HttpClient client;
            const string apiUrl = "api/values";
            string user = id + ":" + pw;
            StringContent queryString =
                new StringContent(user, Encoding.UTF8, "application/json");
            var authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(user));
            client = new HttpClient();
            client.BaseAddress = new Uri("http://10.0.2.2:63357");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeader);
            var json = JsonConvert.SerializeObject(user);
            HttpResponseMessage resp = client.PostAsync(apiUrl, queryString).Result;

            if (resp.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }

    }
}
