using Autofac;
using Autofac.Extras.DynamicProxy;
using System.Reflection;

namespace LHJ.WebHost;

public class AutofacModuleRegister : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        //注册服务
        //builder.RegisterType<TestService>().As<ITestService>();

        //builder.RegisterType<TestRepository>().As<ITestRepository>();

        //注册Service
        var assemblysServices = Assembly.Load("LHJ.Service");
        builder.RegisterAssemblyTypes(assemblysServices)
            .InstancePerLifetimeScope()//默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象
           .AsImplementedInterfaces()//是以接口方式进行注入,注入这些类的所有的公共接口作为服务（除了释放资源）
           .EnableInterfaceInterceptors(); //引用Autofac.Extras.DynamicProxy;应用拦截器

        //注册Repository 
        var assemblysRepository = Assembly.Load("LHJ.Repository");
        builder.RegisterAssemblyTypes(assemblysRepository)
            .InstancePerLifetimeScope()//默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象
           .AsImplementedInterfaces()//是以接口方式进行注入,注入这些类的所有的公共接口作为服务（除了释放资源）
           .EnableInterfaceInterceptors(); //引用Autofac.Extras.DynamicProxy;应用拦截器

    }
}
