using System;
using System.Threading;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace SmartHotel.Clients.Core.Helpers
{
	// https://forums.xamarin.com/discussion/comment/149877/#Comment_149877
    public class Timer
    {
	    private readonly TimeSpan _timespan;
	    private readonly Action _callback;
	    private readonly bool _isRecurring;

	    private CancellationTokenSource _cancellation;

        public bool IsRunning => _cancellation != null && !_cancellation.IsCancellationRequested;

	    public Timer(TimeSpan timespan, Action callback, bool isRecurring = false)
	    {
		    _timespan = timespan;
		    _callback = callback;
		    _isRecurring = isRecurring;
		    _cancellation = new CancellationTokenSource();
	    }

	    public void Start()
	    {
		    if (_cancellation == null)
		    {
			    Interlocked.Exchange(ref _cancellation, new CancellationTokenSource());
		    }

		    CancellationTokenSource cts = _cancellation; // safe copy
		    // TODO Xamarin.Forms.Device.StartTimer is no longer supported. Use Microsoft.Maui.Dispatching.DispatcherExtensions.StartTimer instead. For more details see https://learn.microsoft.com/en-us/dotnet/maui/migration/forms-projects#device-changes
		    Device.StartTimer(_timespan,
			    () => {
				    if (cts.IsCancellationRequested) return false;
				    _callback.Invoke();
				    return _isRecurring;
			    });
	    }

	    public void Stop()
	    {
		    Interlocked.Exchange(ref _cancellation, null)?.Cancel();
	    }
    }
}
