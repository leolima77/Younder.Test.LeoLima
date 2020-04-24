using System;

namespace Chefao.Test.Core.TestBases
{
    public interface IServiceTest<out TService>
    {
        TService GetServiceInstance(Action action = null);
    }
}
