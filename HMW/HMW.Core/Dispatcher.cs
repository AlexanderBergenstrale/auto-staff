using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HMW.Core
{
    public class Dispatcher : IDispatcher
    {
        private readonly IMediator mediator;

        public Dispatcher(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public void Send(IRequest request)
        {
            mediator.Send(request);
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            return mediator.Send(request);
        }

        public Task Dispatch<TNotification>(TNotification notification)
        {
            return mediator.Publish(notification);
        }
    }
}
