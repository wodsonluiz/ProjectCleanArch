using System;
using Polly;
using Polly.CircuitBreaker;

namespace Client.Api.Resilience
{
    public static class CircuitBreaker
    {
        public static AsyncCircuitBreakerPolicy CreatePolicy()
        {
            return Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(10), 
                    onBreak: (_, _) => {
                        System.Console.WriteLine("Open (onBreak)");
                    },
                    onReset: () =>{
                        System.Console.WriteLine("Closed (onReset)");
                    },
                    onHalfOpen: () => {
                        System.Console.WriteLine("Half Open (onHalfOpen");
                    });
                
        }
    }
}