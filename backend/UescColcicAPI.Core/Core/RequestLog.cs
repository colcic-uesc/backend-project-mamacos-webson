using System;

namespace UescColcicAPI.Core
{
    public class RequestLog
    {
        public int Id { get; set; }
        public string? ClientIp { get; set; }
        public bool HasJwt { get; set; }
        public DateTime RequestTime { get; set; }
        public string? RequestMethod { get; set; }
        public string? RequestUrl { get; set; }
        public long ProcessingTime { get; set; }
    }
}
