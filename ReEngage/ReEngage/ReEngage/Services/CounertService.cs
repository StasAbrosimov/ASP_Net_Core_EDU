using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReEngage.Services
{
    public interface ITransendService
    {
        string Value { get; }
    }

    public interface IScopedService
    {
        string Value { get; }
    }

    public interface ISingletonService
    {
        string Value { get; }
    }

    public class CounertService : ITransendService, IScopedService, ISingletonService
    {
        private readonly Random rnd = new Random();
        private readonly int _value;
        private readonly string _GUID = Guid.NewGuid().ToString();


        public CounertService()
        {
            _value = rnd.Next(0, 100000);
        }

        public string Value
        {
            get
            {
                return $"Value:{_value.ToString()} GUID:{_GUID}";
            }
        }
    }
}
