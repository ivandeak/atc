using System.Reflection;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using ToDoApi.Data;

namespace ToDoApi.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}
