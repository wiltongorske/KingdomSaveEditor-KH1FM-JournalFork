using System;
using Xe.Tools;

namespace KHSave.SaveEditor.Kh1.Models
{
    public class JournalReportModel : BaseNotifyPropertyChanged
    {
        private readonly Func<bool> getter;
        private readonly Action<bool> setter;

        public JournalReportModel(string name, Func<bool> getter, Action<bool> setter)
        {
            Name = name;
            this.getter = getter;
            this.setter = setter;
        }

        public string Name { get; }

        public bool IsVisible
        {
            get => getter();
            set
            {
                setter(value);
                OnPropertyChanged();
            }
        }
    }
}
