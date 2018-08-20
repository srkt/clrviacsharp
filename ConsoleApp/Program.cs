using System;
using System.IO;
using System.Reflection;

namespace ConsoleApp
{
    //class Program
    //{
    //    private void Main(string[] args)
    //    {

    //        var tempDomain = AppDomain.CreateDomain("Temp Domain",AppDomain.CurrentDomain.Evidence);

    //        tempDomain.FirstChanceException += TempDomain_FirstChanceException;

    //        tempDomain.AssemblyLoad += TempDomain_AssemblyLoad;

    //        tempDomain.DomainUnload += TempDomain_DomainUnload;

    //        var sa = Assembly.Load("Clr.Via.CSharp.AppDomains");

    //        var assembly = tempDomain.Load("Clr.Via.CSharp.AppDomains");

    //        var obj = tempDomain.CreateInstanceAndUnwrap("Clr.Via.CSharp.AppDomains", 
    //                                                     "Clr.Via.CSharp.AppDomains.Project",
    //                                                     true,
    //                                                     BindingFlags.CreateInstance,
    //                                                     null,
    //                                                     new object[] { "Test" },
    //                                                     null,
    //                                                     null) ;
    //        AppDomain.Unload(tempDomain);

    //        //obj.SetDates(DateTime.Now, DateTime.Now.AddDays(10));

    //        Console.ReadKey();

    //    }


    //    private static void TempDomain_DomainUnload(object sender, EventArgs e)
    //    {
    //        Console.WriteLine("TempDomain_DomainUnload");
    //    }


    //    private static void TempDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
    //    {
    //        Console.WriteLine("TempDomain_AssemblyLoad");
    //    }

    //    private static void TempDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
    //    {
    //        Console.WriteLine("TempDomain_FirstChanceException");
    //        Console.WriteLine(e.Exception.Message);
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            var setup = AppDomain.CurrentDomain.SetupInformation;

            var dllPath = setup.ApplicationBase; //  + "AppDLLs";

            var dlls = Directory.EnumerateFiles(dllPath);

            foreach (var dll in dlls)
            {
                if(dll.EndsWith("dll"))
                Assembly.LoadFrom(dll);
            }

            //foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            //{
            //   Console.WriteLine(assembly.FullName);
            //}

            Console.WriteLine("For oracle connection type 1 type any other for sqlserver");
            var i = Console.ReadLine();

            var assemblyName = "SqlServer";
            var typeName = assemblyName + ".SqlServerDatabase";


            if(i == "1")
            {
                assemblyName = "OracleDB";
                typeName = assemblyName + ".OracleDatabase";

            }

            

            var oracle = AppDomain.CurrentDomain.CreateInstance(assemblyName,
                                                         typeName
                                                    );

            

            var o = oracle.Unwrap();

            var methodInfo = o.GetType().GetMethod("CreateConnection");//.Invoke(o,null);


            var customAttributes = methodInfo.CustomAttributes;

            foreach (var attribute in customAttributes)
            {
                if(attribute.AttributeType.Name == "ReflectionInvocationAttribute")
                {
                    throw new InvalidOperationException("Can't invoke through reflection");
                }
            }

            Console.WriteLine(methodInfo.Invoke(o,null));

            Console.ReadKey();


        }
    }
}
