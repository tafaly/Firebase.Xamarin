namespace Firebase.Database.Offline
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Threading;
    using System.Threading.Tasks;

    using Firebase.Database.Extensions;
    using Firebase.Database.Query;
    using Firebase.Database.Streaming;
    using System.Reactive.Threading.Tasks;
    using System.Linq.Expressions;
    using Internals;
    using Newtonsoft.Json;
    using System.Reflection;
    using System.Reactive.Disposables;

    /// <summary>
    /// The real-time Database which synchronizes online and offline data. 
    /// </summary>
    /// <typeparam name="T"> Type of entities. </typeparam>
    public partial class RealtimeDatabase<T>: IRealtimeDatabase
    {


    }
    public interface IRealtimeDatabase : IDisposable
    {

        /// <summary>
        /// Event raised whenever an exception is thrown in the synchronization thread. Exception thrown in there are swallowed, so this event is the only way to get to them. 
        /// </summary>
        event EventHandler<ExceptionEventArgs> SyncExceptionThrown;

        /// <summary>
        /// Gets the backing Database.
        /// </summary>
        IDictionary<string, OfflineEntry> Database { get; }

        /// <summary>
        /// Fetches everything from the remote database.
        /// </summary>
        Task PullAsync();

    }

}
