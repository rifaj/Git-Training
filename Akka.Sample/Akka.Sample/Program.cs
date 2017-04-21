using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Akka;
using Akka.Actor;

namespace Akka.Sample
{
    public class Greet
    {
        public Greet(string who)
        {
            Who = who;
        }
        public string Who { get; private set; }
    }

    // Create the actor class
    public class GreetingActor : ReceiveActor
    {
        public GreetingActor()
        {
            // Tell the actor to respond
            // to the Greet message
            Receive<Greet>(greet =>
               Console.WriteLine("Hello {0}", greet.Who));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a new actor system (a container for your actors)
            var system = ActorSystem.Create("MySystem");

            // Create your actor and get a reference to it.
            // This will be an "ActorRef", which is not a
            // reference to the actual actor instance
            // but rather a client or proxy to it.
            var greeter = system.ActorOf<GreetingActor>("greeter");
            var greeter1 = system.ActorOf<GreetingActor>("greeter1");

            greeter.Tell(new Greet("World"));
            for (var i = 0; i < 100000000; i++)
            {               
                greeter.Tell(new Greet("World " + i));
            }

            
            //// Send a message to the actor
            //greeter.Tell(new Greet("World"));
            //greeter1.Tell(new Greet("World1"));

            // This prevents the app from exiting
            // before the async work is done
            Console.ReadLine();
        }
    }
}
