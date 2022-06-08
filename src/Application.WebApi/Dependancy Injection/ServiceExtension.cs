using Application.Interface.LoanDocument;
using Application.Interface.Users;
using Application.Repository.LoanDocument;
using Application.Repository.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.WebApi.Dependancy_Injection
{
    public static class ServiceExtension
    {
        public static void ConfigureTransient(this IServiceCollection services)
        {
            services.AddTransient<IUsers, RegistrationRepository>();
            services.AddTransient<ILoanDocument, LoanDocumentRepository>();
        }
    }
}
