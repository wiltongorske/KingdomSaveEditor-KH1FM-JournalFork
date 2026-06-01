using KHSave.Lib1;
using KHSave.Lib1.Types;
using KHSave.SaveEditor.Kh1.Models;
using System.Collections.ObjectModel;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class JournalViewModel
    {
        public JournalViewModel(SaveKh1.SaveFinalMix save)
        {
            Heartless = new ObservableCollection<JournalReportModel>
            {
                new JournalReportModel(
                    "Red Armor",
                    () => save.JournalHeartlessRedArmor,
                    value => save.JournalHeartlessRedArmor = value),
            };

            Reports = new ObservableCollection<JournalReportModel>
            {
                new JournalReportModel(
                    "Ansem's Report 11",
                    () => save.JournalAnsemsReport11,
                    value =>
                    {
                        save.JournalAnsemsReport11 = value;
                        save.InventoryCount[(int)EquipmentType.AnsemsReport11] = value ? (byte)1 : (byte)0;
                    }),
                new JournalReportModel(
                    "Ansem's Report 12",
                    () => save.JournalAnsemsReport12,
                    value =>
                    {
                        save.JournalAnsemsReport12 = value;
                        save.InventoryCount[(int)EquipmentType.AnsemsReport12] = value ? (byte)1 : (byte)0;
                    }),
                new JournalReportModel(
                    "Ansem's Report 13",
                    () => save.JournalAnsemsReport13,
                    value =>
                    {
                        save.JournalAnsemsReport13 = value;
                        save.InventoryCount[(int)EquipmentType.AnsemsReport13] = value ? (byte)1 : (byte)0;
                    }),
            };
        }

        public ObservableCollection<JournalReportModel> Heartless { get; }
        public ObservableCollection<JournalReportModel> Reports { get; }
    }
}
