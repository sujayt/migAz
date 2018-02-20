﻿using MigAz.Core;
using MigAz.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigAz.Azure.MigrationTarget
{
    public class Route : Core.MigrationTarget
    {
        private IRoute _Source;
        private NextHopTypeEnum _NextHopType = NextHopTypeEnum.VnetLocal;
        private String _AddressPrefix = String.Empty;
        private String _NextHopIpAddress = String.Empty;
        

        private Route() { }

        public Route(IRoute route, TargetSettings targetSettings)
        {
            _Source = route;

            this.SetTargetName(route.Name, targetSettings);
            this.NextHopType = route.NextHopType;
            this.AddressPrefix = route.AddressPrefix;
            this.NextHopIpAddress = route.NextHopIpAddress;
        }

        public NextHopTypeEnum NextHopType
        {
            get { return _NextHopType; }
            set { _NextHopType = value; }
        }

        public String AddressPrefix
        {
            get { return _AddressPrefix; }
            set
            {
                if (value == null)
                    _AddressPrefix = String.Empty;
                else
                    _AddressPrefix = value.Trim();
            }
        }
        public String NextHopIpAddress
        {
            get { return _NextHopIpAddress; }
            set
            {
                if (value == null)
                    _NextHopIpAddress = String.Empty;
                else
                    _NextHopIpAddress = value.Trim();
            }
        }

        public String SourceName
        {
            get { return String.Empty; }
        }
        public override string ImageKey { get { return "Route"; } }

        public override string FriendlyObjectName { get { return "Route"; } }



        public override void SetTargetName(string targetName, TargetSettings targetSettings)
        {
            this.TargetName = targetName.Trim().Replace(" ", String.Empty);
            this.TargetNameResult = this.TargetName;
        }
    }
}
