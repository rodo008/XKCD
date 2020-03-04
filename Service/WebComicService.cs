using Application;
using Domain.Model;
using System;

namespace Service
{
    public class WebComicService
    {
        public IResponse GetActualWebComic() {
            var response = ResponseFactory.GetResponse();

            return response;
        }
    }
}
