using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;

namespace TodoApi
{
    public class Job
    {
        private readonly IRecurringJobManager _backgroundJobClient;

        public Job(IRecurringJobManager backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }

        public void EnqueueJob()
        {
            _backgroundJobClient.AddOrUpdate("powerfuljob", () => Console.Write("Powerful!"), "*/20 * * * * *");
            // _backgroundJobClient.Enqueue(() => Console.WriteLine("Hello from a background job!"));
        }
    }
}