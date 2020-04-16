﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Json;

namespace Com.OPPO.Mo.PublicGateway
{
    [RemoteService]
    [Route("api/public-gateway/test")]
    public class PublicGatewayController : AbpController
    {
        private readonly IJsonSerializer _jsonSerializer;

        public PublicGatewayController(IJsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var newLine = Environment.NewLine + Environment.NewLine;

            return Content(
                "Claims: " + User.Claims.Select(c => $"{c.Type} = {c.Value}").JoinAsString(" | ") + newLine +
                "CurrentUser: " + _jsonSerializer.Serialize(CurrentUser) + newLine
            );
        }
    }
}
