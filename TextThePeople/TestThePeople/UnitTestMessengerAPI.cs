using System;
using TextThePeople;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace TestThePeople
{
    [TestClass]
    public class UnitTestMessengerAPI
    {
        [TestMethod]
        public void TestMethod1()
        {
            var restClient = new RestClient("http://localhost:57358/");
            var request = new RestRequest("api/Message", Method.POST);
            //request.RequestFormat = DataFormat.Json;
            request.AddParameter("to", "19545592101");
            request.AddParameter("from", "");
            request.AddParameter("message", "This is a new message");
            request.AddParameter("osentityId", "");
            var response = restClient.Execute(request);

        }
    }
}
