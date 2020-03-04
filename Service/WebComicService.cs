using Application;
using Domain.Model;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Service
{
    /// <summary>
    /// Service manager for XKCD Comic Json API
    /// </summary>
    public  class WebComicService
    {
        /// <summary>
        /// Get the day's actual comic
        /// </summary>
        /// <returns></returns>
        public async  Task<Response> GetActualWebComic() {
            var response = ResponseFactory.GetResponse();
            var actualURL = GeneralSettings.Instance.ActualWebComicUrl;

            try
            {
                string json = "";
                using (WebClient wc = new WebClient())
                {                    
                    json = await wc.DownloadStringTaskAsync(actualURL);                    
                }

                WebComic webComic = JsonConvert.DeserializeObject<WebComic>(json);

                response.Data = webComic;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }


        /// <summary>
        /// Get the specific Comic from Number Code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Response with data</returns>
        public async Task<Response> GetWebComic(int code)
        {
            var response = ResponseFactory.GetResponse();
            var actualURL = String.Format(GeneralSettings.Instance.WebComicUrlTpl,code);

            try
            {
                string json = "";
                using (WebClient wc = new WebClient())
                {                   
                    json = await wc.DownloadStringTaskAsync(actualURL);
                }

                WebComic webComic = JsonConvert.DeserializeObject<WebComic>(json);

                response.Data = webComic;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
