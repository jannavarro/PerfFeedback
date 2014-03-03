using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PerfFeedback.Framework
{
    /// <summary>
    /// Temporary class to publish event. Will improve this to a pattern later on.
    /// </summary>
    public static class TempEventBus
    {
        static ConcurrentDictionary<string, UniqueTypeListWrapper<ISubscriber>> _subscribers = new ConcurrentDictionary<string, UniqueTypeListWrapper<ISubscriber>>();
        /// <summary>
        /// Lock for the List values of the Dictionary.
        /// </summary>
        static ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

        public static void Subscribe(string topic, ISubscriber subscriber)
        {
            var valSubscribers = _subscribers.GetOrAdd(topic, new UniqueTypeListWrapper<ISubscriber>() { subscriber });
            
            rwLock.EnterWriteLock();
            try
            {
                valSubscribers.Add(subscriber);
            }
            catch (Exception e)
            {

            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }

        public static void Publish(string topic, SubscribeResponse response)
        {
            UniqueTypeListWrapper<ISubscriber> subscribers;
            if (_subscribers.TryGetValue(topic, out subscribers))
            {
                rwLock.EnterReadLock();
                try
                {
                    foreach (var subscriber in subscribers)
                    {
                        subscriber.HandleNotification(response);
                    }
                }
                catch (Exception e)
                {
                }
                finally
                {
                    rwLock.ExitReadLock();
                }
            }
        }
    }
}
