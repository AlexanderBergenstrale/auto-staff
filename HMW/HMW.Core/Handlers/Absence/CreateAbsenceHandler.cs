using HMW.Core.Notifications.Absence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HMW.Core.Handlers.Absence
{
    class CreateAbsenceHandler : INotificationHandler<CreateAbsenceNotification>
    {
        public CreateAbsenceHandler()
        {
        }

        public Task Handle(CreateAbsenceNotification notification, CancellationToken cancellationToken)
        {
            // send through event queue or similar

            return Task.FromResult(0);
        }
    }
}
