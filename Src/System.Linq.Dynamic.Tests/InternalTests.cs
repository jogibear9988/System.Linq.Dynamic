using System;
#if !NETFX_CORE
using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#endif
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Tests.Helpers;
using System.Collections;
using System.Collections.Generic;

#if !NET35
using System.Threading.Tasks;
#endif

namespace System.Linq.Dynamic.Tests
{
    [TestClass]
    public class InternalTests
    {
#if !NET35 && !NETFX_CORE
        [TestMethod]
        public void ClassFactory_LoadTest()
        {
            //Arrange
            var rnd = new Random(1);

            var testPropertiesGroups = new DynamicProperty[][] {
                new DynamicProperty[] { 
                    new DynamicProperty("String1", typeof( string )), 
                },
                new DynamicProperty[] { 
                    new DynamicProperty("String1", typeof( string )), 
                    new DynamicProperty("String2", typeof( string )) 
                },
                new DynamicProperty[] { 
                    new DynamicProperty("String1", typeof( string )), 
                    new DynamicProperty("Int1", typeof( int )) 
                },
                new DynamicProperty[] { 
                    new DynamicProperty("Int1", typeof( int )), 
                    new DynamicProperty("Int2", typeof( int )) 
                },
                new DynamicProperty[] { 
                    new DynamicProperty("String1", typeof( string )), 
                    new DynamicProperty("String2", typeof( string )), 
                    new DynamicProperty("String3", typeof( string )), 
                },
            };

            Action<int> testActionSingle = i =>
            {
                ClassFactory.Instance.GetDynamicClass(testPropertiesGroups[0]);
            };

            Action<int> testActionMultiple = i => {
                var testProperties = testPropertiesGroups[rnd.Next(0, testPropertiesGroups.Length)];

                ClassFactory.Instance.GetDynamicClass(testProperties);
            };

            //Act
            Parallel.For(0, 100000, testActionSingle);

            Parallel.For(0, 100000, testActionMultiple);

        }
#endif

    }
}