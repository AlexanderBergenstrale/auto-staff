using MediatR;
using System.Threading.Tasks;

namespace HMW.Core
{
    public interface IDispatcher
    {
        Task Dispatch<TNotification>(TNotification notification);
        void Send(IRequest request);
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}