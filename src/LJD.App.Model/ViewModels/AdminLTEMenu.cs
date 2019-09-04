using System.Collections.Generic;

namespace LJD.App.Model.ViewModels
{ 

    public class AdminLteMenu 
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public List<AdminLteMenu> Children { get; set; }
        public string TargetType { get; set; }

        public bool IsHeader { get; set; }
    }
}