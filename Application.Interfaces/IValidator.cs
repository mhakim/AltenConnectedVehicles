using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    /// <summary>
    /// Validate resource for create and update operation
    /// </summary>
    /// <typeparam name="TResource"></typeparam>
    public interface IValidator<TResource> where TResource : IResource
    {
        bool IsValid(TResource resource);
    }
}
