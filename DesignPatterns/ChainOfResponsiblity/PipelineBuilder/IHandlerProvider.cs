using System;
using DesignPatterns.ChainOfResponsiblity.Handler;

namespace DesignPatterns.ChainOfResponsiblity.PipelineBuilder
{
    public interface IHandlerProvider
    {
        IHandler GetHandler(Type handlerType);
    }

    public class HandlerProvider:IHandlerProvider
    {
        public IHandler GetHandler(Type handlerType)
        {

            if (handlerType == typeof(MessageHandler))
            {
                return new MessageHandler();
            }
            return new EmailHandler();
        }
    }
}