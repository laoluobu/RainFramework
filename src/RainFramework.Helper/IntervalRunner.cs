using Microsoft.Extensions.Logging;

namespace RainFramework.Helper
{
    /// <summary>
    /// component that is specialized in calculating and executing a routine for a given interval
    /// </summary>
    public class IntervalRunner : IDisposable
    {
        private const int KMinInterval = 10;

        private readonly object _lock = new object();

        private int _interval = KMinInterval;

        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        private readonly ILogger _logger;

        private readonly Func<Task> _intervalFunc;

        /// <summary>
        /// Identifier of current IntervalRunner
        /// </summary>
        public object Id { get; private init; }

        /// <summary>
        /// Create new instance of <see cref="IntervalRunner"/>.
        /// </summary>
        public IntervalRunner(object id,
                              int interval,
                              Func<bool> canExecuteFunc,
                              Func<Task> intervalFunc,
                              ILogger logger)
        {
            Id = id;
            Interval = interval;
            this.canExecuteFunc = canExecuteFunc;
            _intervalFunc = intervalFunc;
            _logger = logger;
        }


        public IntervalRunner(int interval,
                              Func<Task> intervalFunc,
                              ILogger logger)
        {
            Id = 0;
            Interval = interval;
            canExecuteFunc = () => { return true; };
            _intervalFunc = intervalFunc;
            _logger = logger;
        }




        /// <summary>
        /// Get/set the Interval between Runs
        /// </summary>
        public int Interval
        {
            get => _interval;
            set
            {
                lock (_lock)
                {
                    if (value < KMinInterval)
                    {
                        value = KMinInterval;
                    }

                    _interval = value;
                }
            }
        }

        /// <summary>
        /// Get the function that decides if the configured action can be executed when the Interval elapses
        /// </summary>
        private Func<bool> canExecuteFunc;

        /// <summary>
        /// Get the action that will be executed at each interval
        /// </summary>
        /// <summary>
        /// Starts the IntervalRunner and makes it ready to execute the code.
        /// </summary>
        public void Start()
        {
            Task.Factory.StartNew(ProcessAsync, TaskCreationOptions.LongRunning);
            _logger.LogTrace("IntervalRunner with id: {Id} was started.", Id);
        }

        /// <summary>
        /// Stop the publishing thread.
        /// </summary>
        private void Stop()
        {
            lock (_lock)
            {
                try
                {
                    _cts.Cancel();
                }
                catch { }
                _cts?.Dispose();
            }
            _logger.LogDebug("IntervalRunner with id: {Id} was stopped.", Id);
        }

        public void Dispose()
        {
            Stop();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Periodically executes the .
        /// </summary>
        private async Task ProcessAsync()
        {
            using PeriodicTimer timer = new(TimeSpan.FromMilliseconds(_interval));
            do
            {
                try
                {
                    if (_intervalFunc != null && canExecuteFunc())
                    {
                        await _intervalFunc();
                    }
                }
                catch (Exception e)
                {
                    var retry = _interval * 10;
                    _logger.LogError("{Id} Runner Err: {Message} , Wait {retry} ms to retry ", Id, e.Message, retry);
                    await Task.Delay(TimeSpan.FromMilliseconds(_interval * 10), _cts.Token);
                }
            } while (await timer.WaitForNextTickAsync(_cts.Token));
        }
    }
}