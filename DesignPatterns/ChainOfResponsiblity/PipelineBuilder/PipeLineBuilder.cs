using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.ChainOfResponsiblity.PipelineBuilder
{
    // resean here for delegate is because 
    // this delegate is actually the chain of function(rather then the class)

    public class PipeLineBuilder:IPipeLineBuilder
    {
        private readonly IList<Func<HandlerDelegate,HandlerDelegate>> _components = new List<Func<HandlerDelegate, HandlerDelegate>>();
        public PipeLineBuilder(IHandlerProvider provider)
        {
            HandlerProvider = provider;
        }
        public PipeLineBuilder()
        {
        }

        public IHandlerProvider HandlerProvider { get; set; }
        public IPipeLineBuilder Use(Func<HandlerDelegate, HandlerDelegate> handler)
        {
            _components.Add(handler);
            return this;
        }
        public IPipeLineBuilder New()
        {
            return new PipeLineBuilder();
        }
        public HandlerDelegate Build()
        {
            HandlerDelegate app = context =>
            {
                return Task.CompletedTask;
            };

            foreach (var component in _components.Reverse())
            {
                app = component(app);
            }

            return app;
        }
    }
}
