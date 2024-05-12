﻿namespace Lab5_Http
{
    public class ResponseModel<T>
    {
        public string Message { get; set; }
        public int HttpStatusCode { get; set; }
        public List<T> Data { get; set; }
    }
}
