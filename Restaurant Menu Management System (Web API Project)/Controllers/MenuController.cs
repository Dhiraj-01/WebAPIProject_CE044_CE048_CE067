using Newtonsoft.Json;
using Restaurant_Menu_Management_System__Web_API_Project_.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Restaurant_Menu_Management_System__Web_API_Project_.Controllers
{
    public class MenuController : ApiController
    {
        string constring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Lenovo\\OneDrive\\Documents\\ItemsDB.mdf;Integrated Security=True;Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False;";
        
        [Route("api/item/add")]
        [HttpPost]
        public string AddItem(Item item)
        {
            string result = "";
            try
            {
                SqlConnection con = new SqlConnection(constring);
                string query = @"INSERT INTO Items(Name, Description, Price, Type, Category, Status) Values(@name,@description,@price,@type,@category,@status)";
                SqlCommand com = new SqlCommand(query, con);

                com.Parameters.AddWithValue("@name", item.Name);
                com.Parameters.AddWithValue("@description", item.Description);
                com.Parameters.AddWithValue("@price", item.Price);
                com.Parameters.AddWithValue("@type", item.Type);
                com.Parameters.AddWithValue("@category", item.Category);
                com.Parameters.AddWithValue("@status", item.Status);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                result = "Item added successfully!!";

            }
            catch (Exception ex)
            {
                result = "Error";
            }
            return result;
        }

        [Route("api/item/delete/{id:int}")]
        [HttpDelete]
        public string DeleteItem(int id)
        {
            SqlConnection con = new SqlConnection(constring);
            string query = "DELETE FROM Items WHERE Id=@id";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@id", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            return "Item deleted!!";
        }

        [Route("api/item/get")]
        [HttpGet]
        public DataSet getItems()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(constring);
                string query = "SELECT * from Items";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return ds;
        }

        [Route("api/item/search/{id:int}")]
        [HttpGet]
        public DataSet SearchItem(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(constring);
                string Query = "SELECT * FROM Items WHERE Id=@id";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return ds;
        }

        [Route("api/item/update")]
        [HttpPut]
        public string UpdateItem(Item item)
        {
            string res = "";
            SqlConnection con = new SqlConnection(constring);
            string q = "UPDATE Items SET Name = @name,Description=@description,Price=@price,Type=@type,Category=@cg,Status=@st WHERE Id=@id";
            SqlCommand com = new SqlCommand(q, con);
            com.Parameters.AddWithValue("@name", item.Name);
            com.Parameters.AddWithValue("@description", item.Description);
            com.Parameters.AddWithValue("@price", item.Price);
            com.Parameters.AddWithValue("@type", item.Type);
            com.Parameters.AddWithValue("@cg", item.Category);
            com.Parameters.AddWithValue("@st", item.Status);
            com.Parameters.AddWithValue("@id", item.Id);
            con.Open();
            com.ExecuteNonQuery();
            res = "Item updated!!";
            con.Close();
            return res;
        }
    }
}
