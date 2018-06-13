using System.Threading.Tasks;
using DesignPatterns.ChainOfResponsiblity.Handler;

namespace DesignPatterns.ChainOfResponsiblity.PipelineBuilder
{
    public delegate Task HandlerDelegate(HandlerContext context);
}