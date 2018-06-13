using System;
using System.Threading.Tasks;
using DesignPatterns.ChainOfResponsiblity;
using DesignPatterns.ChainOfResponsiblity.Extensions;
using DesignPatterns.ChainOfResponsiblity.Handler;
using DesignPatterns.ChainOfResponsiblity.PipelineBuilder;

namespace DesignPatterns
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var provider = new HandlerProvider();
            var pipeline = new PipeLineBuilder(provider);

            pipeline.UseHandler<MessageHandler>();
            pipeline.UseHandler<EmailHandler>();

            var del = pipeline.Build();
            await del(new HandlerContext() {Topic = "Email"});

            Console.Read();
        }
    }
}
