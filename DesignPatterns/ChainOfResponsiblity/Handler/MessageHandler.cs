using System;
using System.Threading.Tasks;
using DesignPatterns.ChainOfResponsiblity.PipelineBuilder;

namespace DesignPatterns.ChainOfResponsiblity.Handler
{
//    public class MessageHandler : HandlerBase<NotificationContext>
//    {
//        public override bool DoHandle()
//        {
//            if (Context.Topic.Equals("Message"))
//            {
//                return true;
//            }
//            return false;
//        }
//
//        public override void Handle(NotificationContext context)
//        {
//            if (DoHandle())
//            {
//                SendMessage(context);
//            }
//            base.Handle(context);
//        }
//
//        private void SendMessage(NotificationContext context)
//        {
//            
//        }
//    }
    public class MessageHandler:Handler
    {
        private Task SendMessage(HandlerContext context)
        {
            Console.WriteLine("Message Sent");
            return Task.CompletedTask;
        }

        public override Task HandleAsync(HandlerContext context, HandlerDelegate next)
        {
            if (DoHandle(context))
            {
                SendMessage(context);
            }

            return next.Invoke(context);
        }

        public override bool DoHandle(HandlerContext context)
        {
            if (context.Topic.Equals("Message"))
            {
                return true;
            }
            return false;
        }
    }

}