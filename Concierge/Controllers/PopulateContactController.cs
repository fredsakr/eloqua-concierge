using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Concierge.Infrastructure;
using Concierge.Models;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;

namespace Concierge.Controllers
{
    public class PopulateContactController : Controller
    {
        public ActionResult Index()
        {
            SqlConnection myConnection = DataAccess.GetConnection();

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT TOP 1 * FROM Request ORDER BY 1 DESC", myConnection);
                SqlDataReader queryCommandReader = myCommand.ExecuteReader();

                DataTable dataTable = new DataTable();

                dataTable.Load(queryCommandReader);

                var subject = dataTable.Rows[0]["Subject"];
                var email = EmailHelper.GetEmailFromSubject(subject.ToString());

                var contact = ContactProvider.PopulateDetails(email, Request.Cookies);
                var json = Infrastructure.JsonSerializer<Contact>.DeSerialize(contact);

                myCommand = new SqlCommand(string.Format("UPDATE Request SET IsComplete = 1"), myConnection);
                myCommand.ExecuteNonQuery();
            }
            finally
            {
                myConnection.Close();
            }

            return View();
        }
    }
}
