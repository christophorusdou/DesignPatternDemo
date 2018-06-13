using System.Threading.Tasks;
using DesignPatterns.ChainOfResponsiblity.PipelineBuilder;

namespace DesignPatterns.ChainOfResponsiblity.Handler
{
    public abstract class HandlerBase<T> where T : HandlerContext
    {
        private HandlerBase<T> _sucessor;
        internal T Context;
        public virtual void Handle(T context)
        {
            if (_sucessor != null)
            {
                _sucessor.Handle(context);
            }
        }

        public abstract bool DoHandle();

        public virtual void SetHandler(HandlerBase<T> handler, T context)
        {
            _sucessor = handler;
            Context = context;
        }
    }

    public abstract class Handler:IHandler
    {
        public abstract Task HandleAsync(HandlerContext context, HandlerDelegate next);

        public abstract bool DoHandle(HandlerContext context);
    }
    public interface IHandler
    {
        Task HandleAsync(HandlerContext context, HandlerDelegate next);

    }
}
