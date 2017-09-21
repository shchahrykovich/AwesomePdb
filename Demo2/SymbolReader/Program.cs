using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            string pdbPath = GetPdbPath("SourceLink.pdb");

            using (var stream = File.OpenRead(pdbPath))
            {
                using (var pdbStream = MetadataReaderProvider.FromPortablePdbStream(stream))
                {
                    MethodDebugInformationHandle methodDebugHandle = GetHandle("SourceLink.BubbleSort, SourceLink");
                    MetadataReader metadataReader = pdbStream.GetMetadataReader();

                    foreach (var localVariableHandle in GetLocalVariableHandles(metadataReader, methodDebugHandle).SelectMany(_ => _))
                    {
                        var localVariable = metadataReader.GetLocalVariable(localVariableHandle);
                        var name = metadataReader.GetString(localVariable.Name);
                        Console.WriteLine("Local variable " + name);
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();

                    foreach (var debugInfoHandle in metadataReader.CustomDebugInformation)
                    {
                        CustomDebugInformation debugInfo = metadataReader.GetCustomDebugInformation(debugInfoHandle);
                        var guid = metadataReader.GetGuid(debugInfo.Kind);
                        if (guid == new Guid("CC110556-A091-4D38-9FEC-25AB9A351A6A"))
                        {
                            var reader = metadataReader.GetBlobReader(debugInfo.Value);
                            Console.WriteLine(reader.ReadUTF8(reader.RemainingBytes));
                        }
                    }
                }
            }

            Console.ReadLine();
        }

        private static IEnumerable<LocalVariableHandleCollection> GetLocalVariableHandles(MetadataReader metadataReader, MethodDebugInformationHandle methodDebugHandle)
        {
            LocalScopeHandleCollection scopes = metadataReader.GetLocalScopes(methodDebugHandle);
            foreach (LocalScopeHandle scope in scopes)
            {
                LocalVariableHandleCollection localVariables = metadataReader.GetLocalScope(scope).GetLocalVariables();
                yield return localVariables;
            }
        }

        private static MethodDebugInformationHandle GetHandle(string typeName)
        {
            MethodInfo methodInfo = GetMethodInfo(typeName);
            Handle handle = MetadataTokens.Handle(methodInfo.GetMetadataToken());
            MethodDebugInformationHandle methodDebugHandle = ((MethodDefinitionHandle)handle).ToDebugInformationHandle();
            return methodDebugHandle;
        }

        private static string GetPdbPath(string pdbName)
        {
            var location = Assembly.GetEntryAssembly().Location;
            var path = Path.Combine(Path.GetDirectoryName(location), pdbName);
            return path;
        }

        private static MethodInfo GetMethodInfo(string typeName)
        {
            var type = Type.GetType(typeName);
            var method = type.GetMethods()[0];
            Console.WriteLine("Method name " + method.Name);
            return method;
        }
    }
}