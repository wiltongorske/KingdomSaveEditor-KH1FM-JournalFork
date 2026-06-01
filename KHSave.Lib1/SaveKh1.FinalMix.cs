using KHSave.Lib1.Models;
using KHSave.Lib1.Types;
using System.IO;
using Xe.BinaryMapper;

namespace KHSave.Lib1
{
    public partial class SaveKh1
    {
        public class SaveFinalMix : ISaveKh1
        {
            public bool IsFinalMix => true;

            [Data(0, 0x16C00)] public byte[] Data { get; set; }

            [Data(0)] public uint MagicCode { get; set; }
            [Data(Count = 10, Stride = 0x74)] public Character[] Characters { get; set; }

            [Data(0x48E)] public PlayableCharacterType PlayableCharacter { get; set; }
            [Data(0x48F)] public PlayableCharacterType CompanionCharacter1 { get; set; }
            [Data(0x490)] public PlayableCharacterType CompanionCharacter2 { get; set; }
            [Data(0x491)] public PlayableCharacterType CompanionCharacter3 { get; set; }

            [Data(0x499, Count = 0x100)] public byte[] InventoryCount { get; set; }

            [Data(0x599, Count = 4)] public byte[] SharedAbilities { get; set; }

            [Data(0x844)] public CommandType ShortcutCircle { get; set; }
            [Data(0x845)] public CommandType ShortcutTriangle { get; set; }
            [Data(0x846)] public CommandType ShortcutSquare { get; set; }

            [Data(0x2040)] public WorldType World { get; set; }
            [Data(0x2044)] public uint Room { get; set; }
            [Data(0x2048)] public uint SpawnLocation { get; set; }

            [Data(0x16400)] public int AutoLock { get; set; }
            [Data(0x16404)] public int TargetLock { get; set; }
            [Data(0x16408)] public int Camera { get; set; }
            [Data(0x16410)] public int Vibration { get; set; }
            [Data(0x16414)] public int Sound { get; set; }

            [Data(0x1641C)] public uint Munny { get; set; }
            [Data(0x1642C)] public byte Difficulty { get; set; }

            private const int JournalHeartlessRedArmorOffset = 0x16F9;
            private const byte JournalHeartlessRedArmorMask = 0x02;
            private const int JournalAnsemsReportsOffset = 0x19C1;
            private const byte JournalAnsemsReport11Mask = 0x20;
            private const byte JournalAnsemsReport12Mask = 0x10;
            private const byte JournalAnsemsReport13Mask = 0x08;

            // KH1FM stores the FM-only Ansem Report journal visibility bits
            // separately from the generic inventory count table.
            public bool JournalAnsemsReport11
            {
                get => GetFlag(JournalAnsemsReportsOffset, JournalAnsemsReport11Mask);
                set => SetFlag(JournalAnsemsReportsOffset, JournalAnsemsReport11Mask, value);
            }

            public bool JournalAnsemsReport12
            {
                get => GetFlag(JournalAnsemsReportsOffset, JournalAnsemsReport12Mask);
                set => SetFlag(JournalAnsemsReportsOffset, JournalAnsemsReport12Mask, value);
            }

            public bool JournalAnsemsReport13
            {
                get => GetFlag(JournalAnsemsReportsOffset, JournalAnsemsReport13Mask);
                set => SetFlag(JournalAnsemsReportsOffset, JournalAnsemsReport13Mask, value);
            }

            // KH1FM stores at least one Heartless entry completion bit outside
            // the obvious journal area. This flag marks Red Armor complete.
            public bool JournalHeartlessRedArmor
            {
                get => GetFlag(JournalHeartlessRedArmorOffset, JournalHeartlessRedArmorMask);
                set => SetFlag(JournalHeartlessRedArmorOffset, JournalHeartlessRedArmorMask, value);
            }

            public void Write(Stream stream) =>
                BinaryMapping.WriteObject(stream.FromBegin(), this);

            private bool GetFlag(int offset, byte mask) => (Data[offset] & mask) == mask;

            private void SetFlag(int offset, byte mask, bool value)
            {
                if (value)
                    Data[offset] |= mask;
                else
                    Data[offset] &= (byte)~mask;
            }
        }
    }
}
