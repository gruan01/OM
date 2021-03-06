﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OM.Api.Models
{

    /// <summary>
    /// 设备信息
    /// </summary>
    [XmlRoot("DeviceInfo")]
    public class DeviceInfo
    {

        /// <summary>
        /// 生产商
        /// </summary>
        [XmlElement("manufacturer")]
        public string Manufacturer { get; set; }

        /// <summary>
        /// 硬件版本
        /// </summary>
        [XmlElement("model")]
        public string Model { get; set; }

        /// <summary>
        /// 软件版本
        /// </summary>
        [XmlElement("version")]
        public string Version { get; set; }

        /// <summary>
        /// MAC地址， 由系统参数API_MAC决定是否携带MAC地址
        /// </summary>
        [XmlElement("mac")]
        public string MAC { get; set; }

        /// <summary>
        /// 设备列表
        /// </summary>
        [XmlArray("devices")]
        [XmlArrayItem("line", Type = typeof(LineDeviceItem))]
        [XmlArrayItem("ext", Type = typeof(ExtDeviceItem))]
        [XmlArrayItem("group", Type = typeof(DeviceGroup))]
        public List<DeviceItem> Devices { get; set; }


        /// <summary>
        /// 中继（外线）列表
        /// </summary>
        [XmlIgnore]
        public IEnumerable<LineDeviceItem> Lines => this.Devices?.OfType<LineDeviceItem>();

        /// <summary>
        /// 分机列表
        /// </summary>
        [XmlIgnore]
        public IEnumerable<ExtDeviceItem> Exts => this.Devices?.OfType<ExtDeviceItem>();

        /// <summary>
        /// 设备分组列表
        /// </summary>
        [XmlIgnore]
        public IEnumerable<DeviceGroup> Gropus => this.Devices?.OfType<DeviceGroup>();
    }
}
