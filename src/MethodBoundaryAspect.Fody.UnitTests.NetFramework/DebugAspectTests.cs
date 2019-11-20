﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using FluentAssertions;
using MethodBoundaryAspect.Fody.UnitTests.Shared;
using MethodBoundaryAspect.Fody.UnitTests.TestProgram;
using MethodBoundaryAspect.Fody.UnitTests.TestProgram.NetFramework;
using Xunit;

namespace MethodBoundaryAspect.Fody.UnitTests.NetFramework
{
    public class DebugAspectTests : MethodBoundaryAspectNetFrameworkTestBase
    {
        [Fact(Skip = "Needs to be clarified")]
        public void IfWeavedTestProgramIsExecuted_ThenTheDebugSymbolsShouldWorkAndTheDebuggerShouldBeAttachable()
        {
            // 1) Run unittest without debugger, then in opened dialog attach with current visual studio instance.
            // 2) Put breakpoint in LogAttribute

            // Arrange
            var weavedProgramPath = WeaveAssembly(typeof(TestClass));

            // Act
            var process = Process.Start(weavedProgramPath);
            process.WaitForExit();

            // Arrange
            process.ExitCode.Should().Be(0);
        }

        [Fact(Skip = "Needs to be clarified")]
        public void IfAssemblyIsWeaved_ThenWeaverDebuggerShouldBePossible()
        {
            // Arrange
            var assemblyPath = @"c:\???";

            Weaver = new ModuleWeaver();
            Weaver.AddClassFilter("???");
            Weaver.WeaveToShadowFile(assemblyPath, new FolderAssemblyResolver(ModuleHelper.AssemblyResolver, Path.GetDirectoryName(assemblyPath)));
        }
    }
}