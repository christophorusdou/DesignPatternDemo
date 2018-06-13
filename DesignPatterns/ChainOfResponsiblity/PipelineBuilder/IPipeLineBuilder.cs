using System;

namespace DesignPatterns.ChainOfResponsiblity.PipelineBuilder
{
    public interface IPipeLineBuilder
    {
        IHandlerProvider HandlerProvider { get; set; }
        IPipeLineBuilder Use(Func<HandlerDelegate, HandlerDelegate> handler);
        HandlerDelegate Build();
        IPipeLineBuilder New();

    }
}