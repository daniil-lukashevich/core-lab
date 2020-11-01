using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Services
{
    public interface ICustomeSrvice
    {
        string GetString();
    }

    public class CustomService : ICustomeSrvice
    {
        public string GetString()
        {
            return "test";
        }
    }
}
