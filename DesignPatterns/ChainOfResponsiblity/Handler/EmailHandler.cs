using System;
using System.Threading.Tasks;
using DesignPatterns.ChainOfResponsiblity.PipelineBuilder;

namespace DesignPatterns.ChainOfResponsiblity.Handler
{
//    public class EmailHandler:HandlerBase<NotificationContext>
//    {
//        public override bool DoHandle()
//        {
//            return Context.Topic.Equals("Email");
//        }
//
//        public override void Handle(NotificationContext context)
//        {
//            if (DoHandle())
//            {
//                SendEmail(Context);
//            }
//            base.Handle(context);
//        }
//
//        private void SendEmail(NotificationContext context)
//        {
//            
//        }
//    }
    public class EmailHandler : Handler
    {
        public Task SendEmail(HandlerContext context)
        {
            Console.WriteLine("Email Sent");
            return Task.CompletedTask;
        }

        public override Task HandleAsync(HandlerContext context, HandlerDelegate next)
        {
            if (DoHandle(context))
            {
                SendEmail(context);
            }

            return next.Invoke(context);
        }

        public override bool DoHandle(HandlerContext context)
        {
            if (context.Topic.Equals("Email"))
            {
                return true;
            }
            return false;
        }
    }
}