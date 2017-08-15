using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace NashSoft.BehaviourRecorder.NUnit
{
    [BehaviourRecorderPlugin(true, 0)]
    public class NUnitTestSketchProvider : ITestSketchProvider
    {
        public TestSketch GetTestSketch()
        {
            var testSketch = new TestSketch();
            testSketch.UniqueTestCaseIdentifier = TestContext.CurrentContext.Test.ID;
            testSketch.TestClassType = GetTestType();
            testSketch.TestParameters = TestContext.CurrentContext.Test.Arguments.ToList();
            testSketch.TestMethod = GetMethodBase(testSketch.TestClassType, testSketch.TestParameters);
            return testSketch;
        }

        private static MethodBase GetMethodBase(Type testClassType, IList<object> parameters)
        {
            var methods = testClassType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            var filteredMethods = methods.Where(x => x.GetParameters().Length == parameters.Count);
            foreach (var method in filteredMethods)
            {
                var parameterDetails = method.GetParameters();
                if (WillObjectsMatchTypes(parameters, parameterDetails)) return method;
            }
            throw new SystemException();
        }

        private static bool WillObjectsMatchTypes(IList<object> parameters, ParameterInfo[] parameterDetails)
        {
            for (var i = 0; i < parameters.Count; i++)
            {
                if (!parameterDetails[i].ParameterType.IsInstanceOfType(parameters[i])) return false;
            }
            return true;
        }

        private static Type GetTestType()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var testClassName = TestContext.CurrentContext.Test.ClassName;
            foreach (var assembly in assemblies)
            {
                var type = assembly.GetType(testClassName, false, true);
                if (type != null) return type;
                //TODO: What if multiple type for the same string is found in different assemblies.
            }
            throw new SystemException();
        }
    }
}