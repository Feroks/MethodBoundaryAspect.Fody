﻿using System.Collections.Generic;
using MethodBoundaryAspect.Fody.UnitTests.TestAssembly.NetFramework;
using Xunit;

namespace MethodBoundaryAspect.Fody.UnitTests.NetFramework
{
    public class GenericClassWithArity2Tests : GenericTestBase
    {
        public static IEnumerable<object[]> Methods { get => GetMethodNames(typeof(Generic<List<Disposable[]>, Disposable>)); }

        public GenericClassWithArity2Tests()
        {
            OpenClassType = typeof(Generic<,>);
            ClosedClassType = OpenClassType.MakeGenericType(typeof(List<Disposable[]>), typeof(Disposable));
        }

        [Theory, MemberData(nameof(Methods))]
        public void IfMethodInMultiArityGenericClassIsWeaved_ThenResultIsExpected(string methodName)
        {
            RunTest(methodName);
        }
    }
}
