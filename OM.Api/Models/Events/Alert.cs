﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using OM.Api.Models.Enums;
using Newtonsoft.Json;

namespace OM.Api.Models.Events
{

    /// <summary>
    /// 回铃事件
    /// 当被叫对主叫（分机/来电）的呼叫回铃时，OM向应用服务器推送该事件报告。
    /// </summary>
    [XmlRoot("Event")]
    public class Alert : BaseEvent, IExtNotify
    {

        /// <summary>
        /// 
        /// </summary>
        public override EventTypes Attribute => EventTypes.ALERT;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("ext")]
        public List<IDAttribute> _Exts { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public IDAttribute Ext => this._Exts?.FirstOrDefault();

        /// <summary>
        /// 分机呼叫分机，被叫分机回铃
        /// </summary>
        [JsonIgnore]
        public IDAttribute ToExt => this._Exts?.ElementAtOrDefault(1);


        /// <summary>
        /// 外部来电呼叫分机，分机回铃：
        /// </summary>
        [XmlElement("visitor")]
        public VisitorCallInfo Visitor { get; set; }

        /// <summary>
        /// 分机呼叫外部电话，外部电话回铃：
        /// </summary>
        [XmlElement("outer")]
        public OutCallInfo Outer { get; set; }


        /// <summary>
        /// Menu外呼 没有分机号
        /// </summary>
        string IExtNotify.ExtID => this.Ext?.ID;

        //TODO Menu外呼，外部电话回铃：

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public string ToNO => this.Outer?.To ?? this.Visitor?.To ?? this.ToExt?.ID;
    }
}
