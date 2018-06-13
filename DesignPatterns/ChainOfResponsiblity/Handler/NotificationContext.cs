namespace DesignPatterns.ChainOfResponsiblity.Handler
{
    public class NotificationContext : HandlerContext
    {
        public string Destination { get; set; }
        public string Message { get; set; }
        public string Topic { get; set; }
    }
}