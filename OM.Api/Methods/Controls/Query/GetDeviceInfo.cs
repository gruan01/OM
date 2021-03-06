﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OM.Api.Models;
using AsNum.FluentXml;

namespace OM.Api.Methods.Controls.Query
{

    /// <summary>
    /// 
    /// </summary>
    public class GetDeviceInfo : BaseMethod<DeviceInfo>
    {
        /// <summary>
        /// 
        /// </summary>
        public override ActionCategories ActionCategory => ActionCategories.Control;

        internal override object GetRequestData(ApiClientOption opt)
        {
            object o = null;
            return new
            {
                attribute = "Query".AsAttribute(),
                DeviceInfo = o.AsElement().SetNullVisible(true)
            };
        }
    }
}
