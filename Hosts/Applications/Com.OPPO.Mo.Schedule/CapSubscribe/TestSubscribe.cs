using DotNetCore.CAP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace Com.OPPO.Mo.Schedule.CapSubscribe
{
    public class TestSubscribe : ICapSubscribe, ITransientDependency
    {
        //[CapSubscribe(MoBpmConsts.ProcessEventMessageTopic, Group = "C")]
        //public void CheckReceivedMessage(ProcessEventMessageEto processEventMessageEto)
        //{
        //    Console.WriteLine(JsonConvert.SerializeObject(processEventMessageEto));
        //}
    }
}
