using Application;
using Domain.Model;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Cache;
using System.Threading.Tasks;

namespace Service
{
    /// <summary>
    /// Service manager for XKCD Comic Json API
    /// </summary>
    public  class WebComicService
    {

        private static WebComic _todaysComic;
        private static int  _currentComicNum;

        /// <summary>
        /// Get the day's actual comic
        /// </summary>
        /// <returns></returns>
        public async  Task<Response> GetTodayComic(string comicUrl) {
            
            var response = ResponseFactory.GetResponse();
            
            //Get response data
            response = await GetComicFromUrl(comicUrl);
            

            if (response.Success)
            {
                //validate actual webcomic with response data
                var webComic = response.GetData<WebComic>();

                webComic.IsTodayComic = true;       //set true 
                _todaysComic = webComic;            //store the todays comic 
                _currentComicNum = webComic.Num;    //store the current comic num
            }


            return response;
        }



        /// <summary>
        /// Get the specific Comic from Number Code
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Response with data</returns>
        public async Task<Response> GetComicByCode(int code,string urlTpl)
        {

            var response = ResponseFactory.GetResponse();
            var comicUrl = String.Format(urlTpl, code);            


            //Get response data
            response = await GetComicFromUrl(comicUrl);


            response.NextAction = (code > _currentComicNum);    //if code is greater than current num then NextAction is call for user.
            _currentComicNum = code;                            //pass user's given code to currentNum var.


            if (response.Success)
            {
                //validate actual webcomic with response data
                var webComic = response.GetData<WebComic>();
                webComic.IsTodayComic = (webComic.Num == _todaysComic?.Num);
            }

            return response;
        }



        /// <summary>
        /// Get Commit from remote URL
        /// </summary>
        /// <param name="siteUrl">Remote URL Path</param>
        /// <returns></returns>
        public async Task<Response> GetComicFromUrl(string siteUrl)
        {
            var response = ResponseFactory.GetResponse();
            
            try
            {
                String json = "";

                //Using web client for get data from remote url
                using (WebClient wc = new WebClient())
                {
                    json = await wc.DownloadStringTaskAsync(siteUrl);
                    
                }


                //deserialize object
                WebComic webComic = JsonConvert.DeserializeObject<WebComic>(json);


                response.Data = webComic;
                response.Success = true;                

            }
            catch (WebException ex)
            {
                var webResponse = (HttpWebResponse)ex.Response;
                response.StatusCode = (int)webResponse.StatusCode;
                response.Message = ex.Message;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
