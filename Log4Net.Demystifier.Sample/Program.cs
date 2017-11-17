using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using log4net.Config;

namespace Log4Net.Demystifier.Sample
{
    class Program
    {
        static async Task<int> Main()
        {
            XmlConfigurator.Configure();
            var logger = DemystifiedLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            try
            {
                return await FailingMethod();
            }
            catch (Exception ex)
            {
                logger.Error("Unhandled exception", ex);
                return 1;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        static Task<int> FailingMethod()
        {
            return Task.FromResult(FailingEnumerator().Sum());
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        static IEnumerable<int> FailingEnumerator()
        {
            yield return 1;
            throw new NotImplementedException();
        }
    }
}
