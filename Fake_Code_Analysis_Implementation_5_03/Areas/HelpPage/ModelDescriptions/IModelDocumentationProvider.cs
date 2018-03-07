using System;
using System.Reflection;

namespace Fake_Code_Analysis_Implementation_5_03.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}