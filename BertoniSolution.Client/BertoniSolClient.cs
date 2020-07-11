using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BertoniSolution.Client
{
    public class BertoniSolClient
    {
        private readonly HttpClient httpClient;

        public BertoniSolClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<TEntity> Get<TEntity>(string strUrl)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(strUrl);
                var vJsonResponse = response.Content.ReadAsStringAsync().Result;

                TEntity entity = default;
                if (response.IsSuccessStatusCode)
                    entity = JsonConvert.DeserializeObject<TEntity>(vJsonResponse);

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> Post<TEntity>(string strUrl, object objRequest) where TEntity : class
        {
            try
            {

                var vJson = JsonConvert.SerializeObject(objRequest);
                var vContent = new StringContent(vJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(strUrl, vContent);
                var vJsonResponse = response.Content.ReadAsStringAsync().Result;

                TEntity entity = default;
                if (response.IsSuccessStatusCode)
                {
                    entity = JsonConvert.DeserializeObject<TEntity>(vJsonResponse);
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
