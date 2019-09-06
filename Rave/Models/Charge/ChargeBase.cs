﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rave.api;

namespace Rave.Models.Charge
{
    public abstract class ChargeBase <T1, T2> : ICharge<T1, T2> where T1 : RaveResponse<T2>, new() where T2 : ChargeResponse
    {
        internal ChargeBase (RaveConfig config)
        {
            Config = config;
            RaveApiRequest = new RaveRequest<T1, T2>(config);
            PayDataEncrypt = new DataEncryption();
        }

        internal RaveConfig Config { get; }
        internal IRaveRequest<T1, T2> RaveApiRequest { get; }

        public IDataEncryption PayDataEncrypt { get; }
        public abstract Task<T1> Charge(IParams Params, bool isRecurring = false);
    }
}
