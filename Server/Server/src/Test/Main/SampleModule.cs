using Nancy;

namespace Test.Main
{
    class SampleModule : NancyModule
    {
        public SampleModule()
        {
            Get["/"] = _ => "Hello World!";
            Post["/config"] = x =>
            {
                return 200;
            };
        }
    }
}
