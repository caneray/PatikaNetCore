using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MiddleWarePractices.MiddleWares
{
    public class HelloMiddleware
    {
        private readonly RequestDelegate _next; //injection
        public HelloMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) //async ve await kullandığımız methodların geri dönüş tipi task olur
        {
            Console.WriteLine("Hello World!");
            await _next.Invoke(context);
            Console.WriteLine("Bye World!");
        }
    }

    static public class HelloMiddlewareExtension
    {
        public static IApplicationBuilder UseHello(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HelloMiddleware>();
        }
    }
}