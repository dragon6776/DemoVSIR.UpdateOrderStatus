using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace Demo.UpdateOrderStatus.XinhCaNgay.Models
{
    public class UpdateXCNOrderStatusService
    {
        private const string USERNAME = "VSIR";
        private const string PASSWORD = "5Q!p^AsJxTf*9f-u";

        private const string BASE_URL = "http://localhost:57898/odata/OrderStatuses";
        private const string BASELOGIN_URL = "http://localhost:57898/odata/OrderStatuses/TransporterService.Login";

        public UpdateXCNOrderStatusService()
        {
        }

        private LoginModel Login()
        {
            var user = new LoginModel
            {
                UserName = USERNAME,
                Password = PASSWORD,
            };

            JavaScriptSerializer jss = new JavaScriptSerializer();

            //string data = jss.Serialize(model);
            string loginUrl = BASELOGIN_URL + $"?username={USERNAME}&password={PASSWORD}";
            var wrGETURL = WebRequest.Create(loginUrl);
            wrGETURL.Method = "GET";
            //wrGETURL.Headers.Add("Token", Token);

            var objStream = wrGETURL.GetResponse().GetResponseStream();
            var objReader = new StreamReader(objStream);

            var sLineAll = objReader.ReadToEnd();

            var result = JsonConvert.DeserializeObject<LoginModel>(sLineAll);

            return result;
        }


        public UpdateStatusResult UpdateOrderStatus()
        {
            var loginResult = Login();

            if (!loginResult.Success)
            {
                throw new Exception(loginResult.Message); // dang nhap that bai
            }

            var jss = new JavaScriptSerializer();

            var postData = PreparePostData();
            postData.TokenKey = loginResult.TokenKey;

            string data = jss.Serialize(postData);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(BASE_URL);
            httpWebRequest.Headers["Token"] = loginResult.TokenKey;
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = WebRequestMethods.Http.Post;
            httpWebRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }

            HttpWebResponse response;
            try
            {
                response = httpWebRequest.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }

            var streamReader = new StreamReader(response.GetResponseStream());

            var responseString = streamReader.ReadToEnd();

            var result = JsonConvert.DeserializeObject<UpdateStatusResult>(responseString);

            return result;
        }

        private UpdateOrderStatus PreparePostData()
        {
            var postData = new UpdateOrderStatus
            {
                Note = "", // ghi chu
                Orders = new List<OrderItem>(),
            };

            postData.Orders.Add(new OrderItem
            {
                OrderCode = "TEST1001", // Ma don hang
                OrderStatusCode = (int)Status.Approved, // 1 2 3 4 5 -1
                OrderStatusText = "Mo ta trang thai",
                Date = "2015-12-31 01:22:00", //Ngay thang yyyy-MM-dd hh:mm:ss
                Description = "",
            });

            postData.Orders.Add(new OrderItem
            {
                OrderCode = "TEST1002", // Ma don hang
                OrderStatusCode = (int)Status.Approved, // 1 2 3 4 5 -1
                OrderStatusText = "Mo ta trang thai",
                Date = "Ngay thang",
                Description = "",
            });

            return postData;
        }
    }
}