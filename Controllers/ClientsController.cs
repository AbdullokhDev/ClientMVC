using Newtonsoft.Json;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClientMVC.Models;

namespace ClientMVC.Controllers
{
    public class ClientsController : Controller
    {
        // GET: Clients
        public async Task<IActionResult> Index()
        {
            string Baseurl = "http://172.31.84.38";
            List<Client> ClientInfo = new List<Client>();
            using (var myClient = new HttpClient())
            {
                // Passing service base url
                myClient.BaseAddress = new Uri(Baseurl);
                myClient.DefaultRequestHeaders.Clear();

                // Define request data format
                myClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );

                // Sending request to get clients data from REST service
                HttpResponseMessage Res = await myClient.GetAsync("/clients");

                // Checking the response is successfull or not
                if (Res.IsSuccessStatusCode)
                {
                    // Storing the response data 
                    var ClientResponse = Res.Content.ReadAsStringAsync().Result;

                    // Deserializing the response received from web api
                    ClientInfo = JsonConvert.DeserializeObject<List<Client>>(ClientResponse);
                }
                return View(ClientInfo);
            }
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            string Baseurl = "http://172.31.84.38";
            Client ClientInfo = new Client();
            using (var myClient = new HttpClient())
            {
                // Passing service base url
                myClient.BaseAddress = new Uri(Baseurl);
                myClient.DefaultRequestHeaders.Clear();

                // Define request data format
                myClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );

                // Sending request to get client data from REST service
                HttpResponseMessage Res = await myClient.GetAsync("/clients/" + id);

                // Checking the response is successfull or not
                if (Res.IsSuccessStatusCode)
                {
                    // Storing the response data
                    var ClientResponse = Res.Content.ReadAsStringAsync().Result;

                    // Deserializing the response received from web api
                    ClientInfo = JsonConvert.DeserializeObject<Client>(ClientResponse);
                    return View(ClientInfo);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,firstName,lastName,phoneNumber,email,address")] Client client)
        {
            string Baseurl = "http://172.31.84.38";
            Client ClientInfo = new Client();
            using (var myClient = new HttpClient())
            {
                if (ModelState.IsValid)
                {
                    // Passing service base url
                    myClient.BaseAddress = new Uri(Baseurl);
                    // myClient.DefaultRequestHeaders.Clear();

                    // Define request format
                    myClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json")
                    );

                    // Serialize client data to Json
                    var ClientData = JsonConvert.SerializeObject(client);
                    var stringContent = new StringContent(ClientData, Encoding.UTF8, "application/json");

                    // Sending request with client data to create new client
                    HttpResponseMessage Res = await myClient.PostAsync("/clients/", stringContent);

                    if (Res.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                return View(client);
            }
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            string Baseurl = "http://172.31.84.38";
            Client ClientInfo = new Client();
            using (var myClient = new HttpClient())
            {
                // Passing service base url
                myClient.BaseAddress = new Uri(Baseurl);
                myClient.DefaultRequestHeaders.Clear();

                // Define request data format
                myClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );

                // Sending request to get client data from REST service
                HttpResponseMessage Res = await myClient.GetAsync("/clients/" + id);

                // Checking the response is successfull or not
                if (Res.IsSuccessStatusCode)
                {
                    // Storing the response data
                    var ClientResponse = Res.Content.ReadAsStringAsync().Result;

                    // Deserializing the response received from web api
                    ClientInfo = JsonConvert.DeserializeObject<Client>(ClientResponse);
                    return View(ClientInfo);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,firstName,lastName,phoneNumber,email,address")] Client client)
        {
            string Baseurl = "http://172.31.84.38";
            Client ClientInfo = new Client();
            using (var myClient = new HttpClient())
            {
                if (ModelState.IsValid)
                {
                    // Passing service base url
                    myClient.BaseAddress = new Uri(Baseurl);
                    // myClient.DefaultRequestHeaders.Clear();

                    // Define request format
                    myClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json")
                    );

                    // Serialize client data to Json
                    var ClientData = JsonConvert.SerializeObject(client);
                    var stringContent = new StringContent(ClientData, Encoding.UTF8, "application/json");

                    // Sending request with client data to create new client
                    HttpResponseMessage Res = await myClient.PutAsync("/clients/" + id, stringContent);

                    if (Res.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                return View(client);
            }
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            string Baseurl = "http://172.31.84.38";
            Client ClientInfo = new Client();
            using (var myClient = new HttpClient())
            {
                // Passing service base url
                myClient.BaseAddress = new Uri(Baseurl);
                myClient.DefaultRequestHeaders.Clear();

                // Define request data format
                myClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );

                // Sending request to get client data from REST service
                HttpResponseMessage Res = await myClient.GetAsync("/clients/" + id);

                // Checking the response is successfull or not
                if (Res.IsSuccessStatusCode)
                {
                    // Storing the response data
                    var ClientResponse = Res.Content.ReadAsStringAsync().Result;

                    // Deserializing the response received from web api
                    ClientInfo = JsonConvert.DeserializeObject<Client>(ClientResponse);
                    return View(ClientInfo);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string Baseurl = "http://172.31.84.38";
            Client ClientInfo = new Client();
            using (var myClient = new HttpClient())
            {
                // Passing service base url
                myClient.BaseAddress = new Uri(Baseurl);
                // myClient.DefaultRequestHeaders.Clear();

                // Define request format
                myClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json")
                );

                // Sending request with client data to create new client
                HttpResponseMessage Res = await myClient.DeleteAsync("/clients/" + id);

                if (Res.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return BadRequest();
                }
            }            
        }
    }
}
