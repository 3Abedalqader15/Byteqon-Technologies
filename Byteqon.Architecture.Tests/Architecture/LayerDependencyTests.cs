using NetArchTest.Rules;

namespace Byteqon.Architecture.Tests.Architecture;

public sealed class LayerDependencyTests
{
    private const string DomainNamespace = "Byteqon.Domain";
    private const string ApplicationNamespace = "Byteqon.Application";
    private const string InfrastructureNamespace = "Byteqon.Infrastructure";
    private const string ApiNamespace = "Byteqon.Api";

    [Fact]
    public void Domain_Should_Not_Have_Dependency_On_Other_Layers()
    {
        var domainAssembly = typeof(
            Byteqon.Domain.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(domainAssembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                ApplicationNamespace,
                InfrastructureNamespace,
                ApiNamespace)
            .GetResult();

        Assert.True(
            result.IsSuccessful,
            "Domain must not depend on Application, Infrastructure or API.");
    }

    [Fact]
    public void Application_Should_Not_Have_Dependency_On_Outer_Layers()
    {
        var applicationAssembly = typeof(
            Byteqon.Application.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(applicationAssembly)
            .ShouldNot()
            .HaveDependencyOnAny(
                InfrastructureNamespace,
                ApiNamespace)
            .GetResult();

        Assert.True(
            result.IsSuccessful,
            "Application must not depend on Infrastructure or API.");
    }

    [Fact]
    public void Infrastructure_Should_Not_Have_Dependency_On_Api()
    {
        var infrastructureAssembly = typeof(
            Byteqon.Infrastructure.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(infrastructureAssembly)
            .ShouldNot()
            .HaveDependencyOn(ApiNamespace)
            .GetResult();

        Assert.True(
            result.IsSuccessful,
            "Infrastructure must not depend on API.");
    }
}