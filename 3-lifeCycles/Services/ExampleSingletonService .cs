using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lifeCycles.Interfaces;

namespace lifeCycles.Services
{
    public class ExampleSingletonService : IExampleSingletonService
    {
        private readonly Guid Id;

        public ExampleSingletonService()
        {   //global unique identifier
            Id = Guid.NewGuid();
        }

        //Return de id as a string
        public string GetGuid() => Id.ToString();
    }
}