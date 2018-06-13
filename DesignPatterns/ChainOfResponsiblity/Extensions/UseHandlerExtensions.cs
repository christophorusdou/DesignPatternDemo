using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DesignPatterns.ChainOfResponsiblity.Handler;
using DesignPatterns.ChainOfResponsiblity.PipelineBuilder;

namespace DesignPatterns.ChainOfResponsiblity.Extensions
{
    public static class UseHandlerExtensions
    {
        public static IPipeLineBuilder UseHandler<T>(this IPipeLineBuilder pipeline)
        {
            return UseHandler(pipeline,typeof(T));
        }

        public static IPipeLineBuilder UseHandler(this IPipeLineBuilder pipeline, Type handler)
        {
            if (typeof(IHandler).GetTypeInfo().IsAssignableFrom(handler.GetTypeInfo()))
            {
                return UseHandlerInterface(pipeline, handler);
            }

            throw new NotImplementedException("Can only handle intereface");
        }

        private static IPipeLineBuilder UseHandlerInterface(IPipeLineBuilder pipeline, Type handler)
        {
            return pipeline.Use(next =>
            {
                return async context =>
                {
                    var middleware = pipeline.HandlerProvider.GetHandler(handler);
                    if (middleware == null)
                    {
                        // The factory returned null, it's a broken implementation
                        throw new InvalidOperationException();
                    }

                    try
                    {
                        await middleware.HandleAsync(context, next);
                    }
                    catch
                    {

                    }
                    finally
                    {

                    }
                };
            });
        }
    }
}
