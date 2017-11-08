using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlackbirdCs
{
    public class PeriodicTask
    {
        public static async Task Run(Action action, TimeSpan period, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(period, cancellationToken);

                if (!cancellationToken.IsCancellationRequested)
                {
                    action();
                }
            }
        }

        public static Task Run(Action action, TimeSpan period)
        {
            return Run(action, period, CancellationToken.None);
        }
    }

    public class PeriodicTask<T> where T : class
    {
        public static async Task Run(Action<T> action, T actionArgument, TimeSpan period, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(period, cancellationToken);

                if (!cancellationToken.IsCancellationRequested)
                {
                    action(actionArgument);
                }
            }
        }

        public static Task Run(Action<T> action, T actionArgument, TimeSpan period)
        {
            return Run(action, actionArgument, period, CancellationToken.None);
        }
    }
}
