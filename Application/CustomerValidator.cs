using System;
using Application.Interfaces;
using Resources;

namespace Application
{
    public class CustomerValidator : IValidator<CustomerResource>
    {
        public bool IsValid(CustomerResource resource)
        {
            return true;
        }
    }
}
