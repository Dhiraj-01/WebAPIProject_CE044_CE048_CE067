using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Restaurant_Menu_Management_System__Client_.Models;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Restaurant_Menu_Management_System__Client_.Controllers
{
    public class ItemController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        private string url = "https://localhost:44364/api/item/";

        // GET: Item
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, url + "get");

            var response = await client.SendAsync(msg);
            if (response.IsSuccessStatusCode)
            {
                var responseStream = response.Content.ReadAsStringAsync().Result;
                // var res = JObject.Parse(responseStream);
                // return View(Json(res, JsonRequestBehavior.AllowGet));

                var jsonObject = JObject.Parse(responseStream)["Table"];
                var str = JsonConvert.SerializeObject(jsonObject);
                var res = JsonConvert.DeserializeObject<IEnumerable<Item>>(str);
                return View(res);
                // return View(Json(res, JsonRequestBehavior.AllowGet));
            }
            else
            {
                var res = Array.Empty<Item>();
                return View(res);
            }
        }

        // GET: Item/Details/5
        public async System.Threading.Tasks.Task<ActionResult> Details(int id)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, url + "search/" + id);
            var response = await client.SendAsync(msg);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = response.Content.ReadAsStringAsync().Result;
                var jsonObject = JObject.Parse(responseStream)["Table"];
                var str = JsonConvert.SerializeObject(jsonObject);
                var res = JsonConvert.DeserializeObject<IEnumerable<Item>>(str);
                foreach (Item r in res)
                {
                    if (r.Id == id)
                    {
                        return View(r);
                    }
                }
                return View();
            }
            else
            {
                return View();
            }
        }

        // GET: Item/
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Item application = new Item();
                // application.Id = Int32.Parse(collection["Id"]);
                application.Description = collection["Description"];
                application.Category = collection["Category"];
                application.Name = collection["Name"];
                application.Price = Int32.Parse(collection["Price"]);
                application.Status = collection["Status"];
                application.Type = collection["Type"];

                var myContent = JsonConvert.SerializeObject(application);
                var stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url + "add", stringContent);
                string result = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public async System.Threading.Tasks.Task<ActionResult> Edit(int id)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, url + "get");
            var response = await client.SendAsync(msg);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = response.Content.ReadAsStringAsync().Result;
                // var res = JObject.Parse(responseStream);
                // return View(Json(res, JsonRequestBehavior.AllowGet));

                var jsonObject = JObject.Parse(responseStream)["Table"];
                var str = JsonConvert.SerializeObject(jsonObject);
                var res = JsonConvert.DeserializeObject<IEnumerable<Item>>(str);

                foreach(Item r in res)
                {
                    if(r.Id == id) {
                        return View(r);
                    }
                }
                return View();
                // return View(Json(res, JsonRequestBehavior.AllowGet));
            }
            else
            {
                var res = Array.Empty<Item>();
                return View(res);
            }
        }

        // POST: Item/Edit/5
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Item application = new Item();
                application.Id = Int32.Parse(collection["Id"]);
                application.Description = collection["Description"];
                application.Category = collection["Category"];
                application.Name = collection["Name"];
                application.Price = Int32.Parse(collection["Price"]);
                application.Status = collection["Status"];
                application.Type = collection["Type"];

                var myContent = JsonConvert.SerializeObject(application);
                var stringContent = new StringContent(myContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(url + "update", stringContent);
                string result = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public async System.Threading.Tasks.Task<ActionResult> Delete(int id)
        {
            HttpRequestMessage msg = new HttpRequestMessage(HttpMethod.Get, url + "get");
            var response = await client.SendAsync(msg);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = response.Content.ReadAsStringAsync().Result;
                // var res = JObject.Parse(responseStream);
                // return View(Json(res, JsonRequestBehavior.AllowGet));

                var jsonObject = JObject.Parse(responseStream)["Table"];
                var str = JsonConvert.SerializeObject(jsonObject);
                var res = JsonConvert.DeserializeObject<IEnumerable<Item>>(str);

                foreach (Item r in res)
                {
                    if (r.Id == id)
                    {
                        return View(r);
                    }
                }
                return View();
                // return View(Json(res, JsonRequestBehavior.AllowGet));
            }
            else
            {
                var res = Array.Empty<Item>();
                return View(res);
            }
        }

        // POST: Item/Delete/5
        [HttpDelete]
        public async System.Threading.Tasks.Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var response = await client.DeleteAsync(url + "delete/" + id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
