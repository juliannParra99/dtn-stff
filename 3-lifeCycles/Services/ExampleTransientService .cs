using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lifeCycles.Interfaces;

namespace lifeCycles.Services
{
    public class ExampleTransientService : IExampleTransientService
    {
        private readonly Guid Id;

        public ExampleTransientService()
        {
            //global unique identifier
            Id = Guid.NewGuid();
        }

        public string GetGuid() => Id.ToString();
    }
}