﻿using OpenSage.Data.Ini;
using OpenSage.Data.Ini.Parser;

namespace OpenSage.Logic.Object
{
    [AddedIn(SageGame.CncGeneralsZeroHour)]
    public sealed class RiderChangeContainModuleData : TransportContainModuleData
    {
        internal static new RiderChangeContainModuleData Parse(IniParser parser) => parser.ParseBlock(FieldParseTable);

        private static new readonly IniParseTable<RiderChangeContainModuleData> FieldParseTable = TransportContainModuleData.FieldParseTable
            .Concat(new IniParseTable<RiderChangeContainModuleData>
            {
                { "Rider1", (parser, x) => x.Rider1 = RiderChangeRider.Parse(parser) },
                { "Rider2", (parser, x) => x.Rider2 = RiderChangeRider.Parse(parser) },
                { "Rider3", (parser, x) => x.Rider3 = RiderChangeRider.Parse(parser) },
                { "Rider4", (parser, x) => x.Rider4 = RiderChangeRider.Parse(parser) },
                { "Rider5", (parser, x) => x.Rider5 = RiderChangeRider.Parse(parser) },
                { "Rider6", (parser, x) => x.Rider6 = RiderChangeRider.Parse(parser) },
                { "Rider7", (parser, x) => x.Rider7 = RiderChangeRider.Parse(parser) },

                { "ScuttleDelay", (parser, x) => x.ScuttleDelay = parser.ParseInteger() },
                { "ScuttleStatus", (parser, x) => x.ScuttleStatus = parser.ParseEnum<ObjectStatus>() },
            });

        public RiderChangeRider Rider1 { get; private set; }
        public RiderChangeRider Rider2 { get; private set; }
        public RiderChangeRider Rider3 { get; private set; }
        public RiderChangeRider Rider4 { get; private set; }
        public RiderChangeRider Rider5 { get; private set; }
        public RiderChangeRider Rider6 { get; private set; }
        public RiderChangeRider Rider7 { get; private set; }

        public int ScuttleDelay { get; private set; }
        public ObjectStatus ScuttleStatus { get; private set; }
    }

    public sealed class RiderChangeRider
    {
        internal static RiderChangeRider Parse(IniParser parser)
        {
            return new RiderChangeRider
            {
                RiderObject = parser.ParseAssetReference(),
                ModelCondition = parser.ParseEnum<ModelConditionFlag>(),
                WeaponCondition = parser.ParseEnum<WeaponSetConditions>(),
                ObjectStatus = parser.ParseEnum<ObjectStatus>(),
                CommandSet = parser.ParseAssetReference(),
                LocomotorSet = parser.ParseEnum<LocomotorSet>()
            };
        }

        public string RiderObject { get; private set; }
        public ModelConditionFlag ModelCondition { get; private set; }
        public WeaponSetConditions WeaponCondition { get; private set; }
        public ObjectStatus ObjectStatus { get; private set; }
        public string CommandSet { get; private set; }
        public LocomotorSet LocomotorSet { get; private set; }
    }
}