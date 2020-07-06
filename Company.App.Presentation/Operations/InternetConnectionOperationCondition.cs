using System.Threading;
using System.Threading.Tasks;
using Company.App.Application.Connectivity;
using Company.App.Infrastructure.Connectivity;
using Company.App.Resources;
using FlexiMvvm.Operations;

namespace Company.App.Presentation.Operations
{
    public class InternetConnectionOperationCondition : OperationCondition
    {
        public override Task<bool> CheckAsync(OperationContext context, CancellationToken cancellationToken)
        {
            var connectivityService = context.DependencyProvider.Get<IConnectivityService>();

            if (connectivityService.IsConnected)
            {
                return Task.FromResult(true);
            }

            throw new ConnectivityException(Strings.Exception_NoInternetConnection);
        }
    }
}
